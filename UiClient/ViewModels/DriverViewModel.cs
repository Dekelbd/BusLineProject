using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server;
using Model.Interfaces;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace UiClient.ViewModels
{
    public class DriverViewModel : ViewModelBase
    {
        private ObservableCollection<Driver> _drivers;
        private List<Driver> CurrentDrivers;

        public void GetDrivers()
        {
            CurrentDrivers = BusService.Instance.GetDrivers();
            ObservableCollection<Driver> obsCollection = new ObservableCollection<Driver>(CurrentDrivers);
            _drivers = obsCollection;
            //CollectionViewSource v = new CollectionViewSource();
            //v.View.Refresh();

        }

        public DriverViewModel()
        {
            GetDrivers();
        }
        public ObservableCollection<Driver> Drivers
        {

            get
            {
                return _drivers;
            }
            set
            {
                _drivers = value;
                OnPropertyChanged("Driver");
            }
        }


    }
}
