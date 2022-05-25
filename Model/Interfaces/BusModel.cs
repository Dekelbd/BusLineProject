using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public class BusModel
    {
        #region Fields
        List<Bus> busesList = new List<Bus>();
        List<Driver> driverList = new List<Driver>();
        List<Station> stationList = new List<Station>();
        List<Line> lineList = new List<Line>();
        #endregion

        #region Constructor
        public BusModel()
        {
            this.BusesList = new List<Bus>();
            this.DriverList = new List<Driver>();
            this.StationList = new List<Station>();
            this.LineList = new List<Line>();
        }
        #endregion

        #region Getters&Setters

        public List<Bus> BusesList { get => busesList; set => busesList = value; }
        public List<Driver> DriverList { get => driverList; set => driverList = value; }
        public List<Station> StationList { get => stationList; set => stationList = value; }
        public List<Line> LineList { get => lineList; set => lineList = value; }
        #endregion
    }
}
