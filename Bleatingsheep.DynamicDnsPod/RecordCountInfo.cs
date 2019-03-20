namespace Bleatingsheep.DynamicDnsPod
{
    using Newtonsoft.Json;

    public partial class RecordCountInfo
    {
        [JsonProperty("sub_domains")]
        public long SubDomains { get; set; }

        [JsonProperty("record_total")]
        public long RecordTotal { get; set; }

        [JsonProperty("records_num")]
        public long RecordsNum { get; set; }
    }
}