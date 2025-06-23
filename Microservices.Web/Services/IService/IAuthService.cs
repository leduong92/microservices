using Microservices.Shared;
using Microservices.Shared.Dtos;

namespace Microservices.Web.Services.IService
{
    public interface IAuthService
    {
        Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ApiResponse<UserDto>> RegisterAsync(RegisterationRequestDto registrationRequestDto);
        Task<ApiResponse<List<RegionDto>>> GetRegionsAsync();
        Task<ApiResponse<string>> AssignRoleAsync(RegisterationRequestDto registrationRequestDto);
    }
}
