using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Threading.Tasks;
using AutoMapper;
using LocalGoods.BLL.Exceptions.BadRequestException;
using LocalGoods.BLL.Exceptions.NotFoundException;
using LocalGoods.BLL.Models.Auth;
using LocalGoods.BLL.Models.Auth.JWT;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace LocalGoods.BLL.Services
{
    public class AuthService: IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IJwtHandler _jwtHandler;
        private readonly ICityRepository _cityRepository;

        public AuthService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper, 
            IJwtHandler jwtHandler,
            ICityRepository cityRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
            _cityRepository = cityRepository;
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

            // TODO - Seed Roles and add user to a default one
        }

        public async Task<JwtResponse> LoginAsync(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                throw new Exception(model.Email);
            }

            var result = await _signInManager
                .PasswordSignInAsync(user, model.Password, model.RememberMe, false);

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
                ValidTo = token.ValidTo
            };
        }
    }
}