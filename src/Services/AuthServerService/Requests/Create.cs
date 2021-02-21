using AlbedoTeam.Identity.Contracts.Common;
using AlbedoTeam.Sdk.FailFast;
using Identity.Api.Models;
using MediatR;

namespace Identity.Api.Services.AuthServerService.Requests
{
    public class Create : IRequest<Result<AuthServer>>
    {
        public string AccountId { get; set; }
        public Provider Provider { get; set; }
    }
}