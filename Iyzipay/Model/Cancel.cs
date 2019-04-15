using Iyzipay.Request;
using System;

namespace Iyzipay.Model
{
    public class Cancel : IyzipayResource
    {
        public string PaymentId { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }
        public string ConnectorName { get; set; }

        public static Cancel Create(CreateCancelRequest request, Options options)
        {
            return RestHttpClient.Create().Post<Cancel>(options.BaseUrl + "/payment/cancel", GetHttpHeaders(request, options), request);
        }
    }
}
