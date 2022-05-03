using System.Text.Json.Serialization;

namespace MindfulGift.API.Models.Stytch.MagicLinks
{
    public class StytchMagicLinkAuthRequest
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
        [JsonPropertyName("session_duration_minutes")]
        public int SessionDurationMinutes { get; set; }
    }
}
