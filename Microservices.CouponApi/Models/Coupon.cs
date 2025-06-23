namespace Microservices.CouponApi.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
