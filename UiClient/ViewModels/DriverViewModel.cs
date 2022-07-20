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
using System.Windows.Input;
using UiClient.ViewModels;
using System.Windows;
using Prism.Commands;
using UiClient.Views;

namespace UiClient.ViewModels
{
    public class DriverViewModel : ViewModelBase
    {
        public ObservableCollection<Driver> _drivers;
        private List<Driver> CurrentDrivers;
        private string _searchText;
        public ICollectionView FilterDrivers { get; set; }
        public DelegateCommand AddNewDriverCommand { get; set; }

        public void GetDrivers()
        {
            CurrentDrivers = BusService.Instance.GetDrivers();
            ObservableCollection<Driver> obsCollection = new ObservableCollection<Driver>(CurrentDrivers);
            Drivers = obsCollection;
        }

        public DriverViewModel()
        {
            GetDrivers();
            FilterDrivers = CollectionViewSource.GetDefaultView(Drivers);
            FilterDrivers.Filter = (item =>
            {
                if (item is Driver driver)
                    if (string.IsNullOrEmpty(SearchText) || driver.FirstName.ToString().Contains(SearchText))
                    {
                        return true;
                    }
                return false;


            });
            AddNewDriverCommand = new DelegateCommand(OnAddNewDriverCommandExecute);
            BusService.Instance.DriverUpdated += Instance_DriverUpdated;


        }

        private void OnAddNewDriverCommandExecute()
        {
            AddDriverWindow addDriverWin = new AddDriverWindow();
            addDriverWin.ShowDialog();   
        }

        private void Instance_DriverUpdated(object sender, EventArgs e)
        {
            var drivers = BusService.Instance.GetDrivers();
            Drivers.Clear();
            drivers.ForEach(d => Drivers.Add(d));     
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
                OnPropertyChanged("Drivers");
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
                FilterDrivers.Refresh();
            }

        }


    }
}
