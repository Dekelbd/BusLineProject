using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server;
using Model.Interfaces;

namespace UiClient.ViewModels
{
    public class StationViewModel : ViewModelBase
    {
        private ObservableCollection<Station> _stations;
        private List<Station> CurrentStations;

        public void GetStations()
        {
            CurrentStations = BusService.Instance.GetStations();
            ObservableCollection<Station> obsCollection = new ObservableCollection<Station>(CurrentStations);
            _stations = obsCollection;

        }

        public StationViewModel()
        {
            GetStations();
        }
        public ObservableCollection<Station> Stations
        {

            get
            {
                return _stations;
            }
            set
            {
                _stations = value;
                OnPropertyChanged("Stations");
            }
        }


    }
}
