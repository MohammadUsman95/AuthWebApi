using AuthWebApi.Entities;
using AuthWebApi.Model;

namespace AuthWebApi.Services
{
    public interface IAuthService
    {
        Task<TokenResponseDto?> LoginAsync(UserDto request);
        Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request); // same thing will implement in aiuthservice.cs
        Task<User?> RegisterAsync(UserDto request);
    }
}