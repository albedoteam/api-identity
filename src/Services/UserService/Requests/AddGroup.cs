namespace Identity.Api.Services.UserService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class AddGroup : IRequest<Result<User>>
    {
        public string AccountId { get; set; }
        public string UserId { get; set; }
        public string GroupId { get; set; }
    }
}