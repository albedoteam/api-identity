using AlbedoTeam.Sdk.FailFast;
using Identity.Api.Models;
using MediatR;

namespace Identity.Api.Services.GroupService.Requests
{
    public class Create : IRequest<Result<Group>>
    {
        public string AccountId { get; set; }
        public string SuffixName { get; set; }
        public string SuffixDescription { get; set; }
        public bool IsDefault { get; set; }
    }
}