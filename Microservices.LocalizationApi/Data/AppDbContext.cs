using Microservices.LocalizationApi.Model;
using Microsoft.EntityFrameworkCore;

namespace Microservices.LocalizationApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Language>().HasData(new Language { Id = 1, Code = "en", Name = "English" });
            modelBuilder.Entity<Language>().HasData(new Language { Id = 2, Code = "vn", Name = "Vietnamese" });
            modelBuilder.Entity<Language>().HasData(new Language { Id = 3, Code = "cn", Name = "Chinese" });
        }
    }
}
