using AlbedoTeam.Sdk.FailFast;
using Identity.Api.Models;
using MediatR;

namespace Identity.Api.Services.PasswordRecoveryService.Requests
{
    public class Create: IRequest<Result<PasswordRecovery>>
    {
        public string AccountId { get; set; }
        public string UserEmail { get; set; }
    }
}