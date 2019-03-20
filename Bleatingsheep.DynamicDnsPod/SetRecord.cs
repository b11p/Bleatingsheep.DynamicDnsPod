using Newtonsoft.Json;

namespace Bleatingsheep.DynamicDnsPod
{
    public class SetRecord
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Sub domain.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("weight")]
        public object Weight { get; set; }
    }
}
