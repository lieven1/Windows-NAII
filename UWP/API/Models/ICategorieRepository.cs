using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public interface ICategorieRepository
    {
        IEnumerable<Categorie> GetCategories();
        Categorie GetCategorieById(int id);
        void Add(Categorie categorie);
        void Update(Categorie categorie);
        void Delete(Categorie categorie);
        void SaveChanges();
    }
}
