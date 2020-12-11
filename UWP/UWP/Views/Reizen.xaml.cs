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
        public ObservableCollection<Reis> reizen = new ObservableCollection<Reis>();
        public Reizen()
        {
            this.InitializeComponent();
            this.DataContext = new ReisViewModel();
            //AddReizenUI(rvm.Reizen.ToList());
        }

        private void Reis_Navigate(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page3));
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
        
        //relativepanel wordt niet meer gebruikt
        //eventueel voor addbutton te gebruiken?
        private void AddReizenUI(List<Reis> reizen)
        {
            bool left = true;
            Grid lastAdded = null;

            reizen.ForEach(r =>
            {
                var grid = new Grid()
                {
                    Style = (Style)Application.Current.Resources["ReisBlock"]
                };
                grid.Tapped += Reis_Navigate;
                grid.PointerEntered += Reis_PointerEntered;
                grid.PointerExited += Reis_PointerExited;

                RowDefinition r1 = new RowDefinition();
                r1.Height = new GridLength(125);
                grid.RowDefinitions.Add(r1);
                grid.RowDefinitions.Add(new RowDefinition());

                ColumnDefinition c1 = new ColumnDefinition();
                c1.Width = new GridLength(300);
                grid.ColumnDefinitions.Add(c1);
                grid.ColumnDefinitions.Add(new ColumnDefinition());

                grid.Children.Add(MaakRectangle());
                TextBlock titel = new TextBlock()
                {
                    Style = (Style)Application.Current.Resources["TextWhite"],
                    FontSize = 48,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Text = r.Naam
                };
                TextBlock datum = new TextBlock()
                {
                    Style = (Style)Application.Current.Resources["TextWhite"],
                    FontSize = 36,
                    Text = r.Verplaatsingen[0].VertrekTijd.ToShortDateString()
                };
                grid.Children.Add(titel);
                grid.Children.Add(datum);

                if (lastAdded != null)
                {
                    if (!left)
                    {
                        RelativePanel.SetRightOf(grid, lastAdded);
                    } else
                    {
                        RelativePanel.SetBelow(grid, lastAdded);
                    }
                }
                //relativepanel.Children.Add(grid);

                left = !left;
                lastAdded = grid;
            });
        }

        private Rectangle MaakRectangle()
        {
            Rectangle r = new Rectangle()
            {
                Style = (Style)Application.Current.Resources["Rectangle"]
            };
            GradientStopCollection gradientStops = new GradientStopCollection();
            GradientStop stop1 = new GradientStop();
            stop1.Color = Color.FromArgb(1, 222, 41, 41);
            GradientStop stop2 = new GradientStop();
            stop2.Color = Color.FromArgb(1, 235, 203, 38);
            gradientStops.Add(stop1);
            gradientStops.Add(stop2);
            r.Fill = new LinearGradientBrush(gradientStops, 45);
            return r;
        }
    }
}
