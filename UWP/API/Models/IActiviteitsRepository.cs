using System.Collections.Generic;

namespace API.Models
{
    public interface IActiviteitsRepository
    {
        IEnumerable<Activiteit> GetActiviteiten();
        Activiteit GetActiviteitById(int id);
        void Add(Activiteit activiteit);
        void Update(Activiteit activiteit);
        void Delete(Activiteit activiteit);
        void SaveChanges();
    }
}
