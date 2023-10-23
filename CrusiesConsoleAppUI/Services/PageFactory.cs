using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Services
{
    public static class PageFactory
    {
        public static IBasePage CreateHomePage(IUserModel admin, IBasePage page, IPageStore pageStore)
        {
            return new HomePage(admin,page,pageStore);
        }

        public static IBasePage CreateAddCruisePage(IUserModel admin, IBasePage page, IPageStore pageStore)
        {
            return new AddCruisePage(admin, page ,pageStore);
        }

        public static IBasePage CreateAddPassengerPage(IUserModel admin)
        {
            return new AddPassengerPage(admin);
        }

        public static IBasePage CreateAddPortPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore)
        {
            return new AddPortPage(admin, page, cruise, pageStore );
        }

        public static IBasePage CreateEditPortsPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore)
        {
            return new EditPortsPage(admin, page, cruise, pageStore);
        }

        public static IBasePage CreateEditCruisePage(IUserModel admin, IBasePage page ,CruiseModel cruise , IPageStore pageStore)
        {
            return new EditCruisePage(admin, page, cruise, pageStore);
        }

        public static IBasePage CreateRemoveCruisePage(IUserModel admin)
        {
            return new RemoveCruisePage(admin);
        }

        public static IBasePage CreateRemovePassngerPage(IUserModel admin)
        {
            return new RemovePassengerPage(admin);
        }

        public static IBasePage CreateRemovePortPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore)
        {
            return new RemovePortPage(admin, page, cruise, pageStore);
        }

        public static IBasePage CreateViewAllCruisesPage(IUserModel admin, IBasePage page, IPageStore pageStore)
        {
            return new ViewAllCruisesPage(admin, page, pageStore);
        }
    }
}
