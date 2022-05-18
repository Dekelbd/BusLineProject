using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Interfaces
{
    public class Line
    {

        public Line(string lineName, List<Station> stations)
        {
            _lineName = lineName;
            _station = stations;
        }
        private Line()
        {

        }


        public string LineName
        {
            get
            {
                return _lineName;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _lineName = value;
                }
            }
        }

        public List<Station> Stations
        {
            get
            {
                return _station;
            }
            set
            {
                _station = value;
            }
        }


        private string _lineName;
        private List<Station> _station;
        public override String ToString()
        {
            return "Line " + _lineName;
        }

    }
}
