using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Reis
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public List<Verplaatsing> Verplaatsingen { get; set; }
        public List<Activiteit> Activiteiten { get; set; }
        public List<Checklist> CheckListLijsten { get; set; }

        public Reis()
        {

        }
    }
}