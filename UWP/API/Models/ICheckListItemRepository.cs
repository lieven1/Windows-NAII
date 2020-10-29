using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
   public interface ICheckListItemRepository
    {
        IEnumerable<CheckListItem> GetCheckListItems();
        CheckListItem GetCheckListItemById(int id);
        void Add(CheckListItem checkListItem);
        void Update(CheckListItem checkListItem);
        void Delete(CheckListItem checkListItem);
        void SaveChanges();
    }
}
