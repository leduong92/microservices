using Microservices.AuthApi.Data;
using Microservices.AuthApi.Models;
using Microservices.AuthApi.Services.IService;
using Microservices.Shared;
using Microservices.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microservices.AuthApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(AppDbContext context
            , UserManager<ApplicationUser> userManager
            , RoleManager<IdentityRole> roleManager
            , IJwtTokenGenerator jwtTokenGenerator
            )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<ApiResponse<bool>> AssignRole(string email, string roleName)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user, roleName);
                return ApiResponse<bool>.Success(true);
            }
            return ApiResponse<bool>.Failure("AssignRole fail");
        }

        public async Task<ApiResponse<List<RegionDto>>> GetRegionsAsync()
        {
            var response = await _context.Regions.AsNoTracking().Select(x => new RegionDto
             {
                 Id = x.Id,
                 Name = x.Name,
                 Code = x.Code,
                 Description = x.Description
             }).ToListAsync();
            return ApiResponse<List<RegionDto>>.Success(response);
        }

        public async Task<ApiResponse<LoginResponseDto>> Login(LoginRequestDto loginRequestDto)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null || isValid == false)
            {
                return ApiResponse<LoginResponseDto>.Failure("User not found");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user, roles);

            UserDto userDTO = new()
            {
                Email = user.Email,
                ID = user.Id,
                Name = user.DisplayName,
                PhoneNumber = user.PhoneNumber,
                RegionId = user.RegionId
            };

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDTO,
                Token = token
            };

            return ApiResponse<LoginResponseDto>.Success(loginResponseDto);
        }

        public async Task<ApiResponse<UserDto>> Register(RegisterationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                DisplayName = registrationRequestDto.Name,
                PhoneNumber = registrationRequestDto.PhoneNumber,
                RegionId = registrationRequestDto.RegionId
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _context.ApplicationUsers.First(u => u.UserName == registrationRequestDto.Email);

                    UserDto userDto = new()
                    {
                        Email = userToReturn.Email,
                        ID = userToReturn.Id,
                        Name = userToReturn.DisplayName,
                        PhoneNumber = userToReturn.PhoneNumber,
                        RegionId = userToReturn.RegionId
                    };

                    return ApiResponse<UserDto>.Success(userDto);

                }
                else
                {
                    return ApiResponse<UserDto>.Failure(result.Errors.FirstOrDefault().Description);
                }
            }
            catch (Exception ex)
            {
                return ApiResponse<UserDto>.Failure("Something went wrong");
            }
        }
    }
}
