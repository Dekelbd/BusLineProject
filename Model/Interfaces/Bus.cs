using System;
using System.Collections.Generic;
using System.Text;
using Model.Enums;

namespace Model.Interfaces
{

    public class Bus
    {
        public Bus(int id, List<Line> lines, Driver driver, int occupancy, BusType type)
        {
            _lines = lines;
            _id = id;
            _driver = driver;
            _occupancy = occupancy;
            _type = type;

        }

        public List<Line> Lines
        {
            get
            {
                return (_lines);
            }
            set
            {
                if (_lines != null)
                {
                    _lines = value;
                }
            }
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public Driver Driver
        {
            get
            {
                return (_driver);
            }
            set
            {
                if (_driver != null)
                {
                    _driver = value;
                }
            }
        }

        public int Occupancy
        {
            get
            {
                return _occupancy;
            }
            set
            {
                _occupancy = value;
            }
        }

        public BusType _Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }


        private List<Line> _lines;
        private int _id;
        private Driver _driver;
        private int _occupancy;
        private BusType _type;

    }
}
