using CruisesAppDataAccess;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using Spectre.Console;


namespace CrusiesConsoleAppUI.Pages
{
    public class EditCruisePage : IBasePage
    {
        IUserModel _admin;
        IBasePage _page;
        IPageStore _pageStore;
        IDataManager _dataManager;
        CruiseModel _cruise;

        public EditCruisePage(IUserModel admin,IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            _admin = admin;
            _cruise = cruise;
            _page = page;
            _pageStore = pageStore;
            _dataManager = dataManager;
        }
        public void DisplayContent()
        {


            Console.Clear();
            AnsiConsole.MarkupLine(SpectreHelper.DisplayHeader("Edit Cruise"));

            AnsiConsole.MarkupLine($"Cruise Name: {_cruise.CruiseName}");
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine($"Cruise ID: {_cruise.CruiseIdentifier}");
            AnsiConsole.WriteLine();


            AnsiConsole.Write(SpectreHelper.DisplayPortTable(_cruise.Ports, $"{_cruise.CruiseName} Ports"));
            AnsiConsole.WriteLine();
            AnsiConsole.Write(SpectreHelper.DisplayPassengerTable(_cruise.Passengers, $"{_cruise.CruiseName} Passengers"));
            AnsiConsole.WriteLine();

            int selection = SpectreHelper.GetSelection(new List<string>{ "Edit Ports", "Edit Passengers", "Remove Cruise From System"}, "Option");
            HelperMethods.HelperMethods.DisplayEditingOptions("editCruisePage");

            switch (selection)
            {
                case 1:
                    _pageStore.CurrentPage = this;
                    _page = PageFactory.CreateEditPortsPage(_admin, _page, _cruise, _pageStore, _dataManager);
                    _page.DisplayContent();
                     break;

                case 2:
                    _pageStore.CurrentPage = this;
                    _page = PageFactory.CreateEditPassengerPage(_admin, _page, _cruise, _pageStore, _dataManager);
                    _page.DisplayContent();
                    break;

                case 3:
                    Console.Clear();
                    AnsiConsole.Write(SpectreHelper.DisplayCruise(_cruise));
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    AnsiConsole.WriteLine("Are You Sure You Want To Delete This Cruise From The System");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();

                    int selectedOption = SpectreHelper.GetSelection(new List<string> { "Confirm" }, "Option");
                    Console.WriteLine();

                    switch (selectedOption)
                    { 
                        case 1:
                            _dataManager.RemoveCruise(FilePathConstants.ConstructPath(),_cruise.CruiseIdentifier);
                            _admin.RemoveCruise(_cruise);

                            SpectreHelper.ReturnToMainMenu("The Selected Cruise Has Been Successfully Deleted From The System","green");
                            
                            _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                            _page.DisplayContent();
                            break;
                        case 2:
                            SpectreHelper.ReturnToMainMenu("The Selected Cruise Has Not Been Deleted From The System","red3");
                           
                            _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                            _page.DisplayContent();
                            break;
                    }
                    break;

                case 4:
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _page.DisplayContent(); break;
            
            }

        }
    }
}
