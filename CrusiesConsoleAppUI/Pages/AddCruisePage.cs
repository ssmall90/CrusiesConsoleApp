using CruisesAppDataAccess;
using CrusiesAppDataAccess.Factory;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;


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

            HelperMethods.HelperMethods.DisplayEditingOptions("confirmOrCancel");

            switch(HelperMethods.HelperMethods.GetItemInRange(1,2,"Are You Sure You Want To Add This Cruise?"))
            {
                case 1:
                    CruiseModel newCruise = ModelFactory.CreateCruise(cruiseName);
                    _admin.AddCruise(newCruise);
                    _dataManager.AppendCruiseToXml(FilePathConstants.ConstructPath(), newCruise);
                    HelperMethods.HelperMethods.ReturnToMainMenu($"Your Cruise Has Been Successfully Added to {_admin.DisplayName}'s List of Cruises");
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _page.DisplayContent();

                    break;

                case 2:
                    HelperMethods.HelperMethods.ReturnToMainMenu($"Your Cruise Has Not Been Added to {_admin.DisplayName}'s List of Cruises");
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _page.DisplayContent();
                    break;

            }




        }
    }
}
