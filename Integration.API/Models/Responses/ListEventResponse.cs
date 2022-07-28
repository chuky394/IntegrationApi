using Newtonsoft.Json;
using System.Collections.Generic;

namespace Integration.API.Responses
{
    public class ListEventResponse
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("value")]
        public List<EventResponse> Value { get; set; }
    }   
}