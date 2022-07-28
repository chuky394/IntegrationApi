using Integration.API.Models;
using Newtonsoft.Json;

namespace Integration.API.Responses
{
    public class OrganizerResponse
    {
        [JsonProperty("emailAddress")]
        public EmailAddress EmailAddress { get; set; }
    }
}