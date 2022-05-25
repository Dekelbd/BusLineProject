using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Model.Enums;

namespace Model.Interfaces
{
    [Serializable]
    public class Bus
    {
        #region Constructor
        public Bus(int id, List<Line> lines, Driver driver, int occupancy, BusType type)
        {
            Lines = lines;
            _id = id;
            _driver = driver;
            _occupancy = occupancy;
            _type = type;

        }
        private Bus()
        {

        }
        #endregion

        #region Getters&Setters
        [XmlArray("line")]
        public List<Line> Lines { get => _lines; set => _lines = value; }
        [XmlAttribute("BusId")]
        public int Id { get => _id; set => _id = value; }
        public Driver Driver { get => _driver; set => _driver = value; }
        public int Occupancy { get => _occupancy; set => _occupancy = value; }
        public BusType Type { get => _type; set => _type = value; }
        #endregion

        #region Fields
        private List<Line> _lines;
        private int _id;
        private Driver _driver;
        private int _occupancy;
        private BusType _type;
        #endregion

    }
}
