using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Repositories
{
    public class CheckListItemRepository : ICheckListItemRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<CheckListItem> _checkListItems;

        public CheckListItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _checkListItems = dbContext.CheckListItems;
        }
        public void Add(CheckListItem checkListItem)
        {
            _checkListItems.Add(checkListItem);
        }

        public void Delete(CheckListItem checkListItem)
        {
            _checkListItems.Remove(checkListItem);
        }

        public CheckListItem GetCheckListItemById(int id)
        {
            return _checkListItems.Where(r => r.Id == id).FirstOrDefault();
        }

        public IEnumerable<CheckListItem> GetCheckListItems()
        {
            return _checkListItems.ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(CheckListItem checkListItem)
        {
            _checkListItems.Update(checkListItem);
        }
    }
}
