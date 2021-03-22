using System;
using System.Collections.Generic;
using AlbedoTeam.Identity.Contracts.Common;

namespace Identity.Api.Models
{
    public class AuthServer
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string Name { get; set; }
        public string Audience { get; set; }
        public string Description { get; set; }
        public string Issuer { get; set; }
        public string AuthUrl { get; set; }
        public string AccessTokenUrl { get; set; }
        public string ClientId { get; set; }
        public List<string> BasicScopes { get; set; }
        public bool Active { get; set; }
        public Provider Provider { get; set; }
        public string ProviderId { get; set; }
        public CommunicationRules CommunicationRules { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}