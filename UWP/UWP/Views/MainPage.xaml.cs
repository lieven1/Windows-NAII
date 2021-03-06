﻿using Windows.UI.Xaml.Controls;

namespace UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem selectedItem = (NavigationViewItem)args.SelectedItem;
            switch (selectedItem.Tag.ToString())
            {
                case "Page1":
                    MainFrame.Navigate(typeof(Reizen));
                    break;
                case "Page2":
                    MainFrame.Navigate(typeof(CheckListPage));
                    break;
                case "Page3":
                    MainFrame.Navigate(typeof(ItemsToevoegenView));
                    break;
            }
        }
    }
}
