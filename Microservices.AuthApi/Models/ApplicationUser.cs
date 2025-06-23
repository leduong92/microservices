using Microsoft.AspNetCore.Identity;

namespace Microservices.AuthApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? AccountNumber { get; set; }
        public string? DisplayName { get; set; }
    }
}
