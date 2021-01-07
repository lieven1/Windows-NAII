using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Activiteit
    {
        public int Id { get; set; }
        public string Beschrijving { get; set; }
        public DateTime StartTijd { get; set; }
        public DateTime EindTijd { get; set; }

    }
}
