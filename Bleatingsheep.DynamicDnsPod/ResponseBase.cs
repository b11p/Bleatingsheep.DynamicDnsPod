using Newtonsoft.Json;

namespace Bleatingsheep.DynamicDnsPod
{
    public class ResponseBase
    {
        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}
