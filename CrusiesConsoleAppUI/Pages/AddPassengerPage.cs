using CruisesAppDataAccess;
using CrusiesAppDataAccess.Factory;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using Spectre.Console;

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
                AnsiConsole.MarkupLine(SpectreHelper.DisplayHeader("Add New Passenger"));

                passengerFirstName = SpectreHelper.GetValidName("First Name", "Passenger");
                passengerLastName = SpectreHelper.GetValidName("Last Name", "Passenger");
                passengerPassportNumber = SpectreHelper.GetValidInt("Please Enter Your Passport Number. This can be no longer than 9 digits", 999999999);

                if (!_admin.PassportNumbers.Contains($"PN-{passengerPassportNumber}") || _cruise.Passengers.FirstOrDefault(p => p.PassportNumber == $"PN-{passengerPassportNumber}") == null)
                {


                    AnsiConsole.MarkupLine($"[blue]Would You Like To Add This Passenger To {_cruise.CruiseName}'s Itenary[/]");

                    int selectedOption = SpectreHelper.GetSelection(new List<string> { "Confirm" }, "Option");

                    switch (selectedOption)
                    {
                        case 1:
                            if (!_admin.PassportNumbers.Contains($"PN-{passengerPassportNumber}") || _cruise.Passengers.FirstOrDefault(p => p.PassportNumber == $"PN-{passengerPassportNumber}") == null)
                            {
                                PassengerModel newPassenger = ModelFactory.CreatePassenger(passengerFirstName, passengerLastName, passengerPassportNumber);
                                _cruise.AddPassenger(newPassenger);

                                _dataManager.AddPassengersToCruise(FilePathConstants.ConstructPath(), _cruise.CruiseIdentifier, newPassenger);

                                Console.Clear();
                                AnsiConsole.Write(SpectreHelper.DisplayPassengerTable(_cruise.Passengers, $"{_cruise.CruiseName} Passengers"));

                                AnsiConsole.MarkupLine($"[blue]Would You Like To Add [yellow]Another[/] Passenger To {_cruise.CruiseName}'s Itenary[/]");
                                selectedOption = SpectreHelper.GetSelection(new List<string> { "Confirm" }, "Option");

                                switch (selectedOption)
                                {
                                    case 1:
                                        break;
                                    case 2:
                                        SpectreHelper.ReturnToMainMenu("Action Aborted", "red3");

                                        _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager); ;
                                        _page.DisplayContent();

                                        addAnotherPassenger = false;

                                        break;
                                }

                                break;
                            }
                            else
                            {

                                SpectreHelper.ReturnToMainMenu("Passenger Cannot Be Added. A Passenger With This Passport Number Already Exists in The System.", "red3");

                                _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);

                                _page.DisplayContent();

                                addAnotherPassenger = false;

                                break;
                            }


                        case 2:
                            _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                            _page.DisplayContent();
                            break;
                    }
                }
                else
                {
                    SpectreHelper.ReturnToMainMenu("Passenger Cannot Be Added. A Passenger With This Passport Number Already Exists in The System.", "red3");

                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);

                    _page.DisplayContent();
                }
            }
        }
    }
}
