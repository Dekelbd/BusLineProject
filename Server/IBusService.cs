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
        bool AddBus(int id, String linesNumbers, int driverNum, int occupancy, int type);
        bool AddStation(string name, double latitude, double longitude);
        bool AddLine(string lineName, String stationsNumbers);
        bool AddDriver(string firstName, string lastName, string address, string phoneNumber);
        #endregion

        #region Get methods
        void GetLineInfo(string lineName);
        void GetStationInfo(string stationName);
        void GetBusInfo(int id);
        #endregion

        #region Print methods
        void PrintStations();
        void PrintDrivers();
        void PrintLines();
        #endregion

        #region Xml methods
        void WriteToXml();
        void ReadFromXml();
        #endregion

        #region Other methods
        List<Bus> IsStationInLine(string lineName);
        #endregion

    }
}
