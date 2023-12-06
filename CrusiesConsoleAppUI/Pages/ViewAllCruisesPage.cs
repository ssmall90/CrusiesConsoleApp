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

            AnsiConsole.MarkupLine(SpectreHelper.DisplayHeader("View All Cruises"));

            AnsiConsole.Write(SpectreHelper.DisplayCruiseTable(_admin.Cruises , "Cruises"));

            AnsiConsole.WriteLine();

            int selectedCruise = SpectreHelper.GetSelection(_admin.Cruises, "Cruise");


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
