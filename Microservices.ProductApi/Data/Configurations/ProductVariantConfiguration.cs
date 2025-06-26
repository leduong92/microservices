using Microservices.ProductApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Microservices.ProductApi.Data.Configurations
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.ToTable("ProductVariants");
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ColorName).HasMaxLength(128);
            builder.Property(x => x.HexCode).HasMaxLength(32);
            builder.Property(x => x.ImageUrl).HasMaxLength(2048);
            builder.Property(x => x.Price).HasDefaultValue(0).HasColumnType("decimal(18,4)");

            builder.HasOne(v => v.Product).WithMany(p => p.ProductVariants).HasForeignKey(v => v.ProductId);

        }
    }
}
