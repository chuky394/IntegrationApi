using Newtonsoft.Json;

namespace Integration.API.Responses
{
    public class LocationResponse
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("locationType")]
        public string LocationType { get; set; }

        [JsonProperty("uniqueId")]
        public string UniqueId { get; set; }

        [JsonProperty("uniqueIdType")]
        public string UniqueIdType { get; set; }
    }
}