namespace Bleatingsheep.DynamicDnsPod
{
    using System;
    using Newtonsoft.Json;

    public partial class Status
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}