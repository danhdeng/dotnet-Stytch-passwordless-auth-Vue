using System.Text.Json.Serialization;

namespace MindfulGift.API.Models.Stytch.Users
{
    public class StytchAuthenticationResponse
    {
        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }

        [JsonPropertyName("request_id")]
        public string RequestId { get; set; } = "";

        [JsonPropertyName("session")]
        public StytchSession Session { get; set; } = new StytchSession();

        [JsonPropertyName("authentication_factors")]
        public List<StytchAuthenticationFactor> AuthenticationFactors{ get; set; } = new List<StytchAuthenticationFactor>();

        [JsonPropertyName("session_jwt")]
        public string SessionJwt { get; set; } = "";

        [JsonPropertyName("session_token")]
        public string SessionToken { get; set; }
    }
}
