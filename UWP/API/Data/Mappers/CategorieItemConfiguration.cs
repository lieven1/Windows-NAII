using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Mappers
{
    public class CategorieItemConfiguration : IEntityTypeConfiguration<CategorieItem>
    {
        public void Configure(EntityTypeBuilder<CategorieItem> builder)
        {
            builder.ToTable("CategorieItem");
            builder.HasKey(t => t.Id);
        }
    }
}
