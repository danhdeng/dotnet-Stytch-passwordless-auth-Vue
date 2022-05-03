using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using MindfulGift.API.Config;
using MindfulGift.API.DataAccess;
using MindfulGift.API.Models;
using MindfulGift.API.Models.Session;
using MindfulGift.API.Models.Stytch.MagicLinks;
using MindfulGift.API.Models.Stytch.Users;
using System.Text.Json;

namespace MindfulGift.API.BusinessLogic.Auth
{
    public class StytchService : IAuthService
    {
        private readonly ILogger<StytchService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly MindfulGiftDbContext _db;
        private readonly StytchOptions _stythOptions;

        public StytchService(
            ILogger<StytchService> logger,
            IHttpClientFactory httpClientFactory,
            IOptions<StytchOptions> stytchOptions,
            MindfulGiftDbContext db) {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _db = db;
            _stythOptions = stytchOptions.Value;
            
        }

        /// <summary>
        /// Send a Magic Link to the given eamil address
        /// </summary>
        /// <param name="email">the email provided to receive Magic Link</param>
        /// <returns></returns>
        public async Task<AuthResponse> SendMagicLink(string email) {
            _logger.LogInformation("Sending magic link for email:{Email}", email);
            var httpClient=_httpClientFactory.CreateClient();
            var payload = new StytchMagicLinkRequest
            {
                Email = email,
                LoginMagicLinkUrl = _stythOptions.LoginMagicLinkUrl,
                SignUpMagicLinkUrl = _stythOptions.SignUpMagicLinkUrl,
            };
            var options = new JsonSerializerOptions();
            var serializePayload=JsonSerializer.Serialize(payload, options);

            try
            {
                var basicAuthHeaderValue = BuildEncodedAuthString();
                var request = new HttpRequestMessage(HttpMethod.Post, _stythOptions.LoginOrCreateUrl)
                {
                    Headers = {
                        { HeaderNames.Accept, "application/json" },
                        { HeaderNames.Authorization, basicAuthHeaderValue }
                    },
                    Content = new StringContent(serializePayload)
                };
                var httpResponseMessage=await httpClient.SendAsync(request);

                var userLoginResponse = await httpResponseMessage.Content.ReadFromJsonAsync<StytchMagicLinkAuthReponse>();

                if (httpResponseMessage.IsSuccessStatusCode && userLoginResponse != null) {
                    _logger.LogInformation("Successful magic link generation");

                    var user = await _db.AppUsers.FirstOrDefaultAsync(u => u.StytchUserId == userLoginResponse.UserId);

                    if (userLoginResponse.UserCreated || user == null) {
                        user = new AppUser
                        {
                            EmailId = userLoginResponse.EmailId,
                            StytchUserId = userLoginResponse.UserId,
                        };
                        _db.Add(user);
                        await _db.SaveChangesAsync();
                     }
                    return new AuthResponse
                    {
                        IsSuccess = true,
                        UserId = user.StytchUserId
                    };
                }
                _logger.LogError("Error generating magic link");
                return new AuthResponse { IsSuccess = false, UserId="" };
            }
            catch (Exception)
            {
                _logger.LogError("Error while requesting magic token email");
                return new AuthResponse { IsSuccess = false, UserId = "" };
            }
        }

        

        /// <summary>
        /// authenticates a Magic Link with given token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<AuthResponse> AuthenticateMagicLink(string token){
            _logger.LogInformation("Authenticating Token: {Token}", token);
            var httpClient=_httpClientFactory.CreateClient();
            var payload = new StytchMagicLinkAuthRequest
            {
                Token = token,
                SessionDurationMinutes = _stythOptions.SessionDurationMinutes,
            };
            var options = new JsonSerializerOptions();
            var serializePayload = JsonSerializer.Serialize(payload, options);
            try
            {
                return await MakeAuthRequest(_stythOptions.AuthenticateMagicLinkUrl, serializePayload, httpClient);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while requesting magic token email", ex);
                return new AuthResponse { IsSuccess = false, UserId = "" };
            }

        }

       

        /// <summary>
        /// verfiy the provide token 
        /// </summary>
        /// <param name="sessionToken"></param>
        /// <returns></returns>
        public async Task<StytchUserRespone> VerifySession(string sessionToken) {
            _logger.LogInformation("Authenticating Session Token:{token}", sessionToken);
            var httpClient = _httpClientFactory.CreateClient();
            var payload = new StytchSessionRequest
            {
               SessionToken=sessionToken
            };
            var options = new JsonSerializerOptions();
            var serializePayload = JsonSerializer.Serialize(payload, options);
            try
            {
                var authResult= await MakeAuthRequest(_stythOptions.AuthenticateSessionUrl, serializePayload, httpClient);
                if (authResult.IsSuccess) {
                    return await GetStytchUser(authResult.UserId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while verifying the session token for magic link", ex);
                return new StytchUserRespone {};
            }
            return new StytchUserRespone { };

        }

        private async Task<StytchUserRespone> GetStytchUser(string userId)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var basicAuthHeaderValue = BuildEncodedAuthString();
            var userEndpoint = $"{_stythOptions.UserEndpoint}/{userId}";
            var request=new HttpRequestMessage(HttpMethod.Get, userEndpoint) {
                Headers = {
                    {HeaderNames.Accept, "application/json"},
                    { HeaderNames.Authorization, basicAuthHeaderValue}
                },
            };
            var httpResponseMessage=await httpClient.SendAsync(request);
            var contents = await httpResponseMessage.Content.ReadFromJsonAsync<StytchUserRespone>();
            if (httpResponseMessage.IsSuccessStatusCode && contents != null) {
                _logger.LogInformation("Successful user authentication");
                return contents;
            }
            _logger.LogError("Error Authenitcating User");
            return new StytchUserRespone();
        }

        private string BuildEncodedAuthString()
        {
            var authString = $"{_stythOptions.PID}:{_stythOptions.Secret}";
            var base64EncodedAuthenticationString=
                Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(authString));

            var basicAuthHeaderValue = $"Basic {base64EncodedAuthenticationString}";

            return basicAuthHeaderValue;
        }

        private async Task<AuthResponse> MakeAuthRequest(string authenticateMagicLinkUrl, string serializePayload, HttpClient httpClient)
        {
            var basicAuthHeaderValue = BuildEncodedAuthString();
            var request = new HttpRequestMessage(HttpMethod.Post, _stythOptions.LoginOrCreateUrl)
            {
                Headers = {
                        { HeaderNames.Accept, "application/json" },
                        { HeaderNames.Authorization, basicAuthHeaderValue }
                    },
                Content = new StringContent(serializePayload)
            };
            var httpResponseMessage = await httpClient.SendAsync(request);

            var reponse = await httpResponseMessage.Content.ReadFromJsonAsync<StytchAuthenticationResponse>();
            if (httpResponseMessage.IsSuccessStatusCode && reponse != null) { 
                _logger.LogInformation("Successful User Authentication");
                return new AuthResponse {
                    IsSuccess = true,
                    StatusCode = reponse.StatusCode,
                    SessionToken=reponse.SessionToken,
                    UserId=reponse.Session.UserId,
                    LastLogin=reponse.Session.LastAccessedAt
                };
            }

            _logger.LogError("Error Authenticating user");

            return new AuthResponse
            {
                IsSuccess = false
            };
        }
    }
}
