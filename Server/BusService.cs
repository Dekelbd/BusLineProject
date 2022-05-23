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
//using System.Collections.Generic;


namespace Server
{
    public class BusService : IBusService
    {
        #region Fileds

        BusModel _model = new BusModel();
        #endregion

        public BusService()
        {
            LoadData();
        }

        private void LoadData()
        {
            /*
            if (_model == null)
            {
                if (ConfigurationManager.AppSettings["SavingDataFormat"] == "InMemory")
                {
                    Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                    _model = CreateMockData();
                }
                else if(ConfigurationManager.AppSettings["SavingDataFormat"] == "File")
                {
                    Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
                    //const string xmlfile = @"C:\Users\DEKELBE\source\repos\BusLineProject\TransportConfiguration.xml";
                    //XDocument xdoc = XDocument.Load(xmlfile);
                    //var xroot = xdoc.Root;
                    //var chilnodes = xdoc.Root.Descendants();
                    //foreach (var chilnode in chilnodes)
                    //{
                    //    Console.WriteLine(chilnode);
                    //}

                }

            }*/

        }

        private BusModel CreateMockData()
        {
            // write here some default info
            return new BusModel();
        }

        //Filestream.Close();

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
            foreach (String number in numbers)
            {
                int num = int.Parse(number) - 1;
                lines.Add(_model.LineList[num]);
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
            for (int i = 0; i < _model.BusesList.Count; i++)
            {
                if (_model.BusesList[i].Id == id)
                {
                    for (int j = 0; j < _model.BusesList[i].Lines.Count; j++)
                    {
                        Console.WriteLine($"Bus number: { _model.BusesList[i].Id}\n" +
                            $"Bus driver name: {_model.BusesList[i].Driver.FirstName} {_model.BusesList[i].Driver.LastName}\n" +
                            $"Bus line: {_model.BusesList[i].Lines[j].LineName}\n" +
                            $"Bus occupancy: {_model.BusesList[i].Occupancy}\n" +
                            $"Bus type: {_model.BusesList[i]._Type}\n\n ");
                    }
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Bus not found!!!");
            }
        }

        public void GetLineInfo(string lineName)
        {
            int flag = 0;
            for (int i = 0; i < _model.LineList.Count; i++)
            {
                if (_model.LineList[i].LineName == lineName)
                {
                    Console.WriteLine($"Line name: {_model.LineList[i].LineName}");
                    flag = 1;
                }
            }

            for (int i = 0; i < _model.BusesList.Count; i++)
            {
                for (int k = 0; k < _model.BusesList[i].Lines.Count; k++)
                {
                        if (_model.BusesList[i].Lines[k].LineName == lineName)
                        {
                            Console.WriteLine($"Bus number: { _model.BusesList[i].Id}\n" +
                                $"Bus driver name: {_model.BusesList[i].Driver.FirstName} {_model.BusesList[i].Driver.LastName}\n" +
                                $"Bus line: {_model.BusesList[i].Lines[k].LineName}\n" +
                                $"Bus occupancy: {_model.BusesList[i].Occupancy}\n" +
                                $"Bus type: {_model.BusesList[i]._Type}\n\n ");
                        }                 
                }
            }
            if (flag == 0)
            {
                Console.WriteLine($"The line {lineName} is not exist!\n");
            }
        }

        public void GetStationInfo(string stationName)
        {
            int flag = 0;
            for (int i = 0; i < _model.StationList.Count; i++)
            {
                if (_model.StationList[i].Name == stationName)
                {
                    Console.WriteLine($"station name: {_model.StationList[i].Name} - " +
                        $"station latitude: {_model.StationList[i].Latitude}, " +
                        $"station longitude: {_model.StationList[i].Longitude}\n");
                    flag = 1;
                }
            }

            for (int i = 0; i < _model.BusesList.Count; i++)
            {
                for (int k = 0; k < _model.BusesList[i].Lines.Count; k++)
                {
                    for (int j = 0; j < _model.BusesList[i].Lines[k].Stations.Count; j++)
                    {
                        if (_model.BusesList[i].Lines[k].Stations[j].Name == stationName)
                        {
                            Console.WriteLine($"Bus number: { _model.BusesList[i].Id}\n" +
                                $"Bus driver name: {_model.BusesList[i].Driver.FirstName} {_model.BusesList[i].Driver.LastName}\n" +
                                $"Bus line: {_model.BusesList[i].Lines[k].LineName}\n" +
                                $"Bus occupancy: {_model.BusesList[i].Occupancy}\n" +
                                $"Bus type: {_model.BusesList[i]._Type}\n\n ");
                        }
                    }
                }
            }
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
       
        public void AddAllToXml()
            {
                var serializerBus = new XmlSerializer(typeof(List<Bus>));
                ////using (var writerBus = new StreamWriter(@"C:\Users\dekel\source\repos\BusLineProject\Model\Configuration\TransportConfiguration.xml"))
                using (var writerBus = new StreamWriter("TransportConfiguration.xml"))
                {
                    serializerBus.Serialize(writerBus, _model.BusesList);
                    writerBus.Close();
                }

            var serializerDriver = new XmlSerializer(typeof(List<Driver>));
            //using (var writerDriver = new StreamWriter("C:\Users\dekel\source\repos\BusLineProject\Model\Configuration\Driver.xml"))
            using (var writerDriver = new StreamWriter("Driver.xml"))
            {
                serializerDriver.Serialize(writerDriver, _model.DriverList);
                writerDriver.Close();
            }

            var serializerLine = new XmlSerializer(typeof(List<Line>));
            //using (var writerLine = new StreamWriter(@"C:\Users\dekel\source\repos\BusLineProject\Model\Configuration\Line.xml"))
            using (var writerLine = new StreamWriter("Line.xml"))
            {
                serializerLine.Serialize(writerLine, _model.LineList);
                writerLine.Close();
            }

            var serializerStation = new XmlSerializer(typeof(List<Station>));
            using (var writerStation = new StreamWriter("Station.xml"))
            //using (var writerStation = new StreamWriter(@"C:\Users\dekel\source\repos\BusLineProject\Model\Configuration\Station.xml"))
            {
                serializerStation.Serialize(writerStation, _model.StationList);
                writerStation.Close();
            }
        }

        public void LoadAllFromXml()
        {
            //var filepath = @"C:\Users\dekel\source\repos\BusLineProject\TransportConfiguration.xml";
            var filepath = "TransportConfiguration.xml";
            XmlSerializer serializerBus = new XmlSerializer(typeof(List<Bus>));
                using (FileStream fs = new FileStream(filepath, FileMode.Open))
                {
                _model.BusesList = (List<Bus>)serializerBus.Deserialize(fs);
                fs.Close();
                }
            filepath = "Line.xml";
            XmlSerializer serializerLine = new XmlSerializer(typeof(List<Line>));
            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                _model.LineList = (List<Line>)serializerLine.Deserialize(fs);
                fs.Close();
            }

            filepath = "Driver.xml";
            XmlSerializer serializerDriver = new XmlSerializer(typeof(List<Driver>));
            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                _model.DriverList = (List<Driver>)serializerDriver.Deserialize(fs);
                fs.Close();
            }

            filepath = "Station.xml";
            XmlSerializer serializerStation = new XmlSerializer(typeof(List<Station>));
            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                _model.StationList = (List<Station>)serializerStation.Deserialize(fs);
                fs.Close();
            }

        }
    }
}
