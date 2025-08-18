using App.Core.Models;
using App.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                //.HasMaxLength(Category.MAX_TITLE_LENGTH)
                .IsRequired();

            builder.Property(x => x.Description)
                //.HasMaxLength(Category.MAX_DESCRIPTION_LENGTH)
                ;
        }
    }
}
