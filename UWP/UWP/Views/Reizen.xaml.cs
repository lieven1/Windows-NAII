using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UWP.Models;
using UWP.ViewModels;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Reizen : Page
    {
        public ReisViewModel rvm;
        public Reizen()
        {
            this.InitializeComponent();
            rvm = new ReisViewModel();
            this.DataContext = rvm;
        }

        private void Reis_Navigate(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page3));
        }

        private void Reis_Add(object sender, TappedRoutedEventArgs e)
        {
            rvm.AddReisCommand.Execute("New York");
        }

        private void Reis_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Grid g = sender as Grid;
            Rectangle r = g.Children.OfType<Rectangle>().Single();
            r.Fill.Opacity = 0.75;
        }

        private void Reis_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Grid g = sender as Grid;
            Rectangle r = g.Children.OfType<Rectangle>().Single();
            r.Fill.Opacity = 1;
        }
    }
}
