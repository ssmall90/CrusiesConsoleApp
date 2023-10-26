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
    public class SelectPortToEditPage : IBasePage
    {
        IUserModel _admin;
        CruiseModel _cruise;
        IBasePage _page;
        IPageStore _pageStore;
        IDataManager _dataManager;

        public SelectPortToEditPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
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
            HelperMethods.HelperMethods.DisplayPageHeader($"Choose Port");
            HelperMethods.HelperMethods.DisplayList(_cruise.Ports, "Ports");
            int selectedPort = HelperMethods.HelperMethods.GetItemInRange(1, _cruise.Ports.Count, "Which Port Do You Want to Edit?");
            HelperMethods.HelperMethods.DisplayEditingOptions("editTrip");
            int selectedOption = HelperMethods.HelperMethods.GetItemInRange(1, 5, "Select An Action from the Menu Above");

            switch(selectedOption)

            {
                case 1:
                    _page = PageFactory.CreateAddTripPage(_admin, _page, _cruise, _cruise.Ports[selectedPort -1], _pageStore, _dataManager);
                    _page.DisplayContent();
                    break;

                case 2:
                    if (_cruise.Ports[selectedPort - 1] != null)
                    {
                        _page = PageFactory.CreateRemoveTripPage(_admin, _page, _cruise, _cruise.Ports[selectedPort - 1], _pageStore, _dataManager);
                        _page.DisplayContent();
                        break;
                    }
                    else
                    {
                        HelperMethods.HelperMethods.ReturnToMainMenu("This Port Has no Trips to Delete");
                        _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                        _page.DisplayContent();
                        break;
                    }
                case 3: _page = PageFactory.AddPassengerToTripPage(_admin, _page, _cruise, _cruise.Ports[selectedPort - 1], _pageStore, _dataManager);
                    _page.DisplayContent(); break;
            }

        }

    }
}

