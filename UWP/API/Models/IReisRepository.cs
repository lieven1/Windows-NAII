using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public interface IReisRepository
    {
        IEnumerable<Reis> GetReizen();
        Reis GetReisById(int id);
        void Add(Reis reis);
        void Update(Reis reis);
        void Delete(Reis reis);
        void SaveChanges();
    }
}
