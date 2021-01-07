using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Mappers
{
    public class VerplaatsingConfiguration : IEntityTypeConfiguration<Verplaatsing>
    {
        public void Configure(EntityTypeBuilder<Verplaatsing> builder)
        {
            builder.ToTable("Verplaatsing");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.VertrekPlaats).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Bestemming).HasMaxLength(100).IsRequired();
            builder.Property(t => t.VertrekTijd).IsRequired();
            builder.Property(t => t.AankomstTijd).IsRequired();

            builder.HasOne(t => t.Reis).WithMany(t => t.Verplaatsingen).HasForeignKey(t => t.ReisId).IsRequired();
        }
    }
}
