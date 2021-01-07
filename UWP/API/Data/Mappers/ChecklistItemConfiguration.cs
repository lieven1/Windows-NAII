using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Mappers
{
    public class ChecklistItemConfiguration : IEntityTypeConfiguration<CheckListItem>
    {
        public void Configure(EntityTypeBuilder<CheckListItem> builder)
        {
            builder.ToTable("ChecklistItem");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Naam).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Aantal).IsRequired();
            builder.Property(t => t.Checked).IsRequired();
            builder.Property(t => t.Type);

            builder.HasMany(t => t.Categories).WithOne(t => t.Item);
        }
    }
}
