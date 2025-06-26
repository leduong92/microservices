using Microservices.Shared;
using Microservices.Shared.Dtos;

namespace Microservices.Web.Services.IService
{
    public interface ILocalizationService
    {
        Task<ApiResponse<List<LanguageDto>>> GetLocalizationsAsync();
    }
}
