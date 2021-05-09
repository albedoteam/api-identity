namespace Identity.Api.Services.GroupService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    // [Cache(120)]
    public class Get : IRequest<Result<Group>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
        public bool ShowDeleted { get; set; }
        public bool NoCache { get; set; }
    }
}