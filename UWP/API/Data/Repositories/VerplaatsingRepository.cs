using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Repositories
{
    public class VerplaatsingRepository : IVerplaatsingRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Verplaatsing> _verplaatsingen;
        public VerplaatsingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _verplaatsingen = _dbContext.Verplaatsingen;
        }
        public void Add(Verplaatsing verplaatsing)
        {
            _verplaatsingen.Add(verplaatsing);
        }

        public void Delete(Verplaatsing verplaatsing)
        {
            _verplaatsingen.Remove(verplaatsing);
        }

        public Verplaatsing GetVerplaatsingById(int id)
        {
            return _verplaatsingen.Where(r => r.Id == id).FirstOrDefault();
        }

        public IEnumerable<Verplaatsing> GetVerplaatsingen()
        {
            return _verplaatsingen.ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Verplaatsing verplaatsing)
        {
            _verplaatsingen.Update(verplaatsing);
        }
    }
}
