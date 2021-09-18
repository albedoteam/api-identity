namespace Identity.Api.Services.AuthServerService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class Update : IRequest<Result<AuthServer>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
        public CommunicationRules CommunicationRules { get; set; }
    }
}