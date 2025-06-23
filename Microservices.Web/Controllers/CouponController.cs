using Microservices.Web.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _couponService.GetAllCouponsAsync();
            return View(response.Data);
        }
    }
}
