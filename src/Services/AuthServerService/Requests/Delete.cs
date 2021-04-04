namespace Identity.Api.Services.AuthServerService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class Delete : IRequest<Result<AuthServer>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
    }
}