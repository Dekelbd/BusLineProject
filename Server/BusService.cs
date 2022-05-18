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

        // serialiser.Serialize(Filestream,busesList);

        //Filestream.Close();

        public bool AddBus(int id, String linesNumbers, int driverNum, int occupancy, int type)
        {
            const string xmlfile = @"C:\Users\DEKELBE\source\repos\BusLineProject\TransportConfiguration.xml";
            XDocument xdoc = XDocument.Load(xmlfile);

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
            var serializer = new XmlSerializer(typeof(Bus));
            using (var writer = new StreamWriter(@"C:\Users\DEKELBE\source\repos\BusLineProject\TransportConfiguration.xml"))
            {
                serializer.Serialize(writer, bus);
                xdoc.Save(xmlfile);
            }
            //AddBusToXml(bus);
            Console.WriteLine("Bus add successfully!\n");
            return true;
        }

        public bool AddDriver(string firstName, string lastName, string address, string phoneNumber)
        {
            //const string xmlfile = @"C:\Users\DEKELBE\source\repos\BusLineProject\TransportConfiguration.xml";
            //XDocument xdoc = XDocument.Load(xmlfile);

            Driver driver = new Driver(firstName, lastName, address, phoneNumber);
            if (driver == null)
            {
                return false;
            }
            _model.DriverList.Add(driver);
            //AddDriverToXml(driver);
            var serializer = new XmlSerializer(typeof(Driver));
            using (FileStream fs = new FileStream(@"C:\Users\DEKELBE\source\repos\BusLineProject\TransportConfiguration.xml", FileMode.Append, FileAccess.Write))
            using (var writer = new StreamWriter(fs))
            {
                serializer.Serialize(writer, driver);
            }
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
            var serializer = new XmlSerializer(typeof(Line));
            using (var writer = new StreamWriter(@"C:\Users\DEKELBE\source\repos\BusLineProject\TransportConfiguration.xml"))
            {
                serializer.Serialize(writer, line);
            }
            //AddLineToXml(line);
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
            //AddStationToXml(station);
            var serializer = new XmlSerializer(typeof(Station));
            using (var writer = new StreamWriter(@"C:\Users\DEKELBE\source\repos\BusLineProject\TransportConfiguration.xml", append:true))
            {
                serializer.Serialize(writer, station);
            }
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

        public void AddBusToXml(Bus buses)
        {/*
            const string xmlfile = @"C:\Users\DEKELBE\source\repos\BusLineProject\TransportConfiguration.xml";
            XDocument xdoc = XDocument.Load(xmlfile);

                XElement xbus = new XElement("Bus",
                    new XAttribute("ID", buses.Id), new XAttribute("Lines", buses.Lines),
                    new XAttribute("Driver", buses.Driver), new XAttribute("Occupancy", buses.Occupancy),
                    new XAttribute("Type", buses._Type));
                xdoc.Root.Add(xbus);
                xdoc.Save(xmlfile);
            
        */}
        public void AddStationToXml(Station stations)
        {/*
            const string xmlfile = @"C:\Users\DEKELBE\source\repos\BusLineProject\TransportConfiguration.xml";
            XDocument xdoc = XDocument.Load(xmlfile);

                XElement xstatione = new XElement("Station",
                    new XAttribute("Name", stations.Name), new XAttribute("Latitude", stations.Latitude),
                    new XAttribute("Longitude", stations.Longitude));
                xdoc.Root.Add(xstatione);
                xdoc.Save(xmlfile); 
            
            
        */}
        public void AddLineToXml(Line lines)
        {/*
            const string xmlfile = @"C:\Users\DEKELBE\source\repos\BusLineProject\TransportConfiguration.xml";
            XDocument xdoc = XDocument.Load(xmlfile);

                XElement xline = new XElement("Line",
                    new XAttribute("Name", lines.LineName), new XAttribute("Station", lines.Stations));
                xdoc.Root.Add(xline);
                xdoc.Save(xmlfile); 

        */}
        public void AddDriverToXml(Driver drivers)
        {/*
            const string xmlfile = @"C:\Users\DEKELBE\source\repos\BusLineProject\TransportConfiguration.xml";
            XDocument xdoc = XDocument.Load(xmlfile);

                XElement xdriver = new XElement("Driver",
                    new XAttribute("FirstName", drivers.FirstName), new XAttribute("LastName", drivers.LastName),
                    new XAttribute("Address", drivers.Address), new XAttribute("PhoneNumber", drivers.PhoneNumber));
                xdoc.Root.Add(xdriver);
                xdoc.Save(xmlfile);
            
        */}

        public void AddAllToXml()
        {/*
            const string xmlfile = @"C:\Users\DEKELBE\source\repos\BusLineProject\TransportConfiguration.xml";
            XDocument xdoc = XDocument.Load(xmlfile);

            foreach (var bus in _model.BusesList)
            {
                XElement xbus = new XElement("Bus",
                    new XAttribute("ID", bus.Id), new XElement("Lines", new XElement("Line", bus.Lines.Count)),
                    new XElement("Driver", bus.Driver), new XAttribute("Occupancy", bus.Occupancy),
                    new XAttribute("Type", bus._Type));
                xdoc.Root.Add(xbus);
                xdoc.Save(xmlfile);
            }
            foreach (var driver in _model.DriverList)
            {
                XElement xdriver = new XElement("Driver",
                    new XAttribute("FirstName", driver.FirstName), new XAttribute("LastName", driver.LastName),
                    new XAttribute("Address", driver.Address), new XAttribute("PhoneNumber", driver.PhoneNumber));
                xdoc.Root.Add(xdriver);
                xdoc.Save(xmlfile);
            }
            foreach (var station in _model.StationList)
            {
                XElement xbus = new XElement("Stations", new XElement("Station",
                    new XAttribute("Name", station.Name), new XAttribute("Latitude", station.Latitude),
                    new XAttribute("Longitude", station.Longitude)));
                xdoc.Root.Add(xbus);
                xdoc.Save(xmlfile);
            }
            foreach (var line in _model.LineList)
            {
                XElement xline = new XElement("Lines",
                    new XAttribute("Name", line.LineName), new XElement("Station", line.Stations));
                xdoc.Root.Add(xline);
                xdoc.Save(xmlfile);
            }*/
        }
    }
}
