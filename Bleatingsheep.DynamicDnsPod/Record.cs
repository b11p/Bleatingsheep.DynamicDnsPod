using System;
using Newtonsoft.Json;

namespace Bleatingsheep.DynamicDnsPod
{
    public partial class Record : ResponseBase
    {
        [JsonProperty("domain")]
        public BriefDomainInfo Domain { get; set; }

        [JsonProperty("info")]
        public RecordCountInfo Info { get; set; }

        [JsonProperty("records")]
        public RecordInfo[] Records { get; set; }
    }

    public partial class BriefDomainInfo
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("punycode")]
        public string Punycode { get; set; }

        [JsonProperty("grade")]
        public string Grade { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("ext_status")]
        public string ExtStatus { get; set; }

        [JsonProperty("ttl")]
        public int Ttl { get; set; }

        [JsonProperty("min_ttl")]
        public int MinTtl { get; set; }

        [JsonProperty("dnspod_ns")]
        public string[] DnspodNs { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class RecordInfo
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("ttl")]
        public int Ttl { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("enabled")]
        public int Enabled { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("updated_on")]
        public DateTime UpdatedOn { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("line")]
        public string Line { get; set; }

        [JsonProperty("line_id")]
        public string LineId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("weight")]
        public object Weight { get; set; }

        [JsonProperty("monitor_status")]
        public string MonitorStatus { get; set; }

        [JsonProperty("remark")]
        public string Remark { get; set; }

        [JsonProperty("use_aqb")]
        public string UseAqb { get; set; }

        [JsonProperty("mx")]
        public string Mx { get; set; }
    }
}