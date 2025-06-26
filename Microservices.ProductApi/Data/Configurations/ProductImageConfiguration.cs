using Microservices.ProductApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Microservices.ProductApi.Data.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductVariants");
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ImageUrl).HasMaxLength(2048);
            builder.Property(x => x.IsPrimary).HasDefaultValue(false);

            builder.HasOne(i => i.ProductVariant).WithMany(v => v.ProductImages).HasForeignKey(i => i.ProductVariantId);
        }
    }
}
