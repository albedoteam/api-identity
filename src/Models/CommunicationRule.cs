using System.Collections.Generic;

namespace Identity.Api.Models
{
    public class CommunicationRule
    {
        public string TemplateId { get; set; }
        public Dictionary<string, string> DefaultContentParameters { get; set; }
    }
}