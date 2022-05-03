using System.Text.Json.Serialization;

namespace MindfulGift.API.Models
{
    public class StytchPhone
    {
        [JsonPropertyName("phone_id")]
        public string PhoneId { get; set; } = "";

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; } = "";

    }
}