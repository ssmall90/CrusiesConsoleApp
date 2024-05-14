using CruisesAppDataAccess;
using CrusiesAppDataAccess.Factory;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using Spectre.Console;


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


            AnsiConsole.MarkupLine(SpectreHelper.DisplayHeader("Add New Cruise"));

            string cruiseName = SpectreHelper.GetValidName("Name","Cruise");

            AnsiConsole.MarkupLine("[bold yellow]Are You Sure You Would Like To Add This Cruise?[/]");

            int selectedOption = SpectreHelper.GetSelection(new List<string> { "Confirm", }, "An Option");

            switch (selectedOption)
            {
                case 1:
                    CruiseModel newCruise = ModelFactory.CreateCruise(cruiseName);
                    _admin.AddCruise(newCruise);

                    _dataManager.AppendCruiseToXml(FilePathConstants.ConstructPath(), newCruise);

                    SpectreHelper.ReturnToMainMenu($"Your Cruise Has Been Successfully Added To Your List of Cruises", "green");
                   
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _page.DisplayContent();

                    break;

                case 2:
                    SpectreHelper.ReturnToMainMenu($"Your Cruise Has Not Been Added to {_admin.DisplayName}'s List of Cruises","red3");
                   
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _page.DisplayContent();
                    break;

            }




        }
    }
}
