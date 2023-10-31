using CrusiesAppDataAccess.Factory;
using CrusiesConsoleAppUI.Factory;
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
        IDataManager _dataManager;
        

        public AddCruisePage(IUserModel admin, IBasePage page, IPageStore pageStore, IDataManager dataManager)
        {
            _admin = admin;
            _page = page;
            _pageStore = pageStore;   
            _dataManager = dataManager;
        }
        public void DisplayContent()
        {
            Console.Clear();
            HelperMethods.HelperMethods.DisplayPageHeader("Add Cruise");

            string cruiseName = HelperMethods.HelperMethods.GetValidName("Name","Cruise");

            CruiseModel newCruise = ModelFactory.CreateCruise(cruiseName);

            _admin.AddCruise(newCruise);
            _dataManager.AppendCruiseToXml("XML Files\\Cruises1.xml", newCruise);
            HelperMethods.HelperMethods.ReturnToMainMenu($"Your Cruise Has Been Successfully Added to {_admin.DisplayName}'s List of Cruises");
            _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
            _page.DisplayContent();


        }
    }
}
