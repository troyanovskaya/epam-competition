using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using LocalGoods.BLL.Models.Auth;
using LocalGoods.BLL.Models.Auth.JWT;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.PL.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IValidator<ConfirmEmailModel> _confirmEmailValidator;
        private readonly IValidator<ForgotPasswordModel> _forgotPasswordValidator;
        private readonly IValidator<LoginModel> _loginValidator;
        private readonly IValidator<ResetPasswordModel> _resetPasswordValidator;
        private readonly IValidator<SignupModel> _signupValidator;

        public AuthController(
            IAuthService authService,
            IMapper mapper,
            IValidator<ConfirmEmailModel> confirmEmailValidator,
            IValidator<ForgotPasswordModel> forgotPasswordValidator,
            IValidator<LoginModel> loginValidator,
            IValidator<ResetPasswordModel> resetPasswordValidator,
            IValidator<SignupModel> signupValidator)
        {
            _authService = authService;
            _mapper = mapper;
            _confirmEmailValidator = confirmEmailValidator;
            _forgotPasswordValidator = forgotPasswordValidator;
            _loginValidator = loginValidator;
            _resetPasswordValidator = resetPasswordValidator;
            _signupValidator = signupValidator;
        }
        
        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery]ConfirmEmailRequest request)
        {
            var confirmEmailModel = _mapper.Map<ConfirmEmailModel>(request);

            await _confirmEmailValidator.ValidateAndThrowAsync(confirmEmailModel);

            await _authService.ConfirmEmailAsync(confirmEmailModel);
            return Ok();
        }

        [HttpGet("sendEmailConfirmationLink")]
        public async Task<IActionResult> SendEmailConfirmation([FromQuery]string email)
        {
            await _authService.SendEmailConfirmationLink(email);
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var loginModel = _mapper.Map<LoginModel>(request);

            await _loginValidator.ValidateAndThrowAsync(loginModel);

            var token = await _authService.LoginAsync(loginModel);
            return Ok(token);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(SignupRequest request)
        {
            var signupModel = _mapper.Map<SignupModel>(request);

            await _signupValidator.ValidateAndThrowAsync(signupModel);

            await _authService.SignupAsync(signupModel);
            return Ok();
        }
        
        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request)
        {
            var forgotPasswordModel = _mapper.Map<ForgotPasswordModel>(request);

            await _forgotPasswordValidator.ValidateAndThrowAsync(forgotPasswordModel);

            await _authService.ForgotPasswordAsync(forgotPasswordModel);
            return Ok();
        }

        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            var resetPasswordModel = _mapper.Map<ResetPasswordModel>(request);

            await _resetPasswordValidator.ValidateAndThrowAsync(resetPasswordModel);

            await _authService.ResetPasswordAsync(resetPasswordModel);
            return Ok();
        }
    }
}