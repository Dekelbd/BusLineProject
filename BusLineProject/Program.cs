using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server;

namespace ConsoleApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            IBusService busService = new BusService();
            busService.ReadFromXml();

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
                Console.WriteLine("6. Get station info");
                Console.WriteLine("7. Get bus info");
                Console.WriteLine("8. Write to file");
                Console.WriteLine("9. Exit");

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
                        busService.PrintDrivers();
                        Console.Write("Driver number: ");
                        int driver = int.Parse(Console.ReadLine());
                        busService.PrintLines();
                        Console.Write("Enter lines list: ");
                        string linesList = Console.ReadLine();
                        busService.AddBus(id, linesList, driver, occupancy, type);
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
                        busService.AddDriver(firstName, lastName, address, phoneNumber);
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
                        busService.AddStation(stationName, latitude, longitude);
                        break;
                    #endregion
                    #region Add line
                    case 4:
                        Console.Write("Line name: ");
                        string lineName = Console.ReadLine();
                        busService.PrintStations();
                        Console.Write("Enter stations list: ");
                        string stationsList = Console.ReadLine();
                        busService.AddLine(lineName, stationsList);
                        break;
                    #endregion
                    #region Get line
                    case 5:
                        Console.Write("Line name: ");
                        string getLineName = Console.ReadLine();
                        busService.GetLineInfo(getLineName);
                        break;
                    #endregion
                    #region Get station
                    case 6:
                        Console.Write("Station name: ");
                        string stationNameInfo = Console.ReadLine();
                        busService.GetStationInfo(stationNameInfo);
                        break;
                    #endregion
                    #region Get bus
                    case 7:
                        Console.Write("Bus number: ");
                        int busNumberInfo = int.Parse(Console.ReadLine());
                        busService.GetBusInfo(busNumberInfo);
                        break;
                    #endregion
                    #region Write to xml
                    case 8:
                        busService.WriteToXml();
                        Console.WriteLine("Info save\n");
                        break;
                    #endregion
                    #region Exit from switch
                    case 9:
                        Console.WriteLine("Goodbye ..\n");
                        break;
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

