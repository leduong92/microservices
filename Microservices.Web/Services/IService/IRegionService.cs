using Microservices.Shared;
using Microservices.Shared.Dtos;

namespace Microservices.Web.Services.IService
{
    public interface IRegionService
    {
        Task<ApiResponse<List<RegionDto>>> GetRegionsAsync();
    }
}
