using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using System.Diagnostics;

namespace Iyzipay.Samples
{
    public class Sample
    {
        protected Options options;

        [SetUp]
        public void Initialize()
        {
            options = new Options
            {
                ApiKey = "sandbox-ecTcpoxlOm4LIDZhSdzobE3Hv10qybBl",
                SecretKey = "sandbox-Ctiqcajui9wDi7YXDPLpAw3S72A0iZYe",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };
        }

        protected void PrintResponse<T>(T resource)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("Trace.log"));
            Trace.WriteLine(JsonConvert.SerializeObject(resource, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }));
        }
    }
}
