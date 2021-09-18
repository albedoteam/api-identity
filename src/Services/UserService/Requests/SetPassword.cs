namespace Identity.Api.Services.UserService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class SetPassword : IRequest<Result<User>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
        public string Password { get; set; }
    }
}