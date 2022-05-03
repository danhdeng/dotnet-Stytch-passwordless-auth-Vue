using System.Text.Json.Serialization;

namespace MindfulGift.API.Models.Stytch.MagicLinks
{
    public class StythMagicLinkRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("Login_magic_link_url")]
        public string LoginMagicLinkUrl { get; set; }

        [JsonPropertyName("Sign_up_magic_link_url")]
        public string SignUpMagicLinkUrl { get; set; }
    }
}
