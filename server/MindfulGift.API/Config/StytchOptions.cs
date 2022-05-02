namespace MindfulGift.API.Config
{
    public class StytchOptions
    {
        public string Env { get; set; } = "";

        public string PID { get; set; } = "";

        public String Secret { get; set; }

        public int SessionDurationMinutes { get; set; }

        public string AuthenticateSessionUrl { get; set; } = "";

        public string AuthenticateMagicLinkUrl { get; set; } = "";
        public string LoginOrCreateUrl { get; set; }

        public  string UserEndpoint { get; set; }

        public String LoginMagicLinkUrl { get; set; }

        public string SignUpMagicLinkUrl { get; set; }
    }
}
