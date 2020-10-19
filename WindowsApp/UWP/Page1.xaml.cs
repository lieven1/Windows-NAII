using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page1 : Page
    {
        public ObservableCollection<Reis> reizen = new ObservableCollection<Reis>();

        public Page1()
        {
            this.InitializeComponent();

            reizen.Add(new Reis() { Naam = "Barcelona", Vertrek = DateTime.Now.AddDays(1), Terug = DateTime.Now.AddDays(2) });
            reizen.Add(new Reis() { Naam = "Parijs", Vertrek = DateTime.Now.AddDays(7), Terug = DateTime.Now.AddDays(12) });
            reizen.Add(new Reis() { Naam = "Berlijn", Vertrek = DateTime.Now.AddDays(31), Terug = DateTime.Now.AddDays(33) });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            reizen.Add(new Reis() { Naam = "New York", Vertrek = DateTime.Now.AddDays(50), Terug = DateTime.Now.AddDays(55) });
        }
    }
}
