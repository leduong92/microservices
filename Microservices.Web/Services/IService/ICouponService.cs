using Microservices.Shared;
using Microservices.Shared.Dtos;

namespace Microservices.Web.Services.IService
{
    public interface ICouponService
    {
        Task<ApiResponse<CouponDto>> GetCouponAsync(string couponCode);
        Task<ApiResponse<List<CouponDto>>> GetAllCouponsAsync();
    }
}
