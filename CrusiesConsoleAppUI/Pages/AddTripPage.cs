using CrusiesAppDataAccess.Factory;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            HelperMethods.HelperMethods.DisplayPageHeader("Add Trip");

            string tripName = HelperMethods.HelperMethods.GetValidName("Name", "Trip");
            int costOfTrip = HelperMethods.HelperMethods.GetValidInt("Enter the Cost of the Trip");

            HelperMethods.HelperMethods.DisplayEditingOptions("confirmOrCancel");

            switch (HelperMethods.HelperMethods.GetItemInRange(1, 2, $"Are you sure you would like to add {tripName} to {_port.Name}?"))
            {
                case 1:

                    _port.AddTrip(ModelFactory.CreateTrip(tripName, costOfTrip));
                    TripModel newTrip = _port.Trips.Where(t => t.NameOfActivity == tripName).FirstOrDefault()!;

                    _dataManager.AddTripToPort(
                        "C:\\Users\\ssmal\\source\\repos\\CrusiesConsoleApp\\CruisesAppLibrary\\XML Files\\Cruises1.xml",
                        _cruise.CruiseIdentifier,
                        _port.PortId.ToString(), newTrip) ;

                    HelperMethods.HelperMethods.ReturnToMainMenu($"Your Trip Has Been Successfully Added to {_port.Name}");
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _page.DisplayContent();
                    break;

                case 2:
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _pageStore.CurrentPage = _page;
                    _page.DisplayContent();
                    break;

            }
        }
    }
}
