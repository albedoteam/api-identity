using System.Collections.Generic;
using AlbedoTeam.Identity.Contracts.Common;
using AlbedoTeam.Sdk.FailFast;
using Identity.Api.Models;
using MediatR;

namespace Identity.Api.Services.UserTypeService.Requests
{
    public class Create : IRequest<Result<UserType>>
    {
        public string AccountId { get; set; }
        public Provider Provider { get; set; }
        public UsernameFormatType UsernameFormatType { get; set; }
        public string UsernameFormatExpression { get; set; }
        public List<string> PredefinedGroups { get; set; }
    }
}