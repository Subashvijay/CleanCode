namespace Dinner.Api.Controllers
{
    using Dinner.Application.Services.Auth;
    using Dinner.Contracts.Authentication;

    using Microsoft.AspNetCore.Mvc;

    using OneOf;

    [ApiController]
    [Route("[controller]")]
    //  [ExceptionHandlingFilter] --> adding custom filter to controller.
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
            OneOf<AuthResult, Application.Common.Errors.DuplicateEmailError> result = _AuthService.Register(request);
            return result.Match(
                 r => Ok(r),
                 _ => Problem(statusCode: 400, title: "Email Already exist")
             );
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            return Ok(_AuthService.Login(request));
        }
    }
}