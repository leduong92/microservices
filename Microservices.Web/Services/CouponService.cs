using Microservices.Shared;
using Microservices.Shared.Dtos;
using Microservices.Web.Services.IService;

namespace Microservices.Web.Services
{
    public class CouponService : ICouponService
    {
        private readonly IBaseApiClient _baseApiClient;

        public CouponService(IBaseApiClient baseApiClient)
        {
            _baseApiClient = baseApiClient;
        }

		public async Task<ApiResponse<CouponDto>> CreateCouponsAsync(CouponDto couponDto)
		{
			return await _baseApiClient.SendAsync<CouponDto>(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = couponDto,
				Url = SD.CouponAPIBase + "/api/coupon"
			});
		}

		public async Task<ApiResponse<List<CouponDto>>> GetAllCouponsAsync()
        {
            return await _baseApiClient.SendAsync<List<CouponDto>>(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ApiResponse<CouponDto>> GetCouponAsync(string couponCode)
        {
            return await _baseApiClient.SendAsync<CouponDto>(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/GetByCode/" + couponCode
            });
        }
    }
}
