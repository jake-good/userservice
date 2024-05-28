using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;

namespace userservice
{
    public class Auth0Service
    {
        private readonly string _domain;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _audience;

        public Auth0Service(IConfiguration configuration)
        {
            _domain = configuration["Auth0:Domain"];
            _clientId = configuration["Auth0:ClientId"];
            _clientSecret = configuration["Auth0:ClientSecret"];
            _audience = configuration["Auth0:Audience"];
        }

        public async Task<string> GetAccessTokenAsync()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri($"https://{_domain}"));
            var tokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                Audience = _audience
            };

            var tokenResponse = await authenticationApiClient.GetTokenAsync(tokenRequest);
            return tokenResponse.AccessToken;
        }

        public async Task<ManagementApiClient> GetManagementApiClientAsync()
        {
            var token = await GetAccessTokenAsync();
            return new ManagementApiClient(token, new Uri($"https://{_domain}/api/v2"));
        }
    }
}