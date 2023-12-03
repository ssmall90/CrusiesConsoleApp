using CruisesAppDataAccess;
using CrusiesAppDataAccess.Factory;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;


namespace CrusiesConsoleAppUI.Pages
{
    public class RemovePortPage : IBasePage
    {
        IUserModel _admin;
        CruiseModel _cruise;
        IBasePage _page;
        IPageStore _pageStore;
        IDataManager _dataManager;

        public RemovePortPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
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
            HelperMethods.HelperMethods.DisplayPageHeader($"Remove Port");
            HelperMethods.HelperMethods.DisplayList(_cruise.Ports, "Ports");
            if (_cruise.Ports.Count > 0)
            {
                int selectedPort = HelperMethods.HelperMethods.GetItemInRange(1, _cruise.Ports.Count, "Which Port Would You Like To Delete");

                HelperMethods.HelperMethods.DisplayEditingOptions("confirmOrCancel");

                switch (HelperMethods.HelperMethods.GetItemInRange(1, 2, $"Are you sure you want to delete {_cruise.Ports[selectedPort - 1]}"))
                {
                    case 1:
                        _dataManager.RemovePortFromCruise(FilePathConstants.ConstructPath(), _cruise.Ports[selectedPort - 1].PortId);
                        _cruise.RemovePort(_cruise.Ports[selectedPort - 1]);
                        HelperMethods.HelperMethods.ReturnToMainMenu("The selected port has been  removed from the cruise");
                        _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                        _page.DisplayContent();
                        break;

                    case 2:
                        _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                        _page.DisplayContent();
                        break;
                }
            }
            else
            {
                HelperMethods.HelperMethods.ReturnToMainMenu("The Selected Cruise Does Not Have Any Ports");
                _page = _pageStore.CurrentPage;
                _page.DisplayContent();
            }

        }
    }
}
