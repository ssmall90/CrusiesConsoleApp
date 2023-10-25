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
            HelperMethods.HelperMethods.DisplayPageHeader($"{_cruise}");
            Console.WriteLine(_cruise.CruiseName); 
            Console.WriteLine(_cruise.CruiseIdentifier);
            HelperMethods.HelperMethods.DisplayList(_cruise.Ports, "Ports");
            HelperMethods.HelperMethods.DisplayList(_cruise.Passengers, "Passengers");
            HelperMethods.HelperMethods.DisplayEditingOptions("editCruisePage");

            switch (HelperMethods.HelperMethods.GetItemInRange(1, 3, "Select An Action From The Options Above"))
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
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _page.DisplayContent(); break;
            
            }



            Console.ReadLine();
        }
    }
}
