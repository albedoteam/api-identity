using System;
using System.Collections.Generic;
using AlbedoTeam.Identity.Contracts.Common;
using AlbedoTeam.Identity.Contracts.Responses;

namespace Identity.Api.Models
{
    public class User
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string UserTypeId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public Dictionary<string, string> CustomProfileFields { get; set; }
        public List<string> Groups { get; set; }
        public Provider Provider { get; set; }
        public string ProviderId { get; set; }
        public string UsernameAtProvider { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}