using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;
using System.Configuration;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;


namespace Server
{
    public sealed class BusService : IBusService
    {

        private static IBusService _instance = null;
        private static readonly object padlock = new object();
        private BusService() {
            ReadFromXml() ; }
        public static IBusService Instance
        {
            get
            {
                lock (padlock)
                {

                    if (_instance == null)
                    {
                        _instance = new BusService();
                    }
                }

            return _instance;
            }
        }


        #region Fileds
        BusModel _model = new BusModel();

        public event EventHandler<EventArgs> BusUpdated;
        public event EventHandler<EventArgs> DriverUpdated;

        #endregion

        #region Constructor
        //public BusService() => LoadData();

        #endregion

        #region Private methods
        private void LoadData()
        {
             if (ConfigurationManager.AppSettings["SavingDataFormat"] == "InMemory")
             {
                 _model = CreateMockData();
             }
             else if (ConfigurationManager.AppSettings["SavingDataFormat"] == "File")
             {
                 ReadFromXml();
             }
        }
        private BusModel CreateMockData()
        {
            AddStation("Haifa", 1.2, 2.3);
            AddStation("Tel Aviv", 1.2, 2.3);
            AddStation("Akko", 1.2, 2.3);
            AddStation("Nahariya", 1.2, 2.3);
            AddStation("Rehovot", 1.2, 2.3);
            AddLine("aaa", "1,2");
            AddLine("bbb", "1,3,5");
            AddLine("ccc", "2,4,5");
            AddDriver("Dekel", "Ben", "David", "0525555555");
            AddDriver("Eyal", "Turz", "Yagur", "0523333333");
            AddDriver("Michael", "Shachur", "Eshar", "0527777777");
            AddBus(123, "1,2", 1, 50, 1, "blue");
            AddBus(456, "2,3", 2, 70, 2, "red");
            return new BusModel();
        }
        private List<Bus> IsStationInLine(string lineName)
        {
            string[] splitLine = lineName.Split(',');
            int flag = 1;
            List<Bus> busResult = new List<Bus>();

            foreach (Bus bus in _model.BusesList)
            {
                foreach (Line line in bus.Lines)
                {
                    int maxIndex = 0;
                    for (int i = 0; i < splitLine.Length; i++)
                    {
                        Station tempStation = new Station(splitLine[i]);
                        if (!(line.Stations.Contains(tempStation)))
                        {
                            flag = 0;
                        }
                        int tempIndex = line.Stations.IndexOf(tempStation);
                        if (tempIndex < maxIndex)
                        {
                            flag = 0;
                        }
                        maxIndex = tempIndex;
                    }
                    if (flag == 1)
                    {
                        busResult.Add(bus);
                    }
                    flag = 1;
                }
            }
            busResult.Distinct().ToList();
            return busResult;

        }
        #endregion

        #region Public methods
        public int AddBus(int id, String linesNumbers, int driverNum, int occupancy, int type, string color)
        {
            if ((driverNum < 0) || (driverNum > _model.DriverList.Count))
            {              
                return 1;
            }

            for (int i = 0; i < _model.BusesList.Count; i++)
            {
                if (_model.BusesList[i].Id == id)
                {                   
                    return 2;
                }
            }
            Driver driver = _model.DriverList[driverNum - 1];
            List<Line> lines = new List<Line>();
            string[] numbers = linesNumbers.Split(',');
            if (numbers.Length > 0)
            {
                foreach (String number in numbers)
                {
                    int num = int.Parse(number) - 1;
                    lines.Add(_model.LineList[num]);
                }
            }
            Bus bus = new Bus(id, lines, driver, occupancy, (type == 1) ? BusType.trips : BusType.communal, color);
            if (bus == null)
            {
                return 3;
            }
            _model.BusesList.Add(bus);
            BusUpdated.Invoke(this, new EventArgs());
            return 4;
        }
        public bool AddDriver(string firstName, string lastName, string address, string phoneNumber)
        {
            Driver driver = new Driver(firstName, lastName, address, phoneNumber);
            if (driver == null)
            {
                return false;
            }
            _model.DriverList.Add(driver);
            DriverUpdated.Invoke(this, new EventArgs());
            return true;
        }
        public bool AddLine(string lineName, String stationsNumbers)
        {
            List<Station> stations = new List<Station>();
            string[] numbers = stationsNumbers.Split(',');
            foreach (String number in numbers)
            {
                int num = int.Parse(number) - 1;
                stations.Add(_model.StationList[num]);
            }
            Line line = new Line(lineName, stations);
            if (line == null)
            {
                return false;
            }
            _model.LineList.Add(line);           
            return true;
        }
        public bool AddStation(string name, double latitude, double longitude)
        {
            Station station = new Station(name, latitude, longitude);
            if (station == null)
            {
                return false;
            }
            _model.StationList.Add(station);            
            return true;
        }
        public Bus GetBusInfo(int id)
        {
            Bus busInfo = null;
            _model.BusesList.ForEach(bus =>
            {              
                if (bus.Id.Equals(id))
                {
                    busInfo = bus;
                }
            });
            return busInfo;
        }
        public List<Bus> GetBusByLine(string lineName)
        {
            List<Bus> AcceptBuses = new List<Bus>();
            AcceptBuses = null;
            AcceptBuses = IsStationInLine(lineName);
            return AcceptBuses;
        }
        public List<Bus> GetBusByStation(string stationName)
        {
            int flag = 0;
            List<Bus> busByStation = new List<Bus>();

            _model.BusesList.ForEach(bus => bus.Lines.ForEach(line => line.Stations.ForEach(station =>
            {
                
                if (station.Name.Equals(stationName))
                {
                    busByStation.Add(bus);
                    flag = 1;
                }
            })));
            if(flag == 0)
            {
                busByStation = null;
            }
            return busByStation;

        }
        public Station GetStationLocation(string stationName)
        {
            Station correctLocation = null;
            _model.StationList.ForEach(station =>
            {
                if (station.Name.Equals(stationName))
                {               
                    correctLocation = station;
                }
            });
            return correctLocation;
        }
        public List<Driver> GetDrivers()
        {            
            List<Driver> drivers = new List<Driver>();
            foreach (Driver driver in _model.DriverList)
            {
                drivers.Add(driver);
            }
            return drivers;
        }
        public List<Bus> GetBuses()
        {
            List<Bus> buses = new List<Bus>();
            foreach (Bus bus in _model.BusesList)
            {
                buses.Add(bus);
            }
            return buses;
        }
        public List<Line> GetLines()
        {
            List<Line> lines = new List<Line>();
            foreach (Line line in _model.LineList)
            {
                lines.Add(line);
            }
            return lines;
        }
        public List<Station> GetStations()
        {
            List<Station> stations = new List<Station>();
            foreach (Station station in _model.StationList)
            {
                stations.Add(station);
            }
            return stations;
        }
        public void WriteToXml()
        {
            var filePathBus = Path.Combine(Environment.CurrentDirectory, "Configuration/TransportConfiguration.xml");
            var serializerBus = new XmlSerializer(typeof(List<Bus>));
            ////using (var writerBus = new StreamWriter(@"C:\Users\dekel\source\repos\BusLineProject\Model\Configuration\TransportConfiguration.xml"))
            using (var writerBus = new StreamWriter(filePathBus))
            {
                serializerBus.Serialize(writerBus, _model.BusesList);
            }

            var filePathDriver = Path.Combine(Environment.CurrentDirectory, "Configuration/Driver.xml");
            var serializerDriver = new XmlSerializer(typeof(List<Driver>));
            //using (var writerDriver = new StreamWriter("C:\Users\dekel\source\repos\BusLineProject\Model\Configuration\Driver.xml"))
            using (var writerDriver = new StreamWriter(filePathDriver))
            {
                serializerDriver.Serialize(writerDriver, _model.DriverList);
            }

            var filePathLine = Path.Combine(Environment.CurrentDirectory, "Configuration/Line.xml");
            var serializerLine = new XmlSerializer(typeof(List<Line>));
            //using (var writerLine = new StreamWriter(@"C:\Users\dekel\source\repos\BusLineProject\Model\Configuration\Line.xml"))
            using (var writerLine = new StreamWriter(filePathLine))
            {
                serializerLine.Serialize(writerLine, _model.LineList);
            }

            var filePathStation = Path.Combine(Environment.CurrentDirectory, "Configuration/Station.xml");
            var serializerStation = new XmlSerializer(typeof(List<Station>));
            using (var writerStation = new StreamWriter(filePathStation))
            //using (var writerStation = new StreamWriter(@"C:\Users\dekel\source\repos\BusLineProject\Model\Configuration\Station.xml"))
            {
                serializerStation.Serialize(writerStation, _model.StationList);
            }
        }
        public void ReadFromXml()
        {
            //var filepath = @"C:\Users\dekel\source\repos\BusLineProject\TransportConfiguration.xml";

            var filePathBus = Path.Combine(Environment.CurrentDirectory, "Configuration/TransportConfiguration.xml");
            var serializerBus = new XmlSerializer(typeof(List<Bus>));
            using (var Reader = new StreamReader(filePathBus))
            {
                _model.BusesList = (List<Bus>)serializerBus.Deserialize(Reader);
            }
            var filePathLine = Path.Combine(Environment.CurrentDirectory, "Configuration/Line.xml");
            var serializerLine = new XmlSerializer(typeof(List<Line>));
            using (var Reader = new StreamReader(filePathLine))
            {
                _model.LineList = (List<Line>)serializerLine.Deserialize(Reader);
            }

            var filePathDriver = Path.Combine(Environment.CurrentDirectory, "Configuration/Driver.xml");
            var serializerDriver = new XmlSerializer(typeof(List<Driver>));
            using (var Reader = new StreamReader(filePathDriver))
            {
                _model.DriverList = (List<Driver>)serializerDriver.Deserialize(Reader);
            }

            var filePathStation = Path.Combine(Environment.CurrentDirectory, "Configuration/Station.xml");
            var serializerStation = new XmlSerializer(typeof(List<Station>));
            using (var Reader = new StreamReader(filePathStation))
            {
                _model.StationList = (List<Station>)serializerStation.Deserialize(Reader);
            }

        }
        #endregion
    }
}
