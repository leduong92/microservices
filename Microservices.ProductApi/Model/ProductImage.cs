namespace Microservices.ProductApi.Model
{
    public class ProductImage
    {
        public long Id { get; set; }
        public int ProductVariantId { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
        public ProductVariant ProductVariant { get; set; }
    }
}
