using CruisesAppDataAccess;
using CrusiesAppDataAccess.Factory;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;


namespace CrusiesConsoleAppUI.Pages
{
    public class AddPortPage : IBasePage
    {
        IUserModel _admin;
        IBasePage _page;
        IPageStore _pageStore;
        IDataManager _dataManager;
        CruiseModel _cruise;


        public AddPortPage (IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
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
            HelperMethods.HelperMethods.DisplayPageHeader("Add Port");

            string portName = HelperMethods.HelperMethods.GetValidName("Name", "Port");
            int lengthOfStay = HelperMethods.HelperMethods.GetValidInt("Enter the Duration of the Stay at This Port");

            HelperMethods.HelperMethods.DisplayEditingOptions("confirmOrCancel");


            switch (HelperMethods.HelperMethods.GetItemInRange(1, 2, $"Are you sure you would like to add {portName} to {_cruise.CruiseName}?"))
            {
                case 1:

                    _cruise.AddPort(ModelFactory.CreatePort(portName, lengthOfStay));
                    PortModel newPort = _cruise.Ports.Where(p => p.Name == portName).FirstOrDefault()!;

                    _dataManager.AddPortToCruise(FilePathConstants.ConstructPath(),_cruise, newPort);

                    HelperMethods.HelperMethods.ReturnToMainMenu($"Your Port Has Been Successfully Added to {_cruise.CruiseName}");
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _page.DisplayContent();
                    break;

                case 2:
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _pageStore.CurrentPage = _page;
                    _page.DisplayContent();
                    break;

            }

            //Console.WriteLine($"Enter the Name of The Port You Would Like to Add to {_cruise.CruiseName}");
            //Console.ReadLine();
        }
        

    }
}
