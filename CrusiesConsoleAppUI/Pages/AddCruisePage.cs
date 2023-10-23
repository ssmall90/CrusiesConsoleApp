using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CrusiesConsoleAppUI.Pages
{
    public class AddCruisePage : IBasePage
    {
        IUserModel _admin;
        IBasePage _page;
        IPageStore _pageStore;

        public AddCruisePage(IUserModel admin, IBasePage page, IPageStore pageStore)
        {
            _admin = admin;
            _page = page;
            _pageStore = pageStore;   
        }
        public void DisplayContent()
        {
            Console.Clear();
            HelperMethods.HelperMethods.DisplayPageHeader("Add Cruise");
            Console.WriteLine("Enter The Name of Your Cruise or Press '0' to Go Back" );

            string cruiseName = Console.ReadLine();

            Console.WriteLine("Press '0' to Go Back");

            while (true)
            {
                if (cruiseName == "0")
                {
                    Console.Clear();
                    _page = _pageStore.CurrentPage;
                    _page.DisplayContent();
                }
                else if (string.IsNullOrEmpty(cruiseName) || cruiseName.Length < 3)
                {
                    Console.WriteLine("Enter A valid name for your cruise. \n\r" +
                        "Please ensure your cruise name has more than 3 characters");
                    cruiseName = Console.ReadLine();
                }
                else
                {
                    _admin.AddCruise(ModelFactory.CreateCruise(cruiseName));

                    Console.WriteLine("Your Cruise Has been Created. Add Passengers, Ports, and Trips From the Main Menu");
                    Console.WriteLine("Press Enter to Return To Main Menu");
                    Console.ReadLine();

                    Console.Clear();
                    _page = _pageStore.CurrentPage;
                    _page.DisplayContent();
                }
            }
        }
    }
}
