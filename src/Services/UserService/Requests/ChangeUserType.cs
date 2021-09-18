namespace Identity.Api.Services.UserService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class ChangeUserType : IRequest<Result<User>>
    {
        public string AccountId { get; set; }
        public string UserId { get; set; }
        public string UserTypeId { get; set; }
    }
}