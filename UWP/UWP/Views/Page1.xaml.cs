using System.Collections.ObjectModel;
using UWP.Models;
using UWP.ViewModels;
using Windows.UI.Xaml.Controls;

namespace UWP.Views
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
            this.DataContext = new ReisViewModel();
        }

        private void Lijst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reis r = (Reis)lijst.SelectedItem;
            Frame.Navigate(typeof(Details),r);
        }
    }
}
