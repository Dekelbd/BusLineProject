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
            /* if (ConfigurationManager.AppSettings["SavingDataFormat"] == "InMemory")
             {
                 _model = CreateMockData();
             }
             else if (ConfigurationManager.AppSettings["SavingDataFormat"] == "File")
             {
                 ReadFromXml();
             }*/
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
        public bool AddBus(int id, String linesNumbers, int driverNum, int occupancy, int type)
        {
            if ((driverNum < 0) || (driverNum > _model.DriverList.Count))
            {
                Console.WriteLine("Driver not found");
                return false;
            }

            for (int i = 0; i < _model.BusesList.Count; i++)
            {
                if (_model.BusesList[i].Id == id)
                {
                    Console.WriteLine($"Bus number id {id} is already exist! c'ant create duplicate buses\n");
                    return false;
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
                return false;
            }
            _model.BusesList.Add(bus);
            Console.WriteLine("Bus add successfully!\n");
            return true;
        }

        public bool AddDriver(string firstName, string lastName, string address, string phoneNumber)
        {
            Driver driver = new Driver(firstName, lastName, address, phoneNumber);
            if (driver == null)
            {
                return false;
            }
            _model.DriverList.Add(driver);
            Console.WriteLine("Driver add successfully!\n");
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
            Console.WriteLine("Line add successfull!\n");
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
            Console.WriteLine("Station add successfully!\n");
            return true;
        }

        public void GetBusInfo(int id)
        {
            bool found = false;

            _model.BusesList.ForEach(bus =>
            {
                if (bus.Id.Equals(id))
                {
                    bus.Lines.ForEach(line =>
                    {
                        Console.WriteLine($"Bus number: { bus.Id}\n" +
                          $"Bus driver name: {bus.Driver.FirstName} {bus.Driver.LastName}\n" +
                          $"Bus line: {line.LineName}\n" +
                          $"Bus occupancy: {bus.Occupancy}\n" +
                          $"Bus type: {bus.Type}\n\n ");
                    });
                    found = true;
                }
            });
            if (!found)
            {
                Console.WriteLine("Bus not found!");
            }
        }

        public void GetLineInfo(string lineName)
        {
            int flag = 0;
            _model.LineList.ForEach(line =>
            {
                if (line.LineName.Equals(lineName))
                {
                    Console.WriteLine($"Line name: {line.LineName}");
                    flag = 1;
                }
            });

            List<Bus> AcceptBuses = new List<Bus>();
            AcceptBuses = IsStationInLine(lineName);
            AcceptBuses.ForEach(bus =>
            {
                    flag = 1;
                    Console.WriteLine($"Bus number: { bus.Id}\n" +
                        $"Bus driver name: {bus.Driver.FirstName} {bus.Driver.LastName}\n" +
                        $"Bus occupancy: {bus.Occupancy}\n" +
                        $"Bus type: {bus.Type}\n\n ");     
            });

            if (flag == 0)
            {
                Console.WriteLine($"The line {lineName} is not exist!\n");
            }
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

        public void GetStationInfo(string stationName)
        {
            int flag = 0;

            _model.StationList.ForEach(station =>
            {
                if (station.Name.Equals(stationName))
                {
                    Console.WriteLine($"station name: {station.Name} - " +
                   $"station latitude: {station.Latitude}, " +
                   $"station longitude: {station.Longitude}\n");
                    flag = 1;
                }
            });


            _model.BusesList.ForEach(bus => bus.Lines.ForEach(line => line.Station.ForEach(station =>
            {
                if (station.Name.Equals(stationName))
                {
                    Console.WriteLine($"Bus number: { bus.Id}\n" +
                         $"Bus driver name: {bus.Driver.FirstName} {bus.Driver.LastName}\n" +
                         $"Bus line: {line.LineName}\n" +
                         $"Bus occupancy: {bus.Occupancy}\n" +
                         $"Bus type: {bus.Type}\n\n ");
                }
            })));

            if (flag == 0)
            {
                Console.WriteLine($"The station {stationName} is not exist!\n");
            }
        }

        public void PrintDrivers()
        {
            int i = 1;
            foreach (Driver driver in _model.DriverList)
            {
                Console.WriteLine(i + ". " + driver);
                i++;
            }
        }

        public void PrintLines()
        {
            int i = 1;
            foreach (Line line in _model.LineList)
            {
                Console.WriteLine(i + ". " + line);
                i++;
            }
        }

        public void PrintStations()
        {
            int i = 1;
            foreach (Station station in _model.StationList)
            {
                Console.WriteLine(i + ". " + station);
                i++;
            }
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
