using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Mappers
{
    public class ChecklistConfiguration : IEntityTypeConfiguration<Checklist>
    {
        public void Configure(EntityTypeBuilder<Checklist> builder)
        {
            builder.ToTable("Checklist");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Naam).HasMaxLength(100).IsRequired();

            builder.HasMany(t => t.Items).WithOne().IsRequired();
        }
    }
}
