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
       
        public DelegateCommand AddNewDriverCommand { get; set; }
        //public ICollectionView ChangeDriver { get; set; }

        public void GetDrivers()
        {
            CurrentDrivers = BusService.Instance.GetDrivers();
            ObservableCollection<Driver> obsCollection = new ObservableCollection<Driver>(CurrentDrivers);
            Drivers = obsCollection;
        }

        public DriverViewModel()
        {
            GetDrivers();          
            AddNewDriverCommand = new DelegateCommand(OnAddNewDriverCommandExecute);
            //ChangeDriver = CollectionViewSource.GetDefaultView(Drivers);
            BusService.Instance.DriverUpdated += Instance_DriverUpdated;
        }

        private void OnAddNewDriverCommandExecute()
        {
            AddDriverWindow addDriverWin = new AddDriverWindow();
            addDriverWin.ShowDialog();   
        }

        private void Instance_DriverUpdated(object sender, EventArgs e)
        {
            //_drivers = new ObservableCollection<Driver>(BusService.Instance.GetDrivers());
            //ChangeDriver = CollectionViewSource.GetDefaultView(_drivers);
            //ChangeDriver.Refresh();
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
                OnPropertyChanged("Drivers");
            }
        }


    }
}
