using MindfulGift.API.Models;

namespace MindfulGift.API.BusinessLogic.Auth
{
    public class StytchService : IAuthService
    {
        public StytchService() { 
            
        }

        /// <summary>
        /// Send a Magic Link to the given eamil address
        /// </summary>
        /// <param name="email">the email provided to receive Magic Link</param>
        /// <returns></returns>
        public Task<AuthResponse> SendMagicLink(string email) {
        }

        /// <summary>
        /// authenticates a Magic Link with given token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<AuthResponse> AuthenticateMagicLink(string token){
        }

        /// <summary>
        /// verfiy the provide token 
        /// </summary>
        /// <param name="sessionToken"></param>
        /// <returns></returns>
        public Task<StytchUserReposne> VerifySession(string sessionToken) { 
        }
    }
}
