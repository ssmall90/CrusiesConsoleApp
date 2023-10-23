using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Pages
{
    public class ViewAllCruisesPage: IBasePage
    {
        IUserModel _admin;
        IBasePage _page;
        IPageStore _pageStore;

        public ViewAllCruisesPage(IUserModel admin, IBasePage page, IPageStore pageStore)
        {
            _admin = admin;
            _page = page;
            _pageStore = pageStore;
        }
        public void DisplayContent()
        {
            Console.Clear();
            HelperMethods.HelperMethods.DisplayPageHeader("View All Cruises");
            HelperMethods.HelperMethods.DisplayList(_admin.Cruises,"Cruises");

            int selectedCruise = HelperMethods.HelperMethods.GetItemInRange(1, _admin.Cruises.Count) - 1;

            _page = PageFactory.CreateEditCruisePage(_admin, _page, _admin.Cruises[selectedCruise],_pageStore);
            _page.DisplayContent();


        }
    }
}
