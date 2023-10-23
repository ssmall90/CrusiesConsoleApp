using CrusiesConsoleAppUI.Models;
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
        CruiseModel _cruise;

        public EditCruisePage(IUserModel admin,IBasePage page, CruiseModel cruise)
        {
            _admin = admin;
            _cruise = cruise;
            _page = page;
        }
        public void DisplayContent()
        {
            Console.Clear();
            HelperMethods.HelperMethods.DisplayPageHeader($"{_cruise}");
            Console.WriteLine(_cruise.CruiseName); 
            Console.WriteLine(_cruise.CruiseIdentifier);
            HelperMethods.HelperMethods.DisplayList(_cruise.Ports, "Ports");
            HelperMethods.HelperMethods.DisplayList(_cruise.Passengers, "Passengers");
        }
    }
}
