using System.Text.Json.Serialization;

namespace MindfulGift.API.Models.Stytch.Users
{
    public class StytchAuthenticationFactor
    {
        [JsonPropertyName("delivery_method")]
        public string DeliveryMethod { get; set; } = ""; 

        [JsonPropertyName("email_factor")]
        public StytchEmailFactor EmailFactor { get; set; }
        [JsonPropertyName("last_accessed_at")]
        public DateTime lastAccessedAt { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; } = "";
    }
}