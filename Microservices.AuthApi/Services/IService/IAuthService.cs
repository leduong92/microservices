using Microservices.Shared;
using Microservices.Shared.Dtos;

namespace Microservices.AuthApi.Services.IService
{
    public interface IAuthService
    {
        Task<ApiResponse<UserDto>> Register(RegisterationRequestDto registrationRequestDto);
        Task<ApiResponse<LoginResponseDto>> Login(LoginRequestDto loginRequestDto);
        Task<ApiResponse<bool>> AssignRole(string email, string roleName);
    }
}
