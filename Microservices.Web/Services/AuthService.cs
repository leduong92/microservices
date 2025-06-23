using Microservices.Shared;
using Microservices.Shared.Dtos;
using Microservices.Web.Services.IService;

namespace Microservices.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly IBaseApiClient _baseService;
        public AuthService(IBaseApiClient baseService)
        {
            _baseService = baseService;
        }

        public async Task<ApiResponse<string>> AssignRoleAsync(RegisterationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync<string>(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/AssignRole"
            });
        }

        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendAsync<LoginResponseDto>(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/login"
            }, withBearer: false);
        }

        public async Task<ApiResponse<UserDto>> RegisterAsync(RegisterationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync<UserDto>(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/register"
            }, withBearer: false);
        }
    }
}
