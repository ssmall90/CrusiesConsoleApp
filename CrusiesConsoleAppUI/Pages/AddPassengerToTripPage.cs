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
                    alreadyOnTrip = true; break;
                    
                }

            }

            if(alreadyOnTrip == false)
            {
                _port.Trips[selectedTrip - 1].AttendingPassengers.Add(_cruise.Passengers[selectedPassenger - 1]);
                HelperMethods.HelperMethods.ReturnToMainMenu("passenger has been added to trip");
                foreach(var passenger in _port.Trips[selectedTrip - 1].AttendingPassengers)
                {
                    Console.WriteLine(passenger.FirstName + passenger.PassportNumber);
                }
            }


        }
    }
}
