using AlbedoTeam.Sdk.FailFast;
using Identity.Api.Models;
using MediatR;

namespace Identity.Api.Services.UserTypeService.Requests
{
    public class Delete : IRequest<Result<UserType>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
    }
}