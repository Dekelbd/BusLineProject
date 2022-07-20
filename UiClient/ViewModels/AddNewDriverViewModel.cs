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
    public class AddNewDriverViewModel : ViewModelBase
    {
        public DelegateCommand SaveNewDriverCommand { get; set; }
        private string DriverFirstName;
        private string DriverLastName;
        private string DriverAddress;
        private string DriverPhone;

        public AddNewDriverViewModel()
        {
            SaveNewDriverCommand = new DelegateCommand(OnSaveNewDriverCommandExecute);
        }

        private void OnSaveNewDriverCommandExecute()
        {
            BusService.Instance.AddDriver(FirstName,LastName,Address,PhoneNumber);           
        }
  

        public string FirstName
        {
            get
            {
                return DriverFirstName;
            }
            set
            {
                DriverFirstName = value;
                OnPropertyChanged("FirstName");
            }

        }
        public string LastName
        {
            get
            {
                return DriverLastName;
            }
            set
            {
                DriverLastName = value;
                OnPropertyChanged("LastName");
            }

        }
        public string Address
        {
            get
            {
                return DriverAddress;
            }
            set
            {
                DriverAddress = value;
                OnPropertyChanged("Address");
            }

        }
        public string PhoneNumber
        {
            get
            {
                return DriverPhone;
            }
            set
            {
                DriverPhone = value;
                OnPropertyChanged("PhoneNumber");
            }

        }

    }
}
