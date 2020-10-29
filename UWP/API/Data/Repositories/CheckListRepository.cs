using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Repositories
{
    public class CheckListRepository : ICheckListRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Checklist> _checkListen;
        public CheckListRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _checkListen = _dbContext.Checklisten;
        }
        public void Add(Checklist checklist)
        {
            _checkListen.Add(checklist);
        }

        public void Delete(Checklist checklist)
        {
            _checkListen.Remove(checklist);
        }

        public Checklist GetChecklistById(int id)
        {
            return _checkListen.Where(r => r.Id == id).FirstOrDefault();

        }

        public IEnumerable<Checklist> GetChecklisten()
        {
            return _checkListen.ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Checklist checklist)
        {
            _checkListen.Update(checklist);
        }
    }
}
