namespace Identity.Api.Services.AuthServerService.Requests
{
    using AlbedoTeam.Identity.Contracts.Common;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class Create : IRequest<Result<AuthServer>>
    {
        public string AccountId { get; set; }
        public Provider Provider { get; set; }
    }
}