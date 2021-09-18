namespace Identity.Api.Services.UserTypeService.Requests
{
    using System.Collections.Generic;
    using AlbedoTeam.Identity.Contracts.Common;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class Create : IRequest<Result<UserType>>
    {
        public string AccountId { get; set; }
        public Provider Provider { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public List<string> PredefinedGroups { get; set; }
    }
}