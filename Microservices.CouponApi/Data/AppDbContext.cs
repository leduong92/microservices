using Microservices.CouponApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Microservices.CouponApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.Entity<Coupon>().HasData(new Coupon
            //{
            //    Id = 1,
            //    CouponCode = "10OFF",
            //    DiscountAmount = 10,
            //    MinAmount = 20
            //});


            //modelBuilder.Entity<Coupon>().HasData(new Coupon
            //{
            //    Id = 2,
            //    CouponCode = "20OFF",
            //    DiscountAmount = 20,
            //    MinAmount = 40
            //});
        }
    }
}
