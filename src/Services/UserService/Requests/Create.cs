namespace Identity.Api.Services.UserService.Requests
{
    using System.Collections.Generic;
    using AlbedoTeam.Identity.Contracts.Common;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class Create : IRequest<Result<User>>
    {
        public string AccountId { get; set; }
        public Provider Provider { get; set; }
        public string UserTypeId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Dictionary<string, string> CustomProfileFields { get; set; }
        public List<string> Groups { get; set; }
    }
}