using CruisesAppDataAccess;
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
    public class AddPassengerPage : IBasePage
    {
        IUserModel _admin;
        IDataManager _dataManager;
        IBasePage _page;
        IPageStore _pageStore;
        CruiseModel _cruise;

        public AddPassengerPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            _admin = admin;
            _dataManager = dataManager;
            _page = page;
            _pageStore = pageStore;
            _cruise = cruise;
        }
        public void DisplayContent()
        {
            bool addAnotherPassenger = true;
            string passengerFirstName = string.Empty;
            string passengerLastName = string.Empty;
            int passengerPassportNumber = 0;

            while (addAnotherPassenger)
            {
                Console.Clear();
                HelperMethods.HelperMethods.DisplayPageHeader("Add Passenger");
                passengerFirstName = HelperMethods.HelperMethods.GetValidName("First Name", "Passenger");
                passengerLastName = HelperMethods.HelperMethods.GetValidName("Last Name", "Passenger");
                passengerPassportNumber = HelperMethods.HelperMethods.GetItemInRange(1, 999999999,"Please Enter Your Passport Number. This can be no longer than 9 digits");
                HelperMethods.HelperMethods.DisplayEditingOptions("confirmOrCancel");

                switch (HelperMethods.HelperMethods.GetItemInRange(1, 2, $"Are You Sure You Would Like To Add {passengerFirstName} {passengerLastName} To This Cruise?"))
                {
                    case 1:

                        PassengerModel newPassenger = ModelFactory.CreatePassenger(passengerFirstName, passengerLastName, passengerPassportNumber);
                        _cruise.AddPassenger(newPassenger);
                        _dataManager.AddPassengersToCruise(FilePathConstants.ConstructPath(), _cruise.CruiseIdentifier, newPassenger);
                        HelperMethods.HelperMethods.DisplayEditingOptions("confirmOrCancel");
                        switch (HelperMethods.HelperMethods.GetItemInRange(1, 2, "Would You Like to Add Another Passenger?"))
                        {
                            case 1: break;
                            case 2:
                                HelperMethods.HelperMethods.ReturnToMainMenu("The Passenger/s Have Been Added To The Cruise");
                                _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager); ;
                                _page.DisplayContent();
                                addAnotherPassenger = false;
                                break;

                        }

                        //HelperMethods.HelperMethods.ReturnToMainMenu("The passenger has been added to the cruise");
                        //_page = _pageStore.CurrentPage;
                        //_page.DisplayContent();
                        break;

                    case 2:
                        _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                        _page.DisplayContent();
                        break;
                }
            }
        }
    }
}
