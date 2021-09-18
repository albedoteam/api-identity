namespace Identity.Api.Models
{
    using System;

    public class PasswordRecovery
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string UserId { get; set; }
        public string ValidationToken { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}