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
        public static IBasePage CreateHomePage(IUserModel admin, IBasePage page)
        {
            return new HomePage(admin,page);
        }

        public static IBasePage CreateAddCruisePage(IUserModel admin, IBasePage page)
        {
            return new AddCruisePage(admin, page);
        }

        public static IBasePage CreateAddPassengerPage(IUserModel admin)
        {
            return new AddPassengerPage(admin);
        }

        public static IBasePage CreateAddPortPage(IUserModel admin)
        {
            return new AddPortPage(admin);
        }

        public static IBasePage CreateEditCruisePage(IUserModel admin, IBasePage page ,CruiseModel cruise)
        {
            return new EditCruisePage(admin, page, cruise);
        }

        public static IBasePage CreateRemoveCruisePage(IUserModel admin)
        {
            return new RemoveCruisePage(admin);
        }

        public static IBasePage CreateRemovePassngerPage(IUserModel admin)
        {
            return new RemovePassengerPage(admin);
        }

        public static IBasePage CreateRemovePortPage(IUserModel admin)
        {
            return new RemovePortPage(admin);
        }

        public static IBasePage CreateViewAllCruisesPage(IUserModel admin, IBasePage page)
        {
            return new ViewAllCruisesPage(admin, page);
        }
    }
}
