using MindfulGift.API.Models;

namespace MindfulGift.API.BusinessLogic.Auth
{
    public interface IAuthService
    {
        public Task<AuthResponse> SendMagicLink(string email);
        public Task<AuthResponse> AuthenticateMagicLink(string token);
        public Task<StytchUserRespone> VerifySession(string sessionToken);


    }
}
