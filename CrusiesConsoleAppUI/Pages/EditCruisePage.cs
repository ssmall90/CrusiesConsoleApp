using CruisesAppDataAccess;
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

            switch (HelperMethods.HelperMethods.GetItemInRange(1, 4, "Select An Action From The Options Above"))
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
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Are You Sure You Want To Delete This Cruise From The System");
                    Console.ForegroundColor = ConsoleColor.White;
                    HelperMethods.HelperMethods.DisplayEditingOptions("confirmOrCancel");


                    switch (HelperMethods.HelperMethods.GetItemInRange(1, 2,""))
                    { 
                        case 1:
                            _dataManager.RemoveCruise(FilePathConstants.ConstructPath(),_cruise.CruiseIdentifier);
                            _admin.RemoveCruise(_cruise);
                            HelperMethods.HelperMethods.ReturnToMainMenu("The Selected Cruise Has Been Deleted From The System");
                            _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                            _page.DisplayContent();
                            break;
                        case 2:
                            HelperMethods.HelperMethods.ReturnToMainMenu("The Selected Cruise Has Not Been Deleted From The System");
                            _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                            _page.DisplayContent();
                            break;
                    }
                    break;

                case 4:
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _page.DisplayContent(); break;
            
            }

        }
    }
}
