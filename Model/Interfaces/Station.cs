using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;

namespace Model.Interfaces
{
    [Serializable]
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class Station : INotifyPropertyChanged
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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

        public Station(string stationName)
        {
            Name = stationName;
            Latitude = 0;
            Longitude = 0;
        }

        #endregion

        #region Fields
        private string _name;
        private double _latitude;
        private double _longitude;
        #endregion

        #region Getters&Setters
        [XmlAttribute("name")]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public double Latitude
        {
            get => _latitude;
            set
            {
                _latitude = value;
                OnPropertyChanged("Latitude");
            }
        }
        public double Longitude
        {
            get => _longitude;
            set
            {
                _longitude = value;
                OnPropertyChanged("Longitude");
            }
        }
        #endregion

        #region Operattors overload
        public override String ToString() => Name;

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Station))
            {
                return false;
            }
            return ((Station)obj).Name == this.Name;
        }
        #endregion

    }

}
