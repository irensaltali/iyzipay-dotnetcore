using System;

namespace Iyzipay.Request
{
    public class RetrieveCardListRequest : BaseRequest
    {
        public string CardUserKey { get; set; }

        public override string ToPKIRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPKIRequestString())
                .Append("cardUserKey", CardUserKey)
                .GetRequestString();
        }
    }
}
