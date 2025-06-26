namespace Microservices.ProductApi.Model
{
    public class Product : BaseEntity
    {
        public long Id { get; set; }
        public string? Sku { get; set; }
        public string Slug { get; set; }
        public string? Name { get; set; }
        public decimal BasePrice { get; set; }
        public string? Description { get; set; }
        public string? MetaKeyword { get; set; }
        public string? MetaDescription { get; set; }
        public string? ImageUrl { get; set; }
        public decimal? Depth { get; set; } = 0;
        public decimal? Width { get; set; } = 0;
        public decimal? Height { get; set; } = 0;
        public decimal? NetWeightKg { get; set; } = 0;
        public decimal? GrossWeightKg { get; set; } = 0;
        public decimal? NetWeightLbs { get; set; } = 0;
        public decimal? GrossWeightLbs { get; set; } = 0;
        public int? MaxHeight { get; set; } = 0;
        public int QuantityMultiplier { get; set; } = 1;
        public double? CBM { get; set; } = 0;
        public int CollectionId { get; set; }
        public virtual Collection Collection { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public int TypeId { get; set; }
        public virtual TypeCategory TypeCategory { get; set; }
        public int LifeStyleId { get; set; }
        public virtual LifeStyle LifeStyle { get; set; }
        public int StyleId { get; set; }
        public virtual Style Style { get; set; }
        public virtual ICollection<ProductRegion> ProductRegions { get; set; }
        public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}
