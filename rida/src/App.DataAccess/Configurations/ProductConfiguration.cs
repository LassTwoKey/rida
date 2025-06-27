using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Core.Models;
using App.DataAccess.Entites;

namespace App.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(Product.MAX_TITLE_LENGTH)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(Product.MAX_DESCRIPTION_LENGTH)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();
        }
    }
}
