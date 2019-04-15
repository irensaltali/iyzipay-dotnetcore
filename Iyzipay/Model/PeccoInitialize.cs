using Iyzipay.Request;
using System;

namespace Iyzipay.Model
{
    public class PeccoInitialize : IyzipayResource
    {
        public string HtmlContent { get; set; }
        public string RedirectUrl { get; set; }
        public string Token { get; set; }
        public long? TokenExpireTime { get; set; }

        public static PeccoInitialize Create(CreatePeccoInitializeRequest request, Options options)
        {
            return RestHttpClient.Create().Post<PeccoInitialize>(options.BaseUrl + "/payment/pecco/initialize", GetHttpHeaders(request, options), request);
        }
    }
}
