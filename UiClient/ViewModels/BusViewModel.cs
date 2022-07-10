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
    public class BusViewModel : ViewModelBase
    {
        private ObservableCollection<Bus> _buses;
        private List<Bus> CurrentBuses;

        public void GetBuses()
        {
            CurrentBuses = BusService.Instance.GetBuses();
            ObservableCollection<Bus> obsCollection = new ObservableCollection<Bus>(CurrentBuses);
            _buses = obsCollection;

        }

        public BusViewModel()
        {
            GetBuses();
        }
        public ObservableCollection<Bus> Buses
        {

            get
            {
                return _buses;
            }
            set
            {
                _buses = value;
                OnPropertyChanged("Bus");
            }

        }      
    }
}
