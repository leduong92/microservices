using Microservices.LocalizationApi.Data;
using Microservices.Shared;
using Microservices.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Microservices.LocalizationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizationController : Controller
    {
        private readonly AppDbContext _context;

        public LocalizationController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ApiResponse<List<LanguageDto>>> GetAllAsync()
        {
            var response = await _context.Languages.Select(x => new LanguageDto
            {
                Id = x.Id,
                Name = x.Name, 
                Code = x.Code,
            }).ToListAsync();

            return ApiResponse<List<LanguageDto>>.Success(response);
        }
    }
}
