using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Model.Interfaces
{
    [Serializable]
    public class Station
    {
        #region Constructor
        public Station(string stationName, double latitude, double longitude)
        {
            Name = stationName;
            Latitude = latitude;
            Longitude = longitude;

        }
        private Station()
        {

        }
        #endregion

        #region Fields
        private string _name;
        private double _latitude;
        private double _longitude;
        #endregion

        #region Getters&Setters
        [XmlAttribute("name")]
        public string Name { get => _name; set => _name = value; }
        public double Latitude { get => _latitude; set => _latitude = value; }
        public double Longitude { get => _longitude; set => _longitude = value; }
        #endregion

        #region Operattors overload
        public override String ToString() => "Station " + Name;
        #endregion
    }

}
