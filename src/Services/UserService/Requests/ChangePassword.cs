namespace Identity.Api.Services.UserService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class ChangePassword : IRequest<Result<User>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}