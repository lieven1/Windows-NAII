using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Categorie> _categories;

        public CategorieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _categories = dbContext.Categories;
        }

        public void Add(Categorie categorie)
        {
            _categories.Add(categorie);
        }

        public void Delete(Categorie categorie)
        {
            _categories.Remove(categorie);
        }

        public Categorie GetCategorieById(int id)
        {
            return _categories.Where(r => r.Id == id).FirstOrDefault();
        }

        public IEnumerable<Categorie> GetCategories()
        {
            return _categories.ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Categorie categorie)
        {
            _categories.Update(categorie);
        }
    }
}
