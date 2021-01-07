using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Mappers
{
    public class ReisConfiguration : IEntityTypeConfiguration<Reis>
    {
        public void Configure(EntityTypeBuilder<Reis> builder)
        {
            builder.ToTable("Reis");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Naam).HasMaxLength(100).IsRequired();
        }
    }
}
