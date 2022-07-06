using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;

namespace Model.Interfaces
{
    [Serializable]
    public class Line: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Constructor
        public Line(string lineName, List<Station> stations)
        {
            LineName = lineName;
            Stations = stations;
        }
        private Line()
        {

        }
        #endregion

        #region Fields
        private string _lineName;
        private List<Station> _stations;
        #endregion

        #region Getters&Setters
        [XmlAttribute("name")]
        public string LineName
        {
            get => _lineName;
            set
            {
                _lineName = value;
                OnPropertyChanged("LineName");
            }
        }
                
        public List<Station> Stations
        {
            get => _stations;
            set
            { 
                _stations = value;
                OnPropertyChanged("Stations");
            }
            #endregion
        }

        #region Operattors overload
        public override String ToString() => LineName;
        #endregion

    }
}
