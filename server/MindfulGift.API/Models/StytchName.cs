using System.Text.Json.Serialization;

namespace MindfulGift.API.Models
{
    public class StytchName
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; } = "";

        [JsonPropertyName("middle_name")]
        public string MiddleName { get; set; } = "";

        [JsonPropertyName("last_name")]
        public string LastName { get; set; } = "";

    }
}