using System.Threading.Tasks;
using AutoMapper;
using LocalGoods.BLL.Interfaces;
using LocalGoods.BLL.Models.Auth;
using LocalGoods.PL.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.PL.Controllers
{
    [ApiController]
    [Route(("api/auth"))]
    public class AuthController: ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(
            IAuthService authService,
            IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var loginModel = _mapper.Map<LoginModel>(request);
            var token = await _authService.LoginAsync(loginModel);
            return Ok(token);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(SignupRequest request)
        {
            var signupModel = _mapper.Map<SignupModel>(request);
            await _authService.SignupAsync(signupModel);
            return Ok();
        }
    }
}