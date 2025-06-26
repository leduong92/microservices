using Microservices.Shared;
using Microservices.Shared.Dtos;
using Microservices.Web.Services.IService;

namespace Microservices.Web.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IBaseApiClient _baseApiClient;

        public LocalizationService(IBaseApiClient baseApiClient)
        {
            _baseApiClient = baseApiClient;
        }
		public async Task<ApiResponse<List<LanguageDto>>> GetLocalizationsAsync()
        {
            return await _baseApiClient.SendAsync<List<LanguageDto>>(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.LocalizationAPIBase + "/api/localization"
            });
        }
    }
}
