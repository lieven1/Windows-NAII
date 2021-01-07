using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Verplaatsing
    {
        public int Id { get; set; }
        public int ReisId { get; set; }
        public Reis Reis { get; set; }
        public string VertrekPlaats { get; set; }
        public string Bestemming { get; set; }
        public DateTime VertrekTijd { get; set; }
        public DateTime AankomstTijd { get; set; }

        public Verplaatsing()
        {

        }
    }
}
