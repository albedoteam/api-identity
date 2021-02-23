using AlbedoTeam.Sdk.FailFast;
using Identity.Api.Models;
using MediatR;

namespace Identity.Api.Services.UserService.Requests
{
    public class RemoveGroup : IRequest<Result<User>>
    {
        public string AccountId { get; set; }
        public string UserId { get; set; }
        public string GroupId { get; set; }
    }
}