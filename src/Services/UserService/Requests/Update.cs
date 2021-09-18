namespace Identity.Api.Services.UserService.Requests
{
    using System.Collections.Generic;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class Update : IRequest<Result<User>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Dictionary<string, string> CustomProfileFields { get; set; }
    }
}