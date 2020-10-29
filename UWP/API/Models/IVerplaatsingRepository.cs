using System.Collections.Generic;

namespace API.Models
{
    public interface IVerplaatsingRepository
    {
        IEnumerable<Verplaatsing> GetVerplaatsingen();
        Verplaatsing GetVerplaatsingById(int id);
        void Add(Verplaatsing verplaatsing);
        void Update(Verplaatsing verplaatsing);
        void Delete(Verplaatsing verplaatsing);
        void SaveChanges();
    }
}
