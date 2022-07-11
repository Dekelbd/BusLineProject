using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace UiClient.DataTemplates
{
    internal class BusTemplateSelector:DataTemplateSelector
    {
        public DataTemplate BusListBoxItemTemplateTwo { get; set; }
        public DataTemplate BusListBoxItemTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            if (element!=null && item != null && item is Bus bus)
            {
                if (bus.Occupancy < 55)
                {
                    return BusListBoxItemTemplate;
                }
                else
                {
                    return BusListBoxItemTemplateTwo;
                }
            }
            return null;              
        }
    }
}
