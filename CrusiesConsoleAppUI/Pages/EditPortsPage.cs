using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Pages
{
    public class EditPortsPage : IBasePage
    {
        IUserModel _admin;
        CruiseModel _cruise;
        IBasePage _page;
        IPageStore _pageStore;

        public EditPortsPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore)
        {
            _admin = admin;
            _page = page;
            _cruise = cruise;
            _pageStore = pageStore;
        }
        public void DisplayContent()
        {
            Console.Clear();
            HelperMethods.HelperMethods.DisplayPageHeader("Edit Ports");
            HelperMethods.HelperMethods.DisplayList(_cruise.Ports, $"{_cruise.CruiseName} Ports");
            HelperMethods.HelperMethods.DisplayEditingOptions("editPortPage");
            switch (HelperMethods.HelperMethods.GetItemInRange(1, _cruise.Ports.Count))
            {
                case 1:
                    _pageStore.CurrentPage = this;
                    _page = PageFactory.CreateAddPortPage(_admin, _page, _cruise, _pageStore); 
                    _page.DisplayContent();
                    break;
                case 2:
                    _pageStore.CurrentPage = this;
                    _page = PageFactory.CreateRemovePortPage(_admin, _page, _cruise, _pageStore);
                    _page.DisplayContent();
                    break;

            }





            Console.ReadLine();
        }
    }
}
