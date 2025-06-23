using Microservices.CouponApi.Data;
using Microservices.Shared;
using Microservices.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Microservices.CouponApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : Controller
    {
        private readonly AppDbContext _context;

        public CouponController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ApiResponse<List<CouponDto>>> Get()
        {
            var results = await _context.Coupons.Select(x => new CouponDto
            {
                Id = x.Id,
                CouponCode = x.CouponCode,
                DiscountAmount = x.DiscountAmount,
                MinAmount = x.MinAmount
            }).ToListAsync();

            return ApiResponse<List<CouponDto>>.Success(results);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ApiResponse<CouponDto>> Get(int id)
        {
            var results = await _context.Coupons.Where(x => x.Id == id).Select(x => new CouponDto
            {
                Id = x.Id,
                CouponCode = x.CouponCode,
                DiscountAmount = x.DiscountAmount,
                MinAmount = x.MinAmount
            }).FirstOrDefaultAsync();

            return ApiResponse<CouponDto>.Success(results);
        }
        [HttpGet]
        [Route("GetByCode/{code}")]
        public async Task<ApiResponse<CouponDto>> GetByCode(string code)
        {
            var results = await _context.Coupons.Where(x => x.CouponCode.ToLower() == code.ToLower()).Select(x => new CouponDto
            {
                Id = x.Id,
                CouponCode = x.CouponCode,
                DiscountAmount = x.DiscountAmount,
                MinAmount = x.MinAmount
            }).FirstOrDefaultAsync();

            return ApiResponse<CouponDto>.Success(results);
        }


    }
}
