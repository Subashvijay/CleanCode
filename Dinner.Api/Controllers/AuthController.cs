using Dinner.Application.Services.Auth;
using Dinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _AuthService;

        public AuthController(IAuthService authService)
        {
            this._AuthService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            return Ok(_AuthService.Register(request));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            return Ok(_AuthService.Login(request));
        }
    }
}