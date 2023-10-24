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
    public class HomePage : IBasePage
    {
        IUserModel _admin;
        IBasePage _page;
        IPageStore _pageStore;
        IDataManager _dataManager;

        public HomePage(IUserModel admin, IBasePage page, IPageStore pageStore, IDataManager dataManager)
        {
            _admin = admin;
            _page = page;
            _pageStore = pageStore;
            _dataManager = dataManager;
        }
        public void DisplayContent()
        {
            _pageStore.CurrentPage = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
            Console.Clear();

            Console.WriteLine("1: Add Cruise");
            Console.WriteLine("2: Edit Cruise");
            Console.WriteLine("3: Remove Cruise");
            Console.WriteLine("4: View All Cruises");

            switch(HelperMethods.HelperMethods.GetItemInRange(1, 4))
            {
                case 1:
                    _pageStore.CurrentPage = this;
                    _page = PageFactory.CreateAddCruisePage(_admin, _page, _pageStore, _dataManager);
                    _page.DisplayContent();

                    break; 
                case 2: 
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine();
                    break;
                case 4:
                    _page = PageFactory.CreateViewAllCruisesPage(_admin, _page, _pageStore, _dataManager);
                    _page.DisplayContent();
                    break;
            }

        }
    }
}
