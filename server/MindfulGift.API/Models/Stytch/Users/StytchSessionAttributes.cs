using System.Text.Json.Serialization;

namespace MindfulGift.API.Models.Stytch.Users
{
    public class StytchSessionAttributes
    {
        [JsonPropertyName("ip_address")]
        public string IpAddress { get; set; } = "";

        [JsonPropertyName("user_agent")]
        public string UserAgent { get; set; } = "";
    }
}