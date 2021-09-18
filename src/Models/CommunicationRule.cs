namespace Identity.Api.Models
{
    using System.Collections.Generic;

    public class CommunicationRule
    {
        public string TemplateId { get; set; }
        public Dictionary<string, string> DefaultContentParameters { get; set; }
    }
}