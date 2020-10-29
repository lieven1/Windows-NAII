using System;
using System.Collections.Generic;

namespace API.Models
{
    public class CheckListItem
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int Aantal { get; set; }
        public bool Checked { get; set; }
        public string Type { get; set; }

        public List<Categorie> Categories { get; set; }


    }
}