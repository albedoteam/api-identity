﻿using System.Collections.Generic;
using AlbedoTeam.Sdk.FailFast;
using Identity.Api.Models;
using MediatR;

namespace Identity.Api.Services.UserService.Requests
{
    public class Create : IRequest<Result<User>>
    {
        public string AccountId { get; set; }
        public string UserTypeId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Dictionary<string, string> CustomProfileFields { get; set; }
        public List<string> Groups { get; set; }
    }
}