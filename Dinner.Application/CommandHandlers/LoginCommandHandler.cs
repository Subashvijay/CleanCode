namespace Dinner.Application.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;

    using Dinner.Application.Commands;
    using Dinner.Application.Services.Auth.Models;
    using Dinner.Application.Services.Auth.Queries;

    using FluentResults;

    using MediatR;

    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<AuthResult>>
    {
        private readonly IAuthQueryService _AuthQueryService;

        public LoginCommandHandler(IAuthQueryService authQueryService)
        {
            this._AuthQueryService = authQueryService;
        }
        public async Task<Result<AuthResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return _AuthQueryService.Login(request);
        }
    }
}