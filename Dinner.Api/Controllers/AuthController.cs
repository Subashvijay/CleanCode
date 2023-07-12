namespace Dinner.Api.Controllers
{
    using Dinner.Application.Services.Auth.Queries;
    using Dinner.Application.Services.Auth.Commands;

    using Dinner.Contracts.Authentication;

    using Microsoft.AspNetCore.Mvc;

    using OneOf;
    using Dinner.Application.Services.Auth.Models;
    using MediatR;
    using Dinner.Application.Commands;

    [ApiController]
    [Route("[controller]")]
    //  [ExceptionHandlingFilter] --> adding custom filter to controller.
    public class AuthController : ControllerBase
    {
        private readonly IMediator _MediatoR;

        public AuthController(IMediator mediator)
        {
            this._MediatoR = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand request)
        {
            OneOf<AuthResult, Application.Common.Errors.DuplicateEmailError> result = await _MediatoR.Send(request);
            return result.Match(
                 r => Ok(r),
                 _ => Problem(statusCode: 400, title: "Email Already exist")
             );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand request)
        {
            var result = await _MediatoR.Send(request);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return Problem(statusCode: 500, title: result.Errors[0].Message);
        }
    }
}