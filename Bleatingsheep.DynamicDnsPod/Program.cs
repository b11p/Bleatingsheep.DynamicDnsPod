using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Nager.PublicSuffix;
using WebApiClient;
using WebApiClient.Contexts;

namespace Bleatingsheep.DynamicDnsPod
{
    class Program
    {
        private static IPAddress s_lastIp;

        static async Task Main(string[] args)
        {
            string domain = Environment.GetEnvironmentVariable("DOMAIN");
            string token = Environment.GetEnvironmentVariable("LOGIN_TOKEN");
            var domainParser = new DomainParser(new WebTldRuleProvider());
            var domainInfo = domainParser.Get(domain);
            string regist = domainInfo.RegistrableDomain;
            string subDomain = domainInfo.SubDomain;

            while (true)
            {
                IPAddress newAddress;
                try
                {
                    var unicastAddresses = await IPGlobalProperties.GetIPGlobalProperties().GetUnicastAddressesAsync();
                    newAddress = unicastAddresses.Select(i => i.Address).FirstOrDefault(ip => ip.IsIPv6Teredo);
                }
                catch (Exception)
                {
                    await Task.Delay(TimeSpan.FromMinutes(1));
                    continue;
                }
                if (newAddress != null && !newAddress.Equals(s_lastIp))
                {
                    try
                    {
                        var dnsPodClient = HttpApiClient.Create<IDnsPodClient>();
                        var recordList = await dnsPodClient.GetRecordListAsync(token, regist, subDomain);
                        var record = recordList.Records.First();
                        var setResponse = await dnsPodClient.ModifyRecordAsync(token, regist, subDomain, record.Id, newAddress.ToString(), record.LineId);
                        if (setResponse.Status.Code != 1)
                        {
                            await Task.Delay(TimeSpan.FromSeconds(10));
                            continue;
                        }

                        s_lastIp = newAddress;
                    }
                    catch (Exception)
                    {
                    }
                }
                await Task.Delay(60000);
            }
        }
    }
}
