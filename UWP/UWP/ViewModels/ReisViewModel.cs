using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UWP.Models;

namespace UWP.ViewModels
{
    public class ReisViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Reis> Reizen { get; set; }
        public RelayCommand AddReisCommand { get; set; }

        public ReisViewModel()
        {
            Reizen = new ObservableCollection<Reis>();
            loadDataAsync();
            AddReisCommand = new RelayCommand(AddReis);
        }

        private async void loadDataAsync()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/reis"));
            var reislist = JsonConvert.DeserializeObject<IList<Reis>>(json);
            foreach (var reis in reislist)
            {
                Reizen.Add(reis);
            }
        }

        private void AddReis(object p)
        {
            Reizen.Add(new Reis()
            {
                Naam = p.ToString()
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
