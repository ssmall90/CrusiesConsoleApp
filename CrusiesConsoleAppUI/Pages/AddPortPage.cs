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
        CruiseModel _cruise;
        IBasePage _page;
        IPageStore _pageStore;

        public AddPortPage (IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore)
        {
            _admin = admin;
            _page = page;
            _cruise = cruise;
            _pageStore = pageStore;
        }
        public void DisplayContent()
        {
            Console.Clear();
            HelperMethods.HelperMethods.DisplayPageHeader($"Add A Port to {_cruise.CruiseName}");
        }
        

    }
}
