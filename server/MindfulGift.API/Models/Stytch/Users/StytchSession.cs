using System.Text.Json.Serialization;

namespace MindfulGift.API.Models.Stytch.Users
{
    public class StytchSession
    {
        [JsonPropertyName("attributes")]
        public StytchSessionAttributes Attributes { get; set; }=new StytchSessionAttributes();

        [JsonPropertyName("user_id")]
        public string UserId { get; set; } = "";

        [JsonPropertyName("expires_at")]
        public DateTime ExpiresAt { get; set; }

        [JsonPropertyName("last_accessed_at")]
        public DateTime LastAccessedAt { get; set; }

        [JsonPropertyName("session_id")]
        public string SessionId { get; set; } = "";

        [JsonPropertyName("stated_at")]
        public DateTime StartedAt { get; set; }
    }
}