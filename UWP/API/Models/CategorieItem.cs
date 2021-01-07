using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CategorieItem
    {
        public int Id { get; set; }
        public Categorie Categorie { get; set; }
        public CheckListItem Item { get; set; }

        public CategorieItem()
        {

        }
    }
}
