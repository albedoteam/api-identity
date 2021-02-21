using System;
using AlbedoTeam.Identity.Contracts.Common;

namespace Identity.Api.Models
{
    public class UserType
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Provider Provider { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}