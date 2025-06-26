using Microservices.ProductApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Microservices.ProductApi.Data.Configurations
{
    public class StyleConfiguration : IEntityTypeConfiguration<Style>
    {
        public void Configure(EntityTypeBuilder<Style> builder)
        {
            builder.ToTable("Styles");
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Name).HasMaxLength(64);
            builder.Property(x => x.SortOrder).HasDefaultValue(0);
            builder.Property(x => x.Slug).HasMaxLength(128);
            builder.Property(x => x.ImageUrl).HasMaxLength(2048);
            builder.Property(x => x.Description).HasMaxLength(4000);
            builder.Property(x => x.MetaKeyword).HasMaxLength(256);
            builder.Property(x => x.MetaDescription).HasMaxLength(4000);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreatedBy).HasMaxLength(128);
            builder.Property(x => x.UpdatedBy).HasMaxLength(128);
        }
    }
}
