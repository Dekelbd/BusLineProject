using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UiClient.ViewModels;
namespace UiClient.Views
{
    /// <summary>
    /// Interaction logic for BusView.xaml
    /// </summary>
    public partial class BusView : UserControl
    {
        public BusView()
        {
            InitializeComponent();
            DataContext = new BusViewModel();
            MyList.Items.Filter = IdBusFilter;

        }
  
        private bool IdBusFilter(object obj)
        {
            var FilterObj = obj as Model.Interfaces.Bus;

            return FilterObj.Id.ToString().Contains(FilterTextbox.Text);

        }

        private void FilterTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(FilterTextbox.Text == null)
            {
                MyList.Items.Filter = null;
            }
            else
            {
                MyList.Items.Filter = IdFilter();
            }

        }

        private Predicate<object> IdFilter()
        {
            return IdBusFilter;
        }
    }
}
