using CrusiesAppDataAccess.Factory;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CrusiesConsoleAppUI.Pages
{
    public class AddCruisePage : IBasePage
    {
        IUserModel _admin;
        IBasePage _page;
        IPageStore _pageStore;
        IDataManager _dataManager;
        

        public AddCruisePage(IUserModel admin, IBasePage page, IPageStore pageStore, IDataManager dataManager)
        {
            _admin = admin;
            _page = page;
            _pageStore = pageStore;   
            _dataManager = dataManager;
        }
        public void DisplayContent()
        {
            Console.Clear();
            HelperMethods.HelperMethods.DisplayPageHeader("Add Cruise");

            string cruiseName = HelperMethods.HelperMethods.GetValidName("Name","Cruise");

            string portName = HelperMethods.HelperMethods.GetValidName("Name","Port");
            int lengthOfStay = HelperMethods.HelperMethods.GetValidInt("Enter the duration of the stay at this port");

            PortModel newPort = ModelFactory.CreatePort(portName, lengthOfStay);

            string passengerFirstName = HelperMethods.HelperMethods.GetValidName("First Name","Passenger");
            string passengerLastName = HelperMethods.HelperMethods.GetValidName("Last Name", "Passenger");

            PassengerModel newPassenger = ModelFactory.CreatePassenger(passengerFirstName, passengerLastName);


            CruiseModel newCruise = ModelFactory.CreateCruise(cruiseName);

            newCruise.AddPort(newPort);
            newCruise.AddPassenger(newPassenger);
            _admin.AddCruise(newCruise);
            HelperMethods.HelperMethods.ReturnToMainMenu($"Your Cruise Has Been Successfully Added to {_admin.DisplayName}'s List od Cruises");
            _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
            _page.DisplayContent();


        }
    }
}
