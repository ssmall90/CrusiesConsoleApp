using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;

namespace CrusiesConsoleAppUI.Pages
{
    public class EditPassengerPage : IBasePage
    {
        IUserModel _admin;
        CruiseModel _cruise;
        IBasePage _page;
        IPageStore _pageStore;
        IDataManager _dataManager;

        public EditPassengerPage (IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
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
            HelperMethods.HelperMethods.DisplayPageHeader("Edit Passenger");
            HelperMethods.HelperMethods.DisplayList(_cruise.Passengers, $"{_cruise.CruiseName} Passengers");
            switch (HelperMethods.HelperMethods.GetItemInRange(1, HelperMethods.HelperMethods.DisplayEditingOptions("editPassengerPage"), "Select An Action for the Options Above"))
            {
                case 1:
                    _pageStore.CurrentPage = this;
                    _page = PageFactory.CreateAddPassengerPage(_admin, _page, _cruise, _pageStore, _dataManager);
                    _page.DisplayContent();
                    break;
                case 2:
                    _pageStore.CurrentPage = this;
                    _page = PageFactory.CreateRemovePassengerPage(_admin, _page, _cruise, _pageStore, _dataManager);
                    _page.DisplayContent();
                    break;

                case 3:
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _page.DisplayContent();
                    break;

            }

            Console.ReadLine();
        }
    }
}

