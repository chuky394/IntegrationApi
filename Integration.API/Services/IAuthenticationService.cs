using Integration.API.Requests;
using Integration.API.Responses;
using System.Threading.Tasks;

namespace Integration.API.Services
{
    public interface IAuthenticationService
    {
        void SignIn();
        Task<TokenResponse> GetToken(string code, string state, string error);
        Task<TokenResponse> RefreshToken(RefreshTokenRequest refreshTokenRequest);
    }
}