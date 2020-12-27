using System.Collections.Generic;

namespace API.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public List<CategorieItem> Items { get; set; }
    }
}