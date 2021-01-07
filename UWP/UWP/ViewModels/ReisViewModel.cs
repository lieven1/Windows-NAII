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
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace UWP.ViewModels
{
    public class ReisViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Reis> Reizen { get; set; }
        public RelayCommand AddReisCommand { get; set; }
        private List<GradientStopCollection> _brushes = new List<GradientStopCollection>();

        public ReisViewModel()
        {
            Reizen = new ObservableCollection<Reis>();
            loadDataAsync();
            AddReisCommand = new RelayCommand(AddReis);
            InitializeColors();
        }

        private void InitializeColors()
        {
            var stops1 = new GradientStopCollection();
            stops1.Add(new GradientStop() { Color = Color.FromArgb(1, 222, 41, 41) });
            stops1.Add(new GradientStop() { Color = Color.FromArgb(1, 235, 203, 38) });
            _brushes.Add(stops1);

            var stops2 = new GradientStopCollection();
            stops2.Add(new GradientStop() { Color = Color.FromArgb(1, 41, 81, 222) });
            stops2.Add(new GradientStop() { Color = Color.FromArgb(1, 164, 51, 234) });
            _brushes.Add(stops2);

            var stops3 = new GradientStopCollection();
            stops3.Add(new GradientStop() { Color = Color.FromArgb(1, 49, 184, 27) });
            stops3.Add(new GradientStop() { Color = Color.FromArgb(1, 45, 192, 238) });
            _brushes.Add(stops3);
        }

        private GradientStopCollection GetColor()
        {
            if (_brushes.Count == 0)
            {
                InitializeColors();
            }
            Random random = new Random();
            int index = random.Next(_brushes.Count);
            GradientStopCollection colors = _brushes.ElementAt(index);
            _brushes.Remove(colors);
            return colors;
        }

        private async void loadDataAsync()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/reis"));
            var reislist = JsonConvert.DeserializeObject<IList<Reis>>(json);
            foreach (var reis in reislist)
            {
                reis.IsFake = false;
                GradientStopCollection stops = GetColor();
                reis.Color1 = stops.ElementAt(0).Color;
                reis.Color2 = stops.ElementAt(1).Color;
                Reizen.Add(reis);
            }
            Reizen.Add(new Reis() { IsFake = true }); // <-- add button
        }

        private async void AddReis(object p)
        {
            Reis r = new Reis()
            {
                Naam = p.ToString(),
                IsFake = false
            };
            GradientStopCollection stops = GetColor();
            r.Color1 = stops.ElementAt(0).Color;
            r.Color2 = stops.ElementAt(1).Color;

            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync(new Uri("http://localhost:5000/api/reis"), r);

            if (response.IsSuccessStatusCode)
            {
                Reizen.RemoveAt(Reizen.Count - 1); //verwijder add button
                Reizen.Add(r);
                Reizen.Add(new Reis() { IsFake = true }); //voeg add button toe
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
