using CruisesAppDataAccess;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using Spectre.Console;


namespace CrusiesConsoleAppUI.Pages
{
    public class RemovePassengerFromTripPage : IBasePage
    {
        IUserModel _admin;
        IBasePage _page;
        IPageStore _pageStore;
        IDataManager _dataManager;
        PortModel _port;
        CruiseModel _cruise;

        public RemovePassengerFromTripPage(IUserModel admin, IBasePage page, CruiseModel cruise, PortModel port, IPageStore pageStore, IDataManager dataManager)
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
            AnsiConsole.MarkupLine(SpectreHelper.DisplayHeader("Remove Passenger From Trip"));

            AnsiConsole.Write(SpectreHelper.DisplayTripTable(_port.Trips,$"{_port.Name} Trips"));

            AnsiConsole.WriteLine();

            if (_port.Trips.Count > 0)
            {
                AnsiConsole.WriteLine();

                int selectedTrip = SpectreHelper.GetSelection(_port.Trips, "Which Trip Would You Like To Remove A Passenger From?");

                if(selectedTrip <= _port.Trips.Count)
                {
                    if (_port.Trips[selectedTrip - 1].AttendingPassengers.Count < 1 || _port.Trips[selectedTrip - 1].AttendingPassengers == null)
                    {
                        SpectreHelper.ReturnToMainMenu("There is Currently No Passengers Booked On To This Trip.", "red3");

                        _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                        _page.DisplayContent();
                    }
                    else
                    {

                        Console.Clear();

                        AnsiConsole.MarkupLine(SpectreHelper.DisplayHeader($"{_port.Trips[selectedTrip - 1].NameOfActivity}"));

                        AnsiConsole.WriteLine();

                        AnsiConsole.Write(SpectreHelper.DisplayTrip(_port.Trips[selectedTrip - 1]));

                        int selectedPassenger = SpectreHelper.GetSelection(_port.Trips[selectedTrip - 1].AttendingPassengers, "Which Passenger Would You Like To Remove From This Trip");

                        _dataManager.RemovePassengerFromTrip(FilePathConstants.ConstructPath(), _cruise.CruiseIdentifier, _port.PortId, _port.Trips[selectedTrip - 1].ActivityId, _port.Trips[selectedTrip - 1].AttendingPassengers[selectedPassenger - 1].PassportNumber);
                        _port.Trips[selectedTrip - 1].AttendingPassengers.RemoveAt(selectedPassenger - 1);

                        SpectreHelper.ReturnToMainMenu("Passenger Has Been Removed From Trip", "green");

                        _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                        _page.DisplayContent();

                    }
                }
                else
                {
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
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
