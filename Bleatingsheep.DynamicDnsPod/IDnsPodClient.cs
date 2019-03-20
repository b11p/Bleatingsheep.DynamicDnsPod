using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.DataAnnotations;

namespace Bleatingsheep.DynamicDnsPod
{
    [HttpHost("https://dnsapi.cn/")]
    public interface IDnsPodClient : IHttpApi
    {
        [HttpPost("Record.List")]
        ITask<Record> GetRecordListAsync(
            [AliasAs("login_token"), Required, FormField] string loginToken,
            [Required, FormField] string domain,
            [AliasAs("sub_domain"), FormField] string subdomain,
            [AliasAs("record_type"), FormField] string recordType = "AAAA",
            [FormField] string format = "json");

        [HttpPost("Record.Modify")]
        ITask<ResponseBase> ModifyRecordAsync(
            [AliasAs("login_token"), Required, FormField] string loginToken,
            [Required, FormField] string domain,
            [AliasAs("sub_domain"), FormField] string subdomain,
            [AliasAs("record_id"), Required, FormField] long recordId,
            [Required, FormField] string value,
            [AliasAs("record_line_id"), Required, FormField] string recordLineId,
            [AliasAs("record_type"), Required, FormField] string recordType = "AAAA",
            [FormField] string format = "json");
    }
}
