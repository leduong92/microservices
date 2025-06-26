using Microservices.RegionApi.Data;
using Microservices.Shared;
using Microservices.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Microservices.RegionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : Controller
    {
        private readonly AppDbContext _context;

        public RegionController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ApiResponse<List<RegionDto>>> GetAllAsync()
        {
            var response = await _context.Regions.Select(x => new RegionDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Currency = x.Currency,
                Description = x.Description
            }).ToListAsync();

            return ApiResponse<List<RegionDto>>.Success(response);
        }
    }
}
