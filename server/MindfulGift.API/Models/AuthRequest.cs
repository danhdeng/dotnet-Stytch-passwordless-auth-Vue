using System.Text.Json.Serialization;

namespace MindfulGift.API.Models
{
    public class AuthRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = "";
    }
}
