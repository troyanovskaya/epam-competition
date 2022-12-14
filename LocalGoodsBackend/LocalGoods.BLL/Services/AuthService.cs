using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LocalGoods.BLL.Exceptions.BadRequestException;
using LocalGoods.BLL.Exceptions.NotFoundException;
using LocalGoods.BLL.Models.Auth;
using LocalGoods.BLL.Models.Auth.JWT;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;

namespace LocalGoods.BLL.Services
{
    public class AuthService: IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IJwtHandler _jwtHandler;
        private readonly ICityRepository _cityRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private const string BuyerRole = "Buyer";

        public AuthService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper, 
            IJwtHandler jwtHandler,
            ICityRepository cityRepository,
            IHttpContextAccessor httpContextAccessor,
            IEmailService emailService, 
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
            _cityRepository = cityRepository;
            _httpContextAccessor = httpContextAccessor;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task SignupAsync(SignupModel model)
        {
            if (!await _cityRepository.CheckIfEntityExistsByIdAsync(model.CityId))
            {
                throw new CityNotFoundException(model.CityId);
            }

            var user = _mapper.Map<User>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                throw new AuthException(result.ToString());
            }

            await SendEmailConfirmationLink(user.Email);
            await _userManager.AddToRoleAsync(user, BuyerRole);
        }
        
        public async Task SendEmailConfirmationLink(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                throw new UserNotFoundException(email);
            }
            
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var tokenBytes = Encoding.UTF8.GetBytes(token);
            var tokenEncoded = WebEncoders.Base64UrlEncode(tokenBytes);
            
            var confirmationLink = _configuration.GetSection("UIUrl").Value
                                   + $"auth/confirm-email?token={tokenEncoded}&email={user.Email}";

            await _emailService.SendEmailConfirmationLinkAsync(user.Email, confirmationLink);
        }

        public async Task<JwtResponse> LoginAsync(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                throw new UserNotFoundException("Invalid email or password");
            }

            var result = await _signInManager
                .PasswordSignInAsync(user, model.Password, false, false);

            if (!result.Succeeded)
            {
                throw new InvalidCredentialException("Invalid email or password");
            }

            var claims = await _jwtHandler.GetClaimsAsync(user);
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var token = _jwtHandler.GenerateToken(signingCredentials, claims);

            return new JwtResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
            };
        }

        public async Task ConfirmEmailAsync(ConfirmEmailModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                throw new AuthException($"User with email {model.Email} was not found");
            }

            var tokenBytes = WebEncoders.Base64UrlDecode(model.Token);
            var tokenDecoded = Encoding.UTF8.GetString(tokenBytes);
            
            var result = await _userManager.ConfirmEmailAsync(user, tokenDecoded);

            if (!result.Succeeded)
            {
                throw new AuthException($"Failed to confirm email {model.Email}");
            }
        }

        public async Task ForgotPasswordAsync(ForgotPasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                throw new AuthException($"User with email {model.Email} was not found");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var tokenBytes = Encoding.UTF8.GetBytes(token);
            var tokenEncoded = WebEncoders.Base64UrlEncode(tokenBytes);
            
            var callBack = _configuration.GetSection("UIUrl").Value
                           + $"/auth/password-recovery?token={tokenEncoded}&email={user.Email}";

            await _emailService.SendResetPasswordLinkAsync(user.Email, callBack);
        }

        public async Task ResetPasswordAsync(ResetPasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            
            if (user == null)
            {
                throw new AuthException($"User with email {model.Email} was not found");
            }

            var tokenBytes = WebEncoders.Base64UrlDecode(model.Token);
            var tokenDecoded = Encoding.UTF8.GetString(tokenBytes);
            
            var result = await _userManager.ResetPasswordAsync(user, tokenDecoded, model.Password);

            if (!result.Succeeded)
            {
                throw new AuthException("Failed to reset password");
            }
        }
    }
}