namespace Identity.Api.Services.PasswordRecoveryService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class Create : IRequest<Result<PasswordRecovery>>
    {
        public string AccountId { get; set; }
        public string UserEmail { get; set; }
    }
}