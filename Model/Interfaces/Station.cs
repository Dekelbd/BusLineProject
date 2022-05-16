using System;
using System.Collections.Generic;
using System.Text;


namespace Model.Interfaces
{
    public class Station
    {
        public Station(string stationName, double latitude, double longitude)
        {
            _name = stationName;
            _latitude = latitude;
            _longitude = longitude;

        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _name = value;
                }
            }
        }
        public double Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {

                _latitude = value;

            }
        }

        public double Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {

                _longitude = value;

            }
        }


        private string _name;
        private double _latitude;
        private double _longitude;

        public override String ToString()
        {
            return "Station " + Name;
        }
    }




}
