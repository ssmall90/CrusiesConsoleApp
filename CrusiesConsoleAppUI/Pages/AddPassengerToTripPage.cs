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
            HelperMethods.HelperMethods.DisplayPageHeader("Add Passenger To Trip");
            HelperMethods.HelperMethods.DisplayList(_port.Trips, "Trips");
            int selectedTrip = HelperMethods.HelperMethods.GetItemInRange(1, _port.Trips.Count, "Which Trip Do You Want to Add the Passenger To?");

            HelperMethods.HelperMethods.DisplayList(_cruise.Passengers, "Passengers");
            int selectedPassenger = HelperMethods.HelperMethods.GetItemInRange(1, _port.Trips.Count, "Which Passenger Would you Like to Add to This Trip?");
            bool alreadyOnTrip = false;

            foreach ( var passenger in _port.Trips[selectedTrip -1].AttendingPassengers )
            {

                if(_cruise.Passengers[selectedPassenger - 1].PassportNumber == passenger.PassportNumber)
                {
                    alreadyOnTrip = true;
                    Console.WriteLine($"The Selected Passenger {_cruise.Passengers[selectedPassenger - 1].FirstName} is Already Booked On This Trip \n\rPress Enter To Return To Previous Menu");
                    Console.ReadKey();
                    _page = PageFactory.CreateSelectPortToEditPage(_admin, _page, _cruise, _pageStore, _dataManager);
                    _page.DisplayContent();
                    break;
                    
                }

            }

            if(!alreadyOnTrip)
            {
                _dataManager.AddPassengerToTrip("C:\\Users\\ssmal\\Source\\Repos\\CrusiesConsoleApp\\CruisesAppLibrary\\XML Files\\Cruises1.xml", _cruise.CruiseIdentifier, _port.PortId, _port.Trips[selectedTrip - 1].ActivityId, _cruise.Passengers[selectedPassenger - 1]);
                _port.Trips[selectedTrip - 1].AttendingPassengers.Add(_cruise.Passengers[selectedPassenger - 1]);
                HelperMethods.HelperMethods.ReturnToMainMenu("Passenger Has Been Added To Trip");
                _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                _page.DisplayContent();

            }


        }
    }
}
