using System.Collections.Generic;
using Newtonsoft.Json;

namespace LaunchData.Lib.Models
{
    public class Launch
    {
        public string Id { get; set; }
        [JsonProperty(PropertyName = "full_name")]
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
