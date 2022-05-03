using System.Text.Json.Serialization;

namespace MindfulGift.API.Models
{
    public class StytchUserRespone
    {
        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }

        [JsonPropertyName("request_id")]
        public string RequestId { get; set; } = "";

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("name")]
        public StytchName Name { get; set; } = new();

        [JsonPropertyName("emails")]
        public List<StytchEmail> Emails { get; set; }=new List<StytchEmail>();

        [JsonPropertyName("phone_numbers")]
        public List<StytchPhone> PhoneNumbers { get; set; } = new();
    }
}
