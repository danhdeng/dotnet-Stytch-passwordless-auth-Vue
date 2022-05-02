using MindfulGift.API.Models;

namespace MindfulGift.API.BusinessLogic.Auth
{
    public class StytchService : IAuthService
    {
        public Task<AuthResponse> SendMagicLink(string email) {
        }
        public Task<AuthResponse> AuthenticateMagicLink(string token){
        }
        public Task<StytchUserReposne> VerifySession(string sessionToken) { 
        }
    }
}
