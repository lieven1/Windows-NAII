using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWP.Hulpers
{
    public class ReisDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ReisItem { get; set; }
        public DataTemplate AddButton { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            if (item != null && item is Reis)
            {
                Reis reis = item as Reis;
                if (!reis.IsFake)
                {
                    return ReisItem;
                }
                else
                {
                    return AddButton;
                }
            }
            return null;
            
        }
    }
}
