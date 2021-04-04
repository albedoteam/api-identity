namespace Identity.Api.Services.AuthServerService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class Get : IRequest<Result<AuthServer>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
        public bool ShowDeleted { get; set; }
    }
}