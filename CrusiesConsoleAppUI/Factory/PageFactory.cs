using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Pages;
using CrusiesConsoleAppUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Factory
{
    public static class PageFactory
    {
        public static IBasePage CreateHomePage(IUserModel admin, IBasePage page, IPageStore pageStore ,IDataManager dataManager)
        {
            return new HomePage(admin, page, pageStore, dataManager);
        }


        public static IBasePage CreateViewAllCruisesPage(IUserModel admin, IBasePage page, IPageStore pageStore, IDataManager dataManager)
        {
            return new ViewAllCruisesPage(admin, page, pageStore, dataManager);
        }

        public static IBasePage CreateAddCruisePage(IUserModel admin, IBasePage page, IPageStore pageStore, IDataManager dataManager)
        {
            return new AddCruisePage(admin, page, pageStore, dataManager);
        }

        public static IBasePage CreateRemoveCruisePage(IUserModel admin, IDataManager dataManager)
        {
            return new RemoveCruisePage(admin);
        }

        public static IBasePage CreateEditCruisePage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            return new EditCruisePage(admin, page, cruise, pageStore, dataManager);
        }





        public static IBasePage CreateAddPassengerPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore,  IDataManager dataManager)
        {
            return new AddPassengerPage(admin ,page, cruise, pageStore, dataManager);
        }
        public static IBasePage CreateRemovePassengerPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            return new RemovePassengerPage (admin, page, cruise, pageStore, dataManager);

        }

        public static IBasePage CreateEditPassengerPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            return new EditPassengerPage (admin, page, cruise, pageStore, dataManager);

        }





        public static IBasePage CreateAddPortPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            return new AddPortPage(admin, page, cruise, pageStore, dataManager);
        }

        public static IBasePage CreateRemovePortPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            return new RemovePortPage(admin, page, cruise, pageStore, dataManager);
        }

        public static IBasePage CreateEditPortsPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            return new EditPortsPage(admin, page, cruise, pageStore, dataManager);
        }

        public static IBasePage CreateSelectPortToEditPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            return new SelectPortToEditPage(admin, page, cruise, pageStore, dataManager);
        }





        public static IBasePage CreateAddTripPage(IUserModel admin, IBasePage page, CruiseModel cruise, PortModel port, IPageStore pageStore, IDataManager dataManager)
        {
            return new AddTripPage(admin, page, cruise, port, pageStore, dataManager);
        }

        public static IBasePage CreateRemoveTripPage(IUserModel admin, IBasePage page, CruiseModel cruise, PortModel port, IPageStore pageStore, IDataManager dataManager)
        {
            return new RemoveTripPage(admin, page, cruise, port, pageStore, dataManager);
        }




        public static IBasePage AddPassengerToTripPage(IUserModel admin, IBasePage page, CruiseModel cruise, PortModel port, IPageStore pageStore, IDataManager dataManager)
        {
            return new AddPassengerToTripPage(admin, page, cruise, port, pageStore, dataManager);
        }
        public static IBasePage RemovePassengerFromTripPage(IUserModel admin, IBasePage page, CruiseModel cruise, PortModel port, IPageStore pageStore, IDataManager dataManager)
        {
            return new RemovePassengerFromTripPage(admin, page, cruise, port, pageStore, dataManager);
        }

    }
}
