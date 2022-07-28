using Integration.API.Models;
using Newtonsoft.Json;

namespace Integration.API.Responses
{
    public class AttendeeResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public StatusResponse Status { get; set; }

        [JsonProperty("emailAddress")]
        public EmailAddress EmailAddress { get; set; }
    }
}