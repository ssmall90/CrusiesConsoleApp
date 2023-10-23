using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Pages
{
    public class HomePage : IBasePage
    {
        IUserModel _admin;
        IBasePage _page;

        public HomePage(IUserModel admin, IBasePage page)
        {
            _admin = admin;
            _page = page;
        }
        public void DisplayContent()
        {
            Console.WriteLine("1: Add Cruise");
            Console.WriteLine("2: Edit Cruise");
            Console.WriteLine("3: Remove Cruise");
            Console.WriteLine("4: View All Cruises");

            switch(HelperMethods.HelperMethods.GetItemInRange(1, _admin.Cruises.Count))
            {
                case 1:
                    _page = PageFactory.CreateAddCruisePage(_admin, _page);
                    _page.DisplayContent();

                    break; 
                case 2: 
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine();
                    break;
                case 4:
                    _page = PageFactory.CreateViewAllCruisesPage(_admin, _page);
                    _page.DisplayContent();
                    break;
            }

        }
    }
}
