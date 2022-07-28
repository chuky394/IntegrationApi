using Newtonsoft.Json;
using System;

namespace Integration.API.Responses
{
    public class StatusResponse
    {
        [JsonProperty("response")]
        public string Response { get; set; }

        [JsonProperty("time")]
        public DateTime Time { get; set; }
    }
}