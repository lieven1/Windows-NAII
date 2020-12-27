using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Mappers
{
    public class ActiviteitConfiguration : IEntityTypeConfiguration<Activiteit>
    {
        public void Configure(EntityTypeBuilder<Activiteit> builder)
        {
            builder.ToTable("Activiteit");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Beschrijving).HasMaxLength(200);
            builder.Property(t => t.StartTijd);
            builder.Property(t => t.EindTijd);
        }
    }
}
