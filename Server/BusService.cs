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
    public class BusService : IBusService
    {
        #region Fileds

        BusModel _model = new BusModel();
        #endregion

        #region Constructor
        public BusService() => LoadData();
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
            AddBus(123, "1,2", 1, 50, 1);
            AddBus(456, "2,3", 2, 70, 2);
            return new BusModel();
        }
        #endregion

        #region Public methods
        public int AddBus(int id, String linesNumbers, int driverNum, int occupancy, int type)
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
            Bus bus = new Bus(id, lines, driver, occupancy, (type == 1) ? BusType.trips : BusType.communal);
            if (bus == null)
            {
                return 3;
            }
            _model.BusesList.Add(bus);          
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
            //bool found = false;
            Bus busInfo = null;
            _model.BusesList.ForEach(bus =>
            {
               
                if (bus.Id.Equals(id))
                {

                    /*bus.Lines.ForEach(line =>
                    {
                        Console.WriteLine($"Bus number: { bus.Id}\n" +
                          $"Bus driver name: {bus.Driver.FirstName} {bus.Driver.LastName}\n" +
                          $"Bus line: {line.LineName}\n" +
                          $"Bus occupancy: {bus.Occupancy}\n" +
                          $"Bus type: {bus.Type}\n\n ");
                    });
                    found = true;*/
                    busInfo = bus;

                }
            });
            /*if (!found)
            {
                Console.WriteLine("Bus not found!");
            }*/
            return busInfo;
        }

        public List<Bus> GetBusByLine(string lineName)
        {
            //int flag = 0;
            /*_model.LineList.ForEach(line =>
            {
                if (line.LineName.Equals(lineName))
                {
                    Console.WriteLine($"Line name: {line.LineName}");
                    flag = 1;
                }
            });*/

            List<Bus> AcceptBuses = new List<Bus>();
            AcceptBuses = null;
            AcceptBuses = IsStationInLine(lineName);
            /*if(flag == 0)
            {
               AcceptBuses = null;
               return AcceptBuses;
            }*/
            return AcceptBuses;
            /*AcceptBuses.ForEach(bus =>
            {
                    flag = 1;
                    Console.WriteLine($"Bus number: { bus.Id}\n" +
                        $"Bus driver name: {bus.Driver.FirstName} {bus.Driver.LastName}\n" +
                        $"Bus occupancy: {bus.Occupancy}\n" +
                        $"Bus type: {bus.Type}\n\n ");   
            });*/

           /* if (flag == 0)
            {
                Console.WriteLine($"The line {lineName} is not exist!\n");
            }*/
            //return AcceptBuses;
        }

        public List<Bus> IsStationInLine(string lineName)
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
                        if (!(line.Station.Contains(tempStation)))
                        {
                            flag = 0;
                        }
                        int tempIndex = line.Station.IndexOf(tempStation);
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
        public List<Bus> GetBusByStation(string stationName)
        {
            int flag = 0;
            List<Bus> busByStation = new List<Bus>();
           // busByStation = null;

            _model.BusesList.ForEach(bus => bus.Lines.ForEach(line => line.Station.ForEach(station =>
            {
                
                if (station.Name.Equals(stationName))
                {
                    busByStation.Add(bus);
                    /*Console.WriteLine($"Bus number: { bus.Id}\n" +
                         $"Bus driver name: {bus.Driver.FirstName} {bus.Driver.LastName}\n" +
                         $"Bus line: {line.LineName}\n" +
                         $"Bus occupancy: {bus.Occupancy}\n" +
                         $"Bus type: {bus.Type}\n\n ");*/
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
            //int flag = 0;
            Station correctLocation = null;
           // List<Station> stationInfo = new List<Station>();

            _model.StationList.ForEach(station =>
            {
                if (station.Name.Equals(stationName))
                {               
                    correctLocation = station;
                   /* Console.WriteLine($"station name: {station.Name} - " +
                   $"station latitude: {station.Latitude}, " +
                   $"station longitude: {station.Longitude}\n");*/
                    //flag = 1;
                }
            });
            return correctLocation;


           /* _model.BusesList.ForEach(bus => bus.Lines.ForEach(line => line.Station.ForEach(station =>
            {
                if (station.Name.Equals(stationName))
                {
                    stationInfo.Add(station);
                    Console.WriteLine($"Bus number: { bus.Id}\n" +
                         $"Bus driver name: {bus.Driver.FirstName} {bus.Driver.LastName}\n" +
                         $"Bus line: {line.LineName}\n" +
                         $"Bus occupancy: {bus.Occupancy}\n" +
                         $"Bus type: {bus.Type}\n\n ");
                }
            })));*/
           /*
            if (flag == 0)
            {
                Console.WriteLine($"The station {stationName} is not exist!\n");
            }
            return stationInfo;*/
        }

        public List<Driver> PrintDrivers()
        {
            List<Driver> drivers = new List<Driver>();
            //int i = 1;
            foreach (Driver driver in _model.DriverList)
            {
                drivers.Add(driver);
                //Console.WriteLine(i + ". " + driver);
                //i++;
            }
            return drivers;
        }

        public List<Line> PrintLines()
        {
            List<Line> lines = new List<Line>();
            //int i = 1;
            foreach (Line line in _model.LineList)
            {
                lines.Add(line);
                //Console.WriteLine(i + ". " + line);
                //i++;
            }
            return lines;
        }

        public List<Station> PrintStations()
        {
            List<Station> stations = new List<Station>();
            //int i = 1;
            foreach (Station station in _model.StationList)
            {
                stations.Add(station);
                //Console.WriteLine(i + ". " + station);
                //i++;
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
