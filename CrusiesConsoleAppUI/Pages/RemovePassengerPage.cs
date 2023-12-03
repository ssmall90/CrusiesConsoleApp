using CruisesAppDataAccess;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using Spectre.Console;

namespace CrusiesConsoleAppUI.Pages
{
    public class RemovePassengerPage : IBasePage
    {
        IUserModel _admin;
        IDataManager _dataManager;
        IBasePage _page;
        IPageStore _pageStore;
        CruiseModel _cruise;

        public RemovePassengerPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            _admin = admin;
            _dataManager = dataManager;
            _page = page;
            _pageStore = pageStore;
            _cruise = cruise;

        }
        public void DisplayContent()
        {
            Console.Clear();
            AnsiConsole.Write(SpectreHelper.DisplayHeader("Remove Passenger Page"));

            AnsiConsole.Write(SpectreHelper.DisplayPassengerTable(_cruise.Passengers, $"{_cruise.CruiseName} Passengers"));

            if (_cruise.Passengers.Count > 0)
            {
                int selectedPassenger = SpectreHelper.GetSelection(_cruise.Passengers, "[Blue]Which Passenger Would You Like To Remove[/]");

                Console.Clear();

                AnsiConsole.Write(SpectreHelper.DisplayPassenger(_cruise.Passengers[selectedPassenger - 1]));

                int selectedOption = SpectreHelper.GetSelection(new List<string> { "Confirm" }, "Option");

                switch (selectedOption)
                {
                    case 1:
                        _dataManager.RemovePassengerFromCruise(FilePathConstants.ConstructPath(), _cruise.CruiseIdentifier, _cruise.Passengers[selectedPassenger - 1].PassportNumber);
                        _cruise.RemovePassenger(_cruise.Passengers[selectedPassenger - 1]);

                        SpectreHelper.ReturnToMainMenu("The Selected Passenger Has Been Removed From The Cruise", "green");

                        _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                        _page.DisplayContent();
                        break;

                    case 2:
                        SpectreHelper.ReturnToMainMenu("The Selected Passenger Has Not Been Removed From The Cruise", "red3");

                        _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                        _page.DisplayContent();
                        break;
                }
            }
            else
            {
                SpectreHelper.ReturnToMainMenu("The Selected Cruise Does Not Have Any Passengers", "red3");

                _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                _page.DisplayContent();
            }
           

        }
    }
}
