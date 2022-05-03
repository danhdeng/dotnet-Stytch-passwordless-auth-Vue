using System.Text.Json.Serialization;

namespace MindfulGift.API.Models.Stytch.Users
{
    public class StytchEmailFactor
    {
        [JsonPropertyName("email_address")]
        public string EmailAddress { get; set; } = "";

        [JsonPropertyName("email_id")]
        public string EmailId { get; set; } = "";
    }
}