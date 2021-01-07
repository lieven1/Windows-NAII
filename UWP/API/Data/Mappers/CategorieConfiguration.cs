using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Mappers
{
    public class CategorieConfiguration : IEntityTypeConfiguration<Categorie>
    {
        public void Configure(EntityTypeBuilder<Categorie> builder)
        {
            builder.ToTable("Categorie");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Naam).HasMaxLength(100).IsRequired();

            builder.HasMany(t => t.Items).WithOne(t => t.Categorie);
        }
    }
}
