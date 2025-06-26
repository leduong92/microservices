using Microservices.RegionApi.Model;
using Microsoft.EntityFrameworkCore;

namespace Microservices.RegionApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Region>().HasData(new Region { Id = 1, Code = "US", Name = "United States", Currency = "USD" });
            modelBuilder.Entity<Region>().HasData(new Region { Id = 2, Code = "SG", Name = "Singapore", Currency = "SGD" });
            modelBuilder.Entity<Region>().HasData(new Region { Id = 3, Code = "VN", Name = "Vietnamese", Currency = "VND" });
            modelBuilder.Entity<Region>().HasData(new Region { Id = 4, Code = "CN", Name = "Chinese", Currency = "CNY" });
        }
    }
}
