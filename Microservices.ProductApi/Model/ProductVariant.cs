namespace Microservices.ProductApi.Model
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public long ProductId { get; set; }
        public string? ColorName { get; set; }
        public string? HexCode { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }

    }
}
