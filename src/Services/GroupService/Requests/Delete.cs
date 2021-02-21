using AlbedoTeam.Sdk.FailFast;
using Identity.Api.Models;
using MediatR;

namespace Identity.Api.Services.GroupService.Requests
{
    public class Delete : IRequest<Result<Group>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
    }
}