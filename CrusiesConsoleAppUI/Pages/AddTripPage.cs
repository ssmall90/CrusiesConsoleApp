using CruisesAppDataAccess;
using CrusiesAppDataAccess.Factory;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using Spectre.Console;


namespace CrusiesConsoleAppUI.Pages
{
    public class AddTripPage : IBasePage
    {

        IUserModel _admin;
        IBasePage _page;
        IPageStore _pageStore;
        IDataManager _dataManager;
        PortModel _port;
        CruiseModel _cruise;

        public AddTripPage(IUserModel admin, IBasePage page, CruiseModel cruise, PortModel port, IPageStore pageStore, IDataManager dataManager)
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
            AnsiConsole.MarkupLine(SpectreHelper.DisplayHeader("Add Trip Page"));

            string tripName = HelperMethods.HelperMethods.GetValidName("Name", "Trip");
            int costOfTrip = HelperMethods.HelperMethods.GetValidInt("Enter the Cost of the Trip");

            int selectedOption = SpectreHelper.GetSelection(new List<string> { "Confirm"}, "Option");

            switch (selectedOption)
            {
                case 1:

                    _port.AddTrip(ModelFactory.CreateTrip(tripName, costOfTrip));
                    TripModel newTrip = _port.Trips.Where(t => t.NameOfActivity == tripName).FirstOrDefault()!;

                    _dataManager.AddTripToPort(FilePathConstants.ConstructPath(),_cruise.CruiseIdentifier,_port.PortId.ToString(), newTrip) ;

                    SpectreHelper.ReturnToMainMenu($"Your Trip Has Been Successfully Added to {_port.Name}", "green");
                    
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _page.DisplayContent();

                    break;

                case 2:
                    SpectreHelper.ReturnToMainMenu($"Action Aborted", "red3");

                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _pageStore.CurrentPage = _page;
                    _page.DisplayContent();

                    break;


            }
        }
    }
}
