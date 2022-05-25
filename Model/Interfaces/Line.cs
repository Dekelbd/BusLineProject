using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Model.Interfaces
{
    [Serializable]
    public class Line
    {

        #region Constructor
        public Line(string lineName, List<Station> stations)
        {
            LineName = lineName;
            Station = stations;
        }
        private Line()
        {

        }
        #endregion

        #region Fields
        private string _lineName;
        private List<Station> _station;
        #endregion

        #region Getters&Setters
        [XmlAttribute("name")]
        public string LineName { get => _lineName; set => _lineName = value; }
        public List<Station> Station { get => _station; set => _station = value; }
        #endregion

        #region Operattors overload
        public override String ToString() => "Line " + LineName;
        #endregion

    }
}
