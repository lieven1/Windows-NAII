using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //necessary for supporting the Add-Migration command from Pack Man Console
            var connectionstring = @"Server=.;Database=WindowsAPI;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connectionstring);
        }

        public DbSet<Reis> Reizen { get; set; }
        public DbSet<Verplaatsing> Verplaatsingen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reis>().HasData(
                new Reis
                {
                    Id = 1,
                    Naam = "Barcelona"
                }
            );
            modelBuilder.Entity<Verplaatsing>().HasData(
                new Verplaatsing
                {
                    Id = 1,
                    ReisId = 1,
                    VertrekPlaats = "Gent",
                    Bestemming = "Barcelona",
                    VertrekTijd = new DateTime(2020, 12, 15, 12, 30, 0),
                    AankomstTijd = new DateTime(2020, 12, 15, 15, 0, 0)
                },
                new Verplaatsing
                {
                    Id = 2,
                    ReisId = 1,
                    VertrekPlaats = "Barcelona",
                    Bestemming = "Gent",
                    VertrekTijd = new DateTime(2020, 12, 20, 16, 30, 0),
                    AankomstTijd = new DateTime(2020, 12, 20, 18, 0, 0)
                }
            );
        }
    }
}
