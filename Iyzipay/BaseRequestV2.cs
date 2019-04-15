using Newtonsoft.Json;

namespace Iyzipay
{
    public class BaseRequestV2
    {
        [JsonIgnore]
        public string ConversationId { get; set; }
    }
}
