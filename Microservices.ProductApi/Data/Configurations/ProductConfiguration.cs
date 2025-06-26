using Microservices.ProductApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Microservices.ProductApi.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.BasePrice).HasDefaultValue(0).HasColumnType("decimal(18,4)");
            builder.Property(x => x.Name).HasMaxLength(64);
            builder.Property(x => x.Sku).HasMaxLength(32);
            builder.Property(x => x.Slug).HasMaxLength(128);
            builder.Property(x => x.ImageUrl).HasMaxLength(2048);
            builder.Property(x => x.Description);
            builder.Property(x => x.MetaKeyword).HasMaxLength(256);
            builder.Property(x => x.MetaDescription);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreatedBy).HasMaxLength(128);
            builder.Property(x => x.UpdatedBy).HasMaxLength(128);
            builder.Property(x => x.Depth).HasDefaultValue(0).HasColumnType("decimal(18,4)");
            builder.Property(x => x.Width).HasDefaultValue(0).HasColumnType("decimal(18,4)");
            builder.Property(x => x.Height).HasDefaultValue(0).HasColumnType("decimal(18,4)");
            builder.Property(x => x.NetWeightKg).HasDefaultValue(0).HasColumnType("decimal(18,4)");
            builder.Property(x => x.GrossWeightKg).HasDefaultValue(0).HasColumnType("decimal(18,4)");
            builder.Property(x => x.NetWeightLbs).HasDefaultValue(0).HasColumnType("decimal(18,4)");
            builder.Property(x => x.GrossWeightLbs).HasDefaultValue(0).HasColumnType("decimal(18,4)");
            builder.Property(x => x.QuantityMultiplier).HasDefaultValue(1);
            builder.Property(x => x.CBM).HasDefaultValue(0);

            builder.HasOne(p => p.TypeCategory)
                    .WithMany()
                    .HasForeignKey(p => p.TypeId)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
