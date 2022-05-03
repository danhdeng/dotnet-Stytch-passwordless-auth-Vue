namespace MindfulGift.API.Models
{
    public class AuthResponse
    {
        public bool IsSuccess { get; set; }

        public int StatusCode { get; set; }

        public string SessionToken { get; set; }

        public string UserId { get; set; }

        public DateTime LastLogin { get; set; }
    }
}
