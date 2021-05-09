namespace Identity.Api.Services.UserService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    // [Cache(120)]
    public class Get : IRequest<Result<User>>
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public bool ShowDeleted { get; set; }
        public bool NoCache { get; set; }
    }
}