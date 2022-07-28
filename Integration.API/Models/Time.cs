using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Integration.API.Models
{
    public class Time
    {
        [JsonProperty("dateTime")]
        public DateTime DateTime { get; set; }

        [JsonProperty("timeZone")]
        [DefaultValue("Argentina Standard Time")]
        public string TimeZone { get; set; }
    }
}