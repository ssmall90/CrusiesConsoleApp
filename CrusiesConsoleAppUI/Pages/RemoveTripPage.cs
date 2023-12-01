using CruisesAppDataAccess;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;

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
            HelperMethods.HelperMethods.DisplayPageHeader($"Choose Trip");
            HelperMethods.HelperMethods.DisplayList(_port.Trips, "Trips");
            int selectedTrip = HelperMethods.HelperMethods.GetItemInRange(1, _port.Trips.Count, "Which Trip Do You Want to Remove?");

            HelperMethods.HelperMethods.DisplayEditingOptions("confirmOrCancel");

            switch (HelperMethods.HelperMethods.GetItemInRange(1, 2, $"Are you sure you want to delete {_port.Trips[selectedTrip - 1]}"))
            {
                case 1:
                    _dataManager.RemoveTripFromPort(FilePathConstants.ConstructPath(), _port.Trips[selectedTrip - 1].ActivityId);
                    _port.RemoveTrip(_port.Trips[selectedTrip - 1]);
                    HelperMethods.HelperMethods.ReturnToMainMenu("The Selected Trip Has Been Removed From the Port");
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _page.DisplayContent();
                    break;

                case 2:
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _page.DisplayContent();
                    break;
            }
      
        }
    }
}