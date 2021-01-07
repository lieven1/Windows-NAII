using API.Data.Mappers;
using API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class ApplicationDbContext : IdentityDbContext
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
        public DbSet<Activiteit> Activiteiten { get; set; }
        public DbSet<Checklist> Checklisten { get; set; }
        public DbSet<CheckListItem> CheckListItems { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<CategorieItem> CategorieItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ReisConfiguration());
            modelBuilder.ApplyConfiguration(new VerplaatsingConfiguration());
            modelBuilder.ApplyConfiguration(new ChecklistConfiguration());
            modelBuilder.ApplyConfiguration(new ChecklistItemConfiguration());
            modelBuilder.ApplyConfiguration(new CategorieConfiguration());
            modelBuilder.ApplyConfiguration(new CategorieItemConfiguration());
            modelBuilder.ApplyConfiguration(new ActiviteitConfiguration());
        }
    }
}
