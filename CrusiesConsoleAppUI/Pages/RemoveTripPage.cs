using CruisesAppDataAccess;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using Spectre.Console;

namespace CrusiesConsoleAppUI.Pages
{
    public class RemoveTripPage : IBasePage
    {
        IUserModel _admin;
        IBasePage _page;
        IPageStore _pageStore;
        IDataManager _dataManager;
        PortModel _port;
        CruiseModel _cruise;

        public RemoveTripPage(IUserModel admin, IBasePage page, CruiseModel cruise, PortModel port, IPageStore pageStore, IDataManager dataManager)
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

            AnsiConsole.MarkupLine(SpectreHelper.DisplayHeader("Remove Trip"));

            AnsiConsole.Write(SpectreHelper.DisplayTripTable(_port.Trips, $"{_port.Name} Trips"));

            if(_port.Trips.Count > 0)
            {
                int selectedTrip = SpectreHelper.GetSelection(_port.Trips, "Which Trip Would You Like To Remove");

                Console.Clear();

                AnsiConsole.MarkupLine(SpectreHelper.DisplayHeader($"{_port.Trips[selectedTrip-1].NameOfActivity}"));

                AnsiConsole.WriteLine();

                AnsiConsole.Write(SpectreHelper.DisplayTrip(_port.Trips[selectedTrip - 1]));

                AnsiConsole.WriteLine();

                AnsiConsole.MarkupLine("[red3]Are You Sure You Want To Remove This Trip[/]");


                int selectedOption = SpectreHelper.GetSelection(new List<string> { "Confirm" }, "Option");

                switch (selectedOption)
                {
                    case 1:
                        _dataManager.RemoveTripFromPort(FilePathConstants.ConstructPath(), _port.Trips[selectedTrip - 1].ActivityId);
                        _port.RemoveTrip(_port.Trips[selectedTrip - 1]);

                        SpectreHelper.ReturnToMainMenu("The Selected Trip Has Been Removed From the Port", "red3");

                        _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                        _page.DisplayContent();
                        break;

                    case 2:
                        _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                        _page.DisplayContent();
                        break;
                }
            }
            else
            {
                SpectreHelper.ReturnToMainMenu("The Selected Port Does Not Have Any Trips","red3");

                _page = _pageStore.CurrentPage;
                _page.DisplayContent();
            }

        }
    }
}