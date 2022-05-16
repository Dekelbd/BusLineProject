using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace Server
{
    public class BusService : IBusService
    {
        List<Bus> busesList = new List<Bus>();
        List<Driver> driverList = new List<Driver>();
        List<Station> stationList = new List<Station>();
        List<Line> lineList = new List<Line>();

        public bool AddBus(int id, String linesNumbers, int driverNum, int occupancy, int type)
        {
            for (int i = 0; i < busesList.Count; i++)
            {
                if (busesList[i].Id == id)
                {
                    Console.WriteLine($"Bus number id {id} is already exist! c'ant create duplicate buses\n");
                    return false;
                }
            }
            Driver driver = driverList[driverNum - 1];
            List<Line> lines = new List<Line>();
            string[] numbers = linesNumbers.Split(',');
            foreach (String number in numbers)
            {
                int num = int.Parse(number) - 1;
                lines.Add(lineList[num]);
            }
            Bus bus = new Bus(id, lines, driver, occupancy, (type == 1) ? BusType.trips : BusType.communal);
            if (bus == null)
            {
                return false;
            }
            busesList.Add(bus);
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
            driverList.Add(driver);
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
                stations.Add(stationList[num]);
            }
            Line line = new Line(lineName, stations);
            if (line == null)
            {
                return false;
            }
            lineList.Add(line);
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
            stationList.Add(station);
            Console.WriteLine("Station add successfully!\n");
            return true;
        }

        public void GetBusInfo(int id)
        {
            bool found = false;
            for (int i = 0; i < busesList.Count; i++)
            {
                if (busesList[i].Id == id)
                {
                    for (int j = 0; j < busesList[i].Lines.Count; j++)
                    {
                        Console.WriteLine($"Bus number: { busesList[i].Id}\n" +
                            $"Bus driver name: {busesList[i].Driver.FirstName} {busesList[i].Driver.LastName}\n" +
                            $"Bus line: {busesList[i].Lines[j].LineName}\n" +
                            $"Bus occupancy: {busesList[i].Occupancy}\n" +
                            $"Bus type: {busesList[i]._Type}\n\n ");
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
            for (int i = 0; i < lineList.Count; i++)
            {
                if (lineList[i].LineName == lineName)
                {
                    Console.WriteLine($"Line name: {lineList[i].LineName}");
                    flag = 1;
                }
            }

            for (int i = 0; i < busesList.Count; i++)
            {
                for (int k = 0; k < busesList[i].Lines.Count; k++)
                {
                        if (busesList[i].Lines[k].LineName == lineName)
                        {
                            Console.WriteLine($"Bus number: { busesList[i].Id}\n" +
                                $"Bus driver name: {busesList[i].Driver.FirstName} {busesList[i].Driver.LastName}\n" +
                                $"Bus line: {busesList[i].Lines[k].LineName}\n" +
                                $"Bus occupancy: {busesList[i].Occupancy}\n" +
                                $"Bus type: {busesList[i]._Type}\n\n ");
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
            for (int i = 0; i < stationList.Count; i++)
            {
                if (stationList[i].Name == stationName)
                {
                    Console.WriteLine($"station name: {stationList[i].Name} - " +
                        $"station latitude: {stationList[i].Latitude}, " +
                        $"station longitude: {stationList[i].Longitude}\n");
                    flag = 1;
                }
            }

            for (int i = 0; i < busesList.Count; i++)
            {
                for (int k = 0; k < busesList[i].Lines.Count; k++)
                {
                    for (int j = 0; j < busesList[i].Lines[k].Stations.Count; j++)
                    {
                        if (busesList[i].Lines[k].Stations[j].Name == stationName)
                        {
                            Console.WriteLine($"Bus number: { busesList[i].Id}\n" +
                                $"Bus driver name: {busesList[i].Driver.FirstName} {busesList[i].Driver.LastName}\n" +
                                $"Bus line: {busesList[i].Lines[k].LineName}\n" +
                                $"Bus occupancy: {busesList[i].Occupancy}\n" +
                                $"Bus type: {busesList[i]._Type}\n\n ");
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
            foreach (Driver driver in driverList)
            {
                Console.WriteLine(i + ". " + driver);
                i++;
            }
        }

        public void PrintLines()
        {
            int i = 1;
            foreach (Line line in lineList)
            {
                Console.WriteLine(i + ". " + line);
                i++;
            }
        }

        public void PrintStations()
        {
            int i = 1;
            foreach (Station station in stationList)
            {
                Console.WriteLine(i + ". " + station);
                i++;
            }
        }
    }
}
