namespace Identity.Api.Models
{
    using System;
    using System.Collections.Generic;
    using AlbedoTeam.Identity.Contracts.Common;

    public class UserType
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> PredefinedGroups { get; set; }
        public Provider Provider { get; set; }
        public string ProviderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}