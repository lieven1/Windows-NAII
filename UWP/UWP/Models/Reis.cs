using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace UWP.Models
{
    public class Reis : INotifyPropertyChanged
    {
        private string _naam;
        
        public string Naam {
            get { return _naam; }
            set { _naam = value; RaisePropertyChanged("Naam"); }
        }
        public List<Verplaatsing> Verplaatsingen { get; set; }

        [JsonIgnore]
        public bool IsFake { get; set; }
        [JsonIgnore]
        public Color Color1 { get; set; }
        [JsonIgnore]
        public Color Color2 { get; set; }

        public Reis()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}