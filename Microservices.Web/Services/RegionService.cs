using Microservices.Shared;
using Microservices.Shared.Dtos;
using Microservices.Web.Services.IService;

namespace Microservices.Web.Services
{
    public class RegionService : IRegionService
    {
        private readonly IBaseApiClient _baseApiClient;

        public RegionService(IBaseApiClient baseApiClient)
        {
            _baseApiClient = baseApiClient;
        }
		public async Task<ApiResponse<List<RegionDto>>> GetRegionsAsync()
        {
            return await _baseApiClient.SendAsync<List<RegionDto>>(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RegionAPIBase + "/api/region"
            });
        }
    }
}
