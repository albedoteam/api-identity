using AlbedoTeam.Sdk.FailFast;
using Identity.Api.Models;
using MediatR;

namespace Identity.Api.Services.UserTypeService.Requests
{
    public class RemoveGroup : IRequest<Result<UserType>>
    {
        public string AccountId { get; set; }
        public string UserTypeId { get; set; }
        public string GroupId { get; set; }
    }
}