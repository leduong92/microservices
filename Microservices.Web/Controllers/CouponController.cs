using Microservices.Shared.Dtos;
using Microservices.Web.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

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
            List<CouponDto>? list = new();
            var response = await _couponService.GetAllCouponsAsync();
            if (response != null && response.IsSuccess)
            {
                list = response.Data;
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(list);
        }

		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CouponDto model)
		{
			if (ModelState.IsValid)
			{
				var response = await _couponService.CreateCouponsAsync(model);

				if (response != null && response.IsSuccess)
				{
					TempData["success"] = "Coupon created successfully";
					return RedirectToAction(nameof(Index));
				}
				else
				{
					TempData["error"] = response?.Message;
				}
			}
			return View(model);
		}

	}
}
