using System.Text.Json.Serialization;

namespace MindfulGift.API.Models.Stytch.Users
{
    public class StytchAuthenticationRequest
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = "";
    }
}
