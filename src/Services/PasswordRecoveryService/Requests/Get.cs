using AlbedoTeam.Sdk.FailFast;
using Identity.Api.Models;
using MediatR;

namespace Identity.Api.Services.PasswordRecoveryService.Requests
{
    public class Get: IRequest<Result<PasswordRecovery>>
    {
        public string AccountId { get; set; }
        public string ValidationToken { get; set; }
    }
}