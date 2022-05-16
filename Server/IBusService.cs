using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;


namespace Server
{
    public interface IBusService
    {
        bool AddBus(int id, String linesNumbers, int driverNum, int occupancy, int type);
        bool AddStation(string name, double latitude, double longitude);
        bool AddLine(string lineName, String stationsNumbers);
        bool AddDriver(string firstName, string lastName, string address, string phoneNumber);
        void GetLineInfo(string lineName);
        void GetStationInfo(string stationName);
        void GetBusInfo(int id);
        void PrintStations();
        void PrintDrivers();
        void PrintLines();
    }
}
