using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Repositories
{
    public class ReisRepository : IReisRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Reis> _reizen;

        public ReisRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _reizen = dbContext.Reizen;
        }

        public IEnumerable<Reis> GetReizen()
        {
            return _reizen.Include(r => r.Verplaatsingen);
        }

        public Reis GetReisById(int id)
        {
            return _reizen.Where(r => r.Id == id).FirstOrDefault();
        }

        public void Add(Reis reis)
        {
            _reizen.Add(reis);
        }

        public void Update(Reis reis)
        {
            _reizen.Update(reis);
        }

        public void Delete(Reis reis)
        {
            _reizen.Remove(reis);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        
    }
}
