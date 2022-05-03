using System.Text.Json.Serialization;

namespace MindfulGift.API.Models
{
    public class StytchEmail
    {
        [JsonPropertyName("email_id")]
        public string EmailId { get; set; } = "";

        [JsonPropertyName("email")]
        public string Email { get; set; } = "";

        [JsonPropertyName("verified")]
        public bool Verified { get; set; } = false;
    }
}