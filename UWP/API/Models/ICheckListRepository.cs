using System.Collections.Generic;

namespace API.Models
{
    public interface ICheckListRepository
    {
        IEnumerable<Checklist> GetChecklisten();
        Checklist GetChecklistById(int id);
        void Add(Checklist checklist);
        void Update(Checklist checklist);
        void Delete(Checklist checklist);
        void SaveChanges();
    }
}
