using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Interfaces;
using Server;

namespace ConsoleApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            //IBusService busService = new BusService();
            Bus busInfo;
            Station stationLocationInfo;
            List<Bus> busLineInfo = new List<Bus>();
            List<Bus> busByStationInfo = new List<Bus>();
            List<Driver> allDriver = new List<Driver>();
            List<Line> allLines = new List<Line>();
            List<Station> allStation = new List<Station>();
            //busService.ReadFromXml();
            BusService.Instance.ReadFromXml();

            Console.WriteLine("Hello and welcome to the bus management system!\n");

            #region Switch case
            int menuchoice = 0;
            while (menuchoice != 9)
            {
                Console.WriteLine("Please select the option you want to do:\n");
                Console.WriteLine("1. Adding a new bus");
                Console.WriteLine("2. Adding a new driver");
                Console.WriteLine("3. Adding a new station");
                Console.WriteLine("4. Adding a new line");
                Console.WriteLine("5. Get line info");
                Console.WriteLine("6. Get bus info by station");
                Console.WriteLine("7. Get station location");
                Console.WriteLine("8. Get bus info");
                Console.WriteLine("9. Write to file");
                Console.WriteLine("10. Exit");

                menuchoice = int.Parse(Console.ReadLine());

                switch (menuchoice)
                {
                    #region Add bus
                    case 1:
                        Console.WriteLine("Bus information:");
                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Occupancy: ");
                        int occupancy = int.Parse(Console.ReadLine());
                        Console.Write("Bus Type (1. trips, 2. communal): ");
                        int type = int.Parse(Console.ReadLine());
                        allDriver = BusService.Instance.GetDrivers();
                        int i = 1;
                        foreach (Driver printDriver in allDriver)
                        {
                            Console.WriteLine(i + ". " + printDriver);
                            i++;
                        }
                        Console.Write("Driver number: ");
                        int driver = int.Parse(Console.ReadLine());
                        allLines = BusService.Instance.PrintLines();
                        int j = 1;
                        foreach (Line printLine in allLines)
                        {
                            Console.WriteLine(j + ". " + printLine);
                            j++;
                        }
                        Console.Write("Enter lines list: ");
                        string linesList = Console.ReadLine();
                        int option = BusService.Instance.AddBus(id, linesList, driver, occupancy, type);
                        if (option == 1)
                        {
                            Console.WriteLine("Driver not found");
                        } else if (option == 2)
                        {
                            Console.WriteLine($"Bus number id {id} is already exist! c'ant create duplicate buses\n");
                        } else if (option == 4)
                        {
                            Console.WriteLine("Bus add successfully!\n");
                        }
                        break;
                    #endregion
                    #region Add driver
                    case 2:
                        Console.WriteLine("Driver information:");
                        Console.Write("Firstname: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Lastname: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Address: ");
                        string address = Console.ReadLine();
                        Console.Write("Phone number: ");
                        string phoneNumber = Console.ReadLine();
                        if (BusService.Instance.AddDriver(firstName, lastName, address, phoneNumber) == true)
                        {
                            Console.WriteLine("Driver add successfully!\n");
                        };
                        break;
                    #endregion
                    #region Add station
                    case 3:
                        Console.WriteLine("Station information:");
                        Console.Write("Station name: ");
                        string stationName = Console.ReadLine();
                        Console.Write("Latitude: ");
                        double latitude = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Longitude: ");
                        double longitude = Convert.ToDouble(Console.ReadLine());
                        if (BusService.Instance.AddStation(stationName, latitude, longitude) == true)
                        {
                            Console.WriteLine("Station add successfully!\n");
                        };
                        break;
                    #endregion
                    #region Add line
                    case 4:
                        Console.Write("Line name: ");
                        string lineName = Console.ReadLine();
                        allStation = BusService.Instance.PrintStations();
                        int k = 1;
                        foreach (Station printStation in allStation)
                        {
                            Console.WriteLine(k + ". " + printStation);
                            k++;
                        }
                        Console.Write("Enter stations list: ");
                        string stationsList = Console.ReadLine();
                        if (BusService.Instance.AddLine(lineName, stationsList) == true)
                        {
                            Console.WriteLine("Line add successfull!\n");
                        };
                        break;
                    #endregion
                    #region Get line
                    #region Get line
                    case 5:
                        Console.Write("Enter start station and end station \naccording to the following example : Haifa,Tel Aviv \n");
                        string getLineName = Console.ReadLine();
                        busLineInfo = BusService.Instance.GetBusByLine(getLineName);
                        if (busLineInfo == null)
                        {
                            Console.WriteLine($"The line {getLineName} is not exist!\n");
                        } else
                        {
                            busLineInfo.ForEach(bus =>
                            {
                                Console.WriteLine($"Bus number: { bus.Id}\n" +
                                $"Bus driver name: {bus.Driver.FirstName} {bus.Driver.LastName}\n" +
                                $"Bus occupancy: {bus.Occupancy}\n" +
                                $"Bus type: {bus.Type}\n\n ");
                            });
                        }
                        break;
                    #endregion
                    #region Get bus by station
                    case 6:
                        Console.Write("Station name: ");
                        string stationNameInfo = Console.ReadLine();
                        busByStationInfo = BusService.Instance.GetBusByStation(stationNameInfo);
                        if (busByStationInfo != null)
                        {
                            busByStationInfo.ForEach(bus => bus.Lines.ForEach(line =>
                            {
                                Console.WriteLine($"Bus number: { bus.Id}\n" +
                                $"Bus driver name: {bus.Driver.FirstName} {bus.Driver.LastName}\n" +
                                $"Bus line: {line.LineName}\n" +
                                $"Bus occupancy: {bus.Occupancy}\n" +
                                $"Bus type: {bus.Type}\n\n ");
                            }));
                        }
                        else
                        {
                            Console.WriteLine("There are no buses passing through this station");
                        }

                        break;
                    #endregion
                    #region Get station location
                    case 7:
                        Console.Write("Station name: ");
                        string stationLocation = Console.ReadLine();
                        stationLocationInfo = BusService.Instance.GetStationLocation(stationLocation);
                        if (stationLocationInfo != null)
                        {
                            Console.WriteLine($"station name: {stationLocationInfo.Name} - " +
                            $"station latitude: {stationLocationInfo.Latitude}, " +
                            $"station longitude: {stationLocationInfo.Longitude}\n");
                        }
                        else
                        {
                            Console.WriteLine($"The station {stationLocation} is not exist!\n");
                        }
                        break;
                    #endregion
                    #region Get bus
                    case 8:
                        Console.Write("Bus number: ");
                        int busNumberInfo = int.Parse(Console.ReadLine());
                        busInfo = BusService.Instance.GetBusInfo(busNumberInfo);
                        if (busInfo == null)
                        {
                            Console.WriteLine("Bus not found!");
                        }
                        else
                        {
                            busInfo.Lines.ForEach(line =>
                            {
                                Console.WriteLine($"Bus number: { busInfo.Id}\n" +
                                  $"Bus driver name: {busInfo.Driver.FirstName} {busInfo.Driver.LastName}\n" +
                                  $"Bus line: {line.LineName}\n" +
                                  $"Bus occupancy: {busInfo.Occupancy}\n" +
                                  $"Bus type: {busInfo.Type}\n\n ");
                            });
                        }
                        break;
                    #endregion
                    #region Write to xml
                    case 9:
                        BusService.Instance.WriteToXml();
                        Console.WriteLine("Info save\n");
                        break;
                    #endregion
                    #region Exit from switch
                    case 10:
                        Console.WriteLine("Goodbye ..\n");
                        return;
                    #endregion
                    #region Invalid selection
                    default:
                        Console.WriteLine("Sorry, invalid selection\n");
                        break;
                        #endregion
                }
            }
            #endregion
        }
    }
}
#endregion
