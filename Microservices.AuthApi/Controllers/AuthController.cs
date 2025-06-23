using Azure;
using Microservices.AuthApi.Services.IService;
using Microservices.Shared;
using Microservices.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Microservices.AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService
            , IConfiguration configuration
            )
        {
            _authService = authService;
            _configuration = configuration;
        }
        [HttpGet("region")]
        public async Task<IActionResult> GetRegionsAsync()
        {
            var response = await _authService.GetRegionsAsync();
            return Ok(response);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterationRequestDto model)
        {
            var response = await _authService.Register(model);
            if (!response.IsSuccess)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var response = await _authService.Login(model);
            if (response.Data == null)
            {
                return BadRequest();
            }
            return Ok(response);

        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegisterationRequestDto model)
        {
            var response = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            if (!response.IsSuccess)
            {
                return BadRequest();
            }
            return Ok(response);

        }
    }
}
