using CruisesAppDataAccess;
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
            HelperMethods.HelperMethods.DisplayPageHeader("Remove Passenger From Trip");

            HelperMethods.HelperMethods.DisplayList(_port.Trips, "Trips"); 
            int selectedTrip = HelperMethods.HelperMethods.GetItemInRange(1, _port.Trips.Count, "Which Trip Do You Want to Remove A Passenger From?");


            if(_port.Trips[selectedTrip - 1].AttendingPassengers.Count < 1 || _port.Trips[selectedTrip - 1].AttendingPassengers == null)
            {
                Console.WriteLine("There is Currently No Passengers Booked on to This Trip. Press Enter to Return to Previous Page");
                Console.ReadKey();
                _page = PageFactory.CreateSelectPortToEditPage(_admin, _page, _cruise, _pageStore, _dataManager);
                _page.DisplayContent();
            }
            else
            {
                HelperMethods.HelperMethods.DisplayList(_port.Trips[selectedTrip - 1].AttendingPassengers, "Passengers");
                int selectedPassenger = HelperMethods.HelperMethods.GetItemInRange(1, _port.Trips[selectedTrip - 1].AttendingPassengers.Count, "Which Passenger Would you Like to Remove From This Trip?");

                _dataManager.RemovePassengerFromTrip(FilePathConstants.ConstructPath(), _cruise.CruiseIdentifier, _port.PortId, _port.Trips[selectedTrip - 1].ActivityId, _port.Trips[selectedTrip - 1].AttendingPassengers[selectedPassenger - 1].PassportNumber);
                _port.Trips[selectedTrip - 1].AttendingPassengers.RemoveAt(selectedPassenger-1);

                HelperMethods.HelperMethods.ReturnToMainMenu("Passenger Has Been Removed From Trip");
                _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                _page.DisplayContent();



            }

        }
    }
}
