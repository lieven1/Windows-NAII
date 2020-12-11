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
using UWP.Hulpers;
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
                reis.IsFake = false;
                Reizen.Add(reis);
            }
            Reizen.Add(new Reis() { IsFake = true }); // <-- add button
        }

        private void AddReis(object p)
        {
            Reizen.RemoveAt(Reizen.Count-1); //verwijder add button
            Reizen.Add(new Reis()
            {
                Naam = p.ToString(),
                IsFake = false
            });
            Reizen.Add(new Reis() { IsFake = true }); //voeg add button toe
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
