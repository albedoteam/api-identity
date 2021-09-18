namespace Identity.Api.Services.UserService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class Delete : IRequest<Result<User>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
    }
}