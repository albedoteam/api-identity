namespace Identity.Api.Services.UserService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class Get : IRequest<Result<User>>
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public bool ShowDeleted { get; set; }
    }
}