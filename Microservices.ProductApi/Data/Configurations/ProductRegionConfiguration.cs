using Microservices.ProductApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Microservices.ProductApi.Data.Configurations
{
    public class ProductRegionConfiguration : IEntityTypeConfiguration<ProductRegion>
    {
        public void Configure(EntityTypeBuilder<ProductRegion> builder)
        {
            builder.ToTable("ProductRegions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasIndex(pr => new { pr.ProductId, pr.RegionId }).IsUnique();
            builder.HasOne(pr => pr.Product).WithMany(p => p.ProductRegions).HasForeignKey(p => p.ProductId);
        }
    }
}
