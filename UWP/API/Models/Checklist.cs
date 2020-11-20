using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Checklist
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public List<CheckListItem> tems { get; set; }
    }
}
