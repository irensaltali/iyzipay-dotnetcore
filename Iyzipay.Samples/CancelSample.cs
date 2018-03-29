using Iyzipay.Request;
using Iyzipay.Model;
using NUnit.Framework;

namespace Iyzipay.Samples
{
    public class CancelSample : Sample
    {
        [Test]
        public void Should_Cancel_Payment()
        {
            CreateCancelRequest request = new CreateCancelRequest
            {
                ConversationId = "123456789",
                Locale = Locale.TR.ToString(),
                PaymentId = "1",
                Ip = "85.34.78.112"
            };

            Cancel cancel = Cancel.Create(request, options);

            PrintResponse(cancel);

            Assert.AreEqual(Status.SUCCESS.ToString(), cancel.Status);
            Assert.AreEqual(Locale.TR.ToString(), cancel.Locale);
            Assert.AreEqual("123456789", cancel.ConversationId);
            Assert.IsNotNull(cancel.SystemTime);
            Assert.IsNull(cancel.ErrorCode);
            Assert.IsNull(cancel.ErrorMessage);
            Assert.IsNull(cancel.ErrorGroup);
        }

        [Test]
        public void Should_Cancel_Payment_With_Reason_And_Description()
        {
            CreateCancelRequest request = new CreateCancelRequest
            {
                ConversationId = "123456789",
                Locale = Locale.TR.ToString(),
                PaymentId = "1",
                Ip = "85.34.78.112",
                Reason = RefundReason.OTHER.ToString(),
                Description = "customer requested for default sample"
            };

            Cancel cancel = Cancel.Create(request, options);

            PrintResponse<Cancel>(cancel);

            Assert.AreEqual(Status.SUCCESS.ToString(), cancel.Status);
            Assert.AreEqual(Locale.TR.ToString(), cancel.Locale);
            Assert.AreEqual("123456789", cancel.ConversationId);
            Assert.IsNotNull(cancel.SystemTime);
            Assert.IsNull(cancel.ErrorCode);
            Assert.IsNull(cancel.ErrorMessage);
            Assert.IsNull(cancel.ErrorGroup);
        }
    }
}
