using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using Spectre.Console;

namespace CrusiesConsoleAppUI.Pages
{
    public class EditPortsPage : IBasePage
    {
        IUserModel _admin;
        CruiseModel _cruise;
        IBasePage _page;
        IPageStore _pageStore;
        IDataManager _dataManager;

        public EditPortsPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            _admin = admin;
            _page = page;
            _cruise = cruise;
            _pageStore = pageStore;
            _dataManager = dataManager;
        }
        public void DisplayContent()
        {
            Console.Clear();
            HelperMethods.HelperMethods.DisplayPageHeader("Edit Ports");
            //HelperMethods.HelperMethods.DisplayList(_cruise.Ports, $"{_cruise.CruiseName} Ports");
            AnsiConsole.Write(SpectreHelper.DisplayPortTable(_cruise.Ports));
            int selection = SpectreHelper.GetSelection(new List<string> {"Add Port", "Remove Port","Edit Port" }, "Option");
            switch (selection)
            {
                case 1:
                    _pageStore.CurrentPage = this;
                    _page = PageFactory.CreateAddPortPage(_admin, _page, _cruise, _pageStore, _dataManager); 
                    _page.DisplayContent();
                    break;
                case 2:
                    _pageStore.CurrentPage = this;
                    _page = PageFactory.CreateRemovePortPage(_admin, _page, _cruise, _pageStore, _dataManager);
                    _page.DisplayContent();
                    break;
                case 3:
                    _pageStore.CurrentPage = this;
                    _page = PageFactory.CreateSelectPortToEditPage(_admin, _page, _cruise, _pageStore, _dataManager);
                    _page.DisplayContent();
                    break;
                case 4:
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _page.DisplayContent();
                    break;
            }

            Console.ReadLine();
        }
    }
}
