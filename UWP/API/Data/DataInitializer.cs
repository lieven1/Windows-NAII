using API.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DataInitializer(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                List<Reis> reizen = new List<Reis>();
                reizen.Add(new Reis { Naam = "Barcelona" });

                foreach(Reis reis in reizen) {
                    _context.Reizen.Add(reis);
                }
                _context.SaveChanges();

                List<Verplaatsing> verplaatsingen = new List<Verplaatsing>();
                verplaatsingen.Add(new Verplaatsing()
                {
                    ReisId = 1,
                    VertrekPlaats = "Gent",
                    Bestemming = "Barcelona",
                    VertrekTijd = new DateTime(2021, 2, 15, 12, 30, 0),
                    AankomstTijd = new DateTime(2020, 2, 15, 15, 0, 0)
                });
                verplaatsingen.Add(new Verplaatsing()
                {
                    ReisId = 1,
                    VertrekPlaats = "Barcelona",
                    Bestemming = "Gent",
                    VertrekTijd = new DateTime(2020, 12, 20, 16, 30, 0),
                    AankomstTijd = new DateTime(2020, 12, 20, 18, 0, 0)
                });

                foreach (Verplaatsing v in verplaatsingen)
                {
                    _context.Verplaatsingen.Add(v);
                }
                _context.SaveChanges();

                await InitializeUsers();
            }
        }

        private async Task InitializeUsers()
        {
            IdentityUser user = new IdentityUser { UserName = "tom.cruise@hotmail.com", Email = "tom.cruise@hotmail.com" };
            await _userManager.CreateAsync(user, "P@ssword1");
            //await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "gebruiker"));
        }
    }
}
