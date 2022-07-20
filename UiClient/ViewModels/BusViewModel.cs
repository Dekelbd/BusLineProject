using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server;
using Model.Interfaces;
using System.Windows.Data;
using UiClient.Converters;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace UiClient.ViewModels
{
    public class BusViewModel : ViewModelBase
    {
        private ObservableCollection<Bus> _buses = new ObservableCollection<Bus>();
        private List<Bus> CurrentBuses;
        private string _searchText;
        public ICollectionView FilterBuses { get; set; }

        public void GetBuses()
        {
            CurrentBuses = BusService.Instance.GetBuses();
            ObservableCollection<Bus> obsCollection = new ObservableCollection<Bus>(CurrentBuses);
            _buses = obsCollection;

        }

        public BusViewModel()
        {
            
            GetBuses();
            FilterBuses = CollectionViewSource.GetDefaultView(Buses);
            FilterBuses.Filter = (item =>
            {
                if (item is Bus bus)
                    if (string.IsNullOrEmpty(SearchText) || bus.Id.ToString().Contains(SearchText))
                    {
                        return true;
                    }
                return false;


            });
            BusService.Instance.BusUpdated += Instance_BusUpdated;
            //BusService.Instance.BusUpdated += (sender, e) =>
            //{
            //    _buses = new ObservableCollection<Bus>(BusService.Instance.GetBuses());
            //    FilterBuses.Refresh();
            //};
        }

        private void Instance_BusUpdated(object sender, EventArgs e)
        {
            _buses = new ObservableCollection<Bus>(BusService.Instance.GetBuses());
            FilterBuses.Refresh();
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
                OnPropertyChanged("Buses");
            }

        }
        public string SearchText
        {

            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
                FilterBuses.Refresh();
            }

        }
    }
}
