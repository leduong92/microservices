using Microservices.AuthApi.Models;

namespace Microservices.AuthApi.Services.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
