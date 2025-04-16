using Mango.Services.AuthAPI.Models.Dto;

namespace Mango.Services.AuthAPI.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<string> Register(RegisterRequestDto registerRequestDto);
    }
}
