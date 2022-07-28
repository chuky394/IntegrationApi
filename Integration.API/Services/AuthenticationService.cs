using Integration.API.Configuration;
using Integration.API.Requests;
using Integration.API.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Integration.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationOptions _applicationOptions;
        private readonly MicrosoftApiOptions _microsoftApiOptions;
        public AuthenticationService(HttpClient httpClient,
                                     ApplicationOptions applicationOptions,
                                     MicrosoftApiOptions microsoftApiOptions)
        {
            _httpClient = httpClient;
            _applicationOptions = applicationOptions;
            _microsoftApiOptions = microsoftApiOptions;
        }
        public void SignIn()
        {
            var url = $"{_microsoftApiOptions.TokenUrl}/authorize?" +
                       $"&client_id={_applicationOptions.ClientId}" +
                       "&response_type=code" +
                       $"&redirect_uri= {_microsoftApiOptions.RedirectUrl}" + 
                       "&response_mode=query" +
                       "&scope=Calendars.ReadWrite offline_access User.Read" +
                       "&state=12345";            
            
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = url;
            System.Diagnostics.Process.Start(psi);
        }

        public async Task<TokenResponse> GetToken(string code, string state, string error)
        {
            var url = $"{_microsoftApiOptions.TokenUrl}/token?";

            var message = new HttpRequestMessage(HttpMethod.Post, new Uri(url));

            message.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "client_id", _applicationOptions.ClientId },
                { "scope", "Calendars.ReadWrite offline_access User.Read" },
                { "code", code},
                { "redirect_uri", _microsoftApiOptions.RedirectUrl },
                { "grant_type", "authorization_code" },
                { "client_secret", _applicationOptions.ClientSecret },

            });

            HttpResponseMessage response;
            TokenResponse tokenRespone;
            try
            {
                response = await _httpClient.SendAsync(message);
                tokenRespone = JsonConvert.DeserializeObject<TokenResponse>(await response.Content?.ReadAsStringAsync());
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return tokenRespone;
        }

        public async Task<TokenResponse> RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            var url = $"{_microsoftApiOptions.TokenUrl}/token?";

            var message = new HttpRequestMessage(HttpMethod.Post, new Uri(url));

            message.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "client_id", _applicationOptions.ClientId },
                { "scope", "Calendars.ReadWrite offline_access User.Read"},                
                { "refresh_token", refreshTokenRequest.RefreshToken},
                { "grant_type", "refresh_token" },
                { "client_secret", _applicationOptions.ClientSecret},

            });

            HttpResponseMessage response;
            TokenResponse tokenRespone;
            try
            {
                response = await _httpClient.SendAsync(message);
                tokenRespone = JsonConvert.DeserializeObject<TokenResponse>(await response.Content?.ReadAsStringAsync());
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return tokenRespone;
        }
    }
}