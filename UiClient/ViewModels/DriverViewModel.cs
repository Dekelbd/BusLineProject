using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server;
using Model.Interfaces;

namespace UiClient.ViewModels
{
    public class DriverViewModel : ViewModelBase
    {
        private List<Driver> CurrentDriver;

        public DriverViewModel()
        {
            CurrentDriver = BusService.Instance.GetDrivers();
        }


    }
}
