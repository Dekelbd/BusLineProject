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
        AddDriverWindow AddDriverWin = new AddDriverWindow();
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
            CollectionViewSource.GetDefaultView(Drivers).Refresh();
            AddNewDriverCommand = new DelegateCommand(OnAddNewDriverCommandExecute);            
        }

        private void OnAddNewDriverCommandExecute()
        {            
            AddDriverWin.Show();         
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
