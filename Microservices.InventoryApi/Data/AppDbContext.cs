using Microservices.InventoryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace Microservices.InventoryApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Inventory>().HasKey(x => new { x.ProductId, x.RegionId });
        }

    }
}
