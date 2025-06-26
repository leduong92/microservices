namespace Microservices.ProductApi.Model
{
    public class ProductRegion
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int RegionId { get; set; }
        public bool IsPublished { get; set; }
    }
}
