using CruisesAppDataAccess;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using Spectre.Console;

namespace CrusiesConsoleAppUI.Pages
{
    public class AddPassengerToTripPage : IBasePage
    {
        IUserModel _admin;
        IBasePage _page;
        IPageStore _pageStore;
        IDataManager _dataManager;
        PortModel _port;
        CruiseModel _cruise;

        public AddPassengerToTripPage(IUserModel admin, IBasePage page, CruiseModel cruise, PortModel port, IPageStore pageStore, IDataManager dataManager)
        {
            _admin = admin;
            _page = page;
            _cruise = cruise;
            _port = port;
            _pageStore = pageStore;
            _dataManager = dataManager;
        }

        public void DisplayContent()
        {
            Console.Clear();
            AnsiConsole.MarkupLine(SpectreHelper.DisplayHeader("Add Passenger To Trip Page"));




            if (_port.Trips.Count > 0)
            {
                AnsiConsole.Write(SpectreHelper.DisplayTripTable(_port.Trips, $"{_port.Name} Trips"));

                int selectedTrip = SpectreHelper.GetSelection(_port.Trips, "[dodgerblue2]Which Trip Would You Like To Add A Passenger To[/]");


                if (_cruise.Passengers.Count > 0)
                {

                    Console.Clear();
                    AnsiConsole.Write(SpectreHelper.DisplayPassengerTable(_port.Trips[selectedTrip - 1].AttendingPassengers, $"Passengers Attending {_port.Trips[selectedTrip - 1].NameOfActivity}"));

                    int selectedPassenger = SpectreHelper.GetSelection(_cruise.Passengers, $"[dodgerblue2]Which Passenger Would You Like To Add To {_port.Trips[selectedTrip-1].NameOfActivity}[/]");

                    bool alreadyOnTrip = false;

                    foreach (var passenger in _port.Trips[selectedTrip - 1].AttendingPassengers)
                    {

                        if (_cruise.Passengers[selectedPassenger - 1].PassportNumber == passenger.PassportNumber)
                        {
                            alreadyOnTrip = true;

                            SpectreHelper.ReturnToMainMenu($"The Selected Passenger {_cruise.Passengers[selectedPassenger - 1].FirstName} is Already Booked On This Trip \n\rPress Enter To Return To Previous Menu","red3");

                            _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                            _page.DisplayContent();
                            break;

                        }

                    }

                    if (!alreadyOnTrip)
                    {
                        _dataManager.AddPassengerToTrip(FilePathConstants.ConstructPath(), _cruise.CruiseIdentifier, _port.PortId, _port.Trips[selectedTrip - 1].ActivityId, _cruise.Passengers[selectedPassenger - 1]);
                        _port.Trips[selectedTrip - 1].AttendingPassengers.Add(_cruise.Passengers[selectedPassenger - 1]);

                        Console.Clear();
                        AnsiConsole.Write(SpectreHelper.DisplayPassengerTable(_port.Trips[selectedTrip - 1].AttendingPassengers, $"Passengers Attending {_port.Trips[selectedTrip - 1].NameOfActivity}"));
                        SpectreHelper.ReturnToMainMenu("The Passenger Has Been Added To Trip", "green");

                        _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                        _page.DisplayContent();

                    }
                }
                else
                {
                    SpectreHelper.ReturnToMainMenu("There Are No Passengers Booked Onto This Cruise", "red3");
                    _page = _pageStore.CurrentPage;
                    _page.DisplayContent();
                }
                
            }
            else
            {
                SpectreHelper.ReturnToMainMenu("The Selected Port Does Not Have Any Trips", "red3");
                _page = _pageStore.CurrentPage;
                _page.DisplayContent();
            }

        }
    }
}
