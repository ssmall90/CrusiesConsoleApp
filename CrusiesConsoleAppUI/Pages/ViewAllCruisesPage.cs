using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using Spectre.Console;


namespace CrusiesConsoleAppUI.Pages
{
    public class ViewAllCruisesPage: IBasePage
    {
        IUserModel _admin;
        IBasePage _page;
        IPageStore _pageStore;
        IDataManager _dataManager;

        public ViewAllCruisesPage(IUserModel admin, IBasePage page, IPageStore pageStore, IDataManager dataManager)
        {
            _admin = admin;
            _page = page;
            _pageStore = pageStore;
            _dataManager = dataManager;
        }
        public void DisplayContent()
        {
            Console.Clear();

            HelperMethods.HelperMethods.DisplayPageHeader("View All Cruises");

            AnsiConsole.Write(SpectreHelper.DisplayCruiseTable(_admin.Cruises));

            //HelperMethods.HelperMethods.DisplayList(_admin.Cruises,"Cruises");
            //AnsiConsole.Write(HelperMethods.HelperMethods.DisplayTable("Name", _admin.Cruises));

            Console.WriteLine($"{_admin.Cruises.Count + 1}: Return To Main Menu");

            int selectedCruise = SpectreHelper.GetSelection(_admin.Cruises, "Cruise");

            //HelperMethods.HelperMethods.GetItemInRange(1, _admin.Cruises.Count + 1, "Which Cruise Would You Like To View/Edit?");

            if (selectedCruise > 0 && selectedCruise <= _admin.Cruises.Count)
            {
                _pageStore.CurrentPage = this;
                _page = PageFactory.CreateEditCruisePage(_admin, _page, _admin.Cruises[selectedCruise - 1], _pageStore, _dataManager);
                _page.DisplayContent();
            }
            else
            {
                _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                _page.DisplayContent();
            }

        }
    }
}
