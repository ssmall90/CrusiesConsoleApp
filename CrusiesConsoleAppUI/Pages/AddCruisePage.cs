using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CrusiesConsoleAppUI.Pages
{
    public class AddCruisePage : IBasePage
    {
        IUserModel _admin;
        IBasePage _page;

        public AddCruisePage(IUserModel admin, IBasePage page)
        {
            _admin = admin;
            _page = page;
        }
        public void DisplayContent()
        {
            Console.WriteLine("Enter the name of your cruise");
            string cruiseName = Console.ReadLine();
            while(string.IsNullOrEmpty(cruiseName) || cruiseName.Length < 3)
            {
                Console.WriteLine("Enter A valid name for your cruise. \n\r" +
                    "PLease ensure your name cruise name has more than 3 characters");
                cruiseName = Console.ReadLine();
            }
            
            _admin.AddCruise(ModelFactory.CreateCruise(cruiseName));

            Console.WriteLine("Your Cruise Has been Created. Add Passengers, Ports and Trips From the Main Menu");
            Console.WriteLine("Press Enter to Return To Main Menu");
            Console.ReadLine();

            Console.Clear();
            _page = PageFactory.CreateHomePage(_admin, _page);
            _page.DisplayContent();


        }
    }
}
