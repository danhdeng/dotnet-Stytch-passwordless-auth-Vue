using System.Text.Json.Serialization;

namespace MindfulGift.API.Models.Stytch.MagicLinks
{
    public class StytchMagicLinkAuthReponse
    {
        [JsonPropertyName("email_id")]
        public string EmailId { get; set; }

        [JsonPropertyName("request_id")]
        public string RequestId { get; set; }

        [JsonPropertyName("status_code")]
        public string StatusCode { get; set; }

        [JsonPropertyName("user_created")]
        public bool UserCreated { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
