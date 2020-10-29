using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Repositories
{
    public class ActiviteitRepository: IActiviteitsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Activiteit> _activiteiten;

        public ActiviteitRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _activiteiten = dbContext.Activiteiten;
        }

        public void Add(Activiteit activiteit)
        {
            _activiteiten.Add(activiteit);
        }

        public void Delete(Activiteit activiteit)
        {
            _activiteiten.Remove(activiteit);
        }

        public Activiteit GetActiviteitById(int id)
        {
            return _activiteiten.Where(r => r.ActiviteitId == id).FirstOrDefault();
        }

        public IEnumerable<Activiteit> GetActiviteiten()
        {
            return _activiteiten.ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Activiteit activiteit)
        {
            _activiteiten.Update(activiteit);
        }
    }

}
