using CrusiesAppDataAccess.Factory;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            HelperMethods.HelperMethods.DisplayPageHeader($"Add A Port to {_cruise.CruiseName}");
            string portName = HelperMethods.HelperMethods.GetValidName("Name","Port");
            int lengthOfStay = HelperMethods.HelperMethods.GetValidInt("Please enter the duration of the stay at this port");

            switch (HelperMethods.HelperMethods.ConfirmAction())
            {
                case 0:
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _pageStore.CurrentPage = _page;
                    _page.DisplayContent();
                    break;

                case 1:
                    _cruise.AddPort(ModelFactory.CreatePort(portName,lengthOfStay));
                    PortModel newPort = _cruise.Ports.Where(p =>  p.Name == portName).FirstOrDefault()!;
                    _dataManager.AddPortToCruise("C:\\Users\\ssmal\\source\\repos\\CrusiesConsoleApp\\CruisesAppLibrary\\XML Files\\Cruises1.xml",_cruise, newPort);
                    HelperMethods.HelperMethods.ReturnToMainMenu($"Your Port Has Been Successfully Added to {_cruise.CruiseName}");
                    _page = PageFactory.CreateHomePage(_admin,_page, _pageStore, _dataManager);
                    _page.DisplayContent();
                    break;

            }

            //Console.WriteLine($"Enter the Name of The Port You Would Like to Add to {_cruise.CruiseName}");
            //Console.ReadLine();
        }
        

    }
}
