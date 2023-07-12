namespace Dinner.Application.CommandHandlers
{
    using MediatR;
    using Dinner.Application.Commands;
    using System.Threading.Tasks;
    using System.Threading;
    using OneOf;
    using Dinner.Application.Services.Auth.Models;
    using Dinner.Application.Common.Errors;
    using Dinner.Application.Services.Auth.Commands;

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, OneOf<AuthResult, DuplicateEmailError>>
    {
        private readonly IAuthCommandService _AuthCommandService;

        public RegisterCommandHandler(IAuthCommandService authCommandService)
        {
            this._AuthCommandService = authCommandService;
        }
        public async Task<OneOf<AuthResult, DuplicateEmailError>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var result = _AuthCommandService.Register(request);
            return result;
        }
    }
}