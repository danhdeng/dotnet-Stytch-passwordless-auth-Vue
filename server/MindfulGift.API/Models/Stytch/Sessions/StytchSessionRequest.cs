using System.Text.Json.Serialization;

namespace MindfulGift.API.Models.Session
{
    internal class StytchSessionRequest
    {
        [JsonPropertyName("session_token")]
        public string SessionToken { get; set; }
    }
}