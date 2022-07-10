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
        #region Add methods
        int AddBus(int id, String linesNumbers, int driverNum, int occupancy, int type, string color);
        bool AddStation(string name, double latitude, double longitude);
        bool AddLine(string lineName, String stationsNumbers);
        bool AddDriver(string firstName, string lastName, string address, string phoneNumber);
        #endregion

        #region Get methods
        List<Bus> GetBusByLine(string lineName);
        Station GetStationLocation(string stationName);
        List<Bus> GetBusByStation(string stationName);
        Bus GetBusInfo(int id);
        List<Station> GetStations();
        List<Driver> GetDrivers();
        List<Line> GetLines();
        List<Bus> GetBuses();
        #endregion

        #region Xml methods
        void WriteToXml();
        void ReadFromXml();
        #endregion

        #region Other methods
        //List<Bus> IsStationInLine(string lineName);
        #endregion

    }
}
