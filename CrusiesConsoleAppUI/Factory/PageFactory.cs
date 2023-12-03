using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Pages;
using CrusiesConsoleAppUI.Services;


namespace CrusiesConsoleAppUI.Factory
{
    public static class PageFactory
    {
        private static AddCruisePage? addCruisePageInstance;
        private static HomePage? homePageInstance;
        private static ViewAllCruisesPage? viewAllCruisesPageInstance;
        private static EditCruisePage? editCruisePageInstance;
        private static AddPassengerPage? addPassengerPageInstance;
        private static RemovePassengerPage? removePassengerPageInstance;
        private static EditPassengerPage? editPassengerPageInstance;
        private static AddPortPage? addPortPageInstance;
        private static RemovePortPage? removePortPageInstance;
        private static EditPortsPage? editPortsPageInstance;
        private static SelectPortToEditPage? selectPortToEditPageInstance;
        private static AddTripPage? addTripPageInstance;
        private static RemoveTripPage? removeTripPageInstance;
        private static AddPassengerToTripPage? AddPassengerToTripPageInstance;
        private static RemovePassengerFromTripPage? removePassengerFromTripPageInstance;

        public static IBasePage CreateHomePage(IUserModel admin, IBasePage page, IPageStore pageStore ,IDataManager dataManager)
        {
            ResetInstances();

            if(homePageInstance == null)
            {
                homePageInstance = new HomePage(admin, page, pageStore, dataManager);
            }
            return homePageInstance;
        }
        public static IBasePage CreateViewAllCruisesPage(IUserModel admin, IBasePage page, IPageStore pageStore, IDataManager dataManager)
        {
            if(viewAllCruisesPageInstance == null)
            {
                viewAllCruisesPageInstance = new ViewAllCruisesPage(admin, page, pageStore, dataManager);
            }
            return viewAllCruisesPageInstance;
        }
        public static IBasePage CreateAddCruisePage(IUserModel admin, IBasePage page, IPageStore pageStore, IDataManager dataManager)
        {
            if(addCruisePageInstance == null)
            {
                addCruisePageInstance = new AddCruisePage(admin, page, pageStore, dataManager);
            }
            return addCruisePageInstance;
        }
        public static IBasePage CreateEditCruisePage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            if(editCruisePageInstance == null)
            {
                editCruisePageInstance = new EditCruisePage(admin, page, cruise, pageStore, dataManager);
            }
            return editCruisePageInstance;
        }
        public static IBasePage CreateAddPassengerPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore,  IDataManager dataManager)
        {
            if(addPassengerPageInstance == null)
            {
                addPassengerPageInstance = new AddPassengerPage(admin, page, cruise, pageStore, dataManager);
            }
            return addPassengerPageInstance;
        }
        public static IBasePage CreateRemovePassengerPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            if(removePassengerPageInstance == null)
            {
                removePassengerPageInstance = new RemovePassengerPage(admin, page, cruise, pageStore, dataManager);
            }
            return removePassengerPageInstance;

        }
        public static IBasePage CreateEditPassengerPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            if (editPassengerPageInstance == null)
            {
                editPassengerPageInstance = new EditPassengerPage(admin, page, cruise, pageStore, dataManager);
            }
            return editPassengerPageInstance;

        }
        public static IBasePage CreateAddPortPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            if(addPortPageInstance == null)
            {
                addPortPageInstance = new AddPortPage(admin, page, cruise, pageStore, dataManager);
            }
            return addPortPageInstance;
        }
        public static IBasePage CreateRemovePortPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            if(removePortPageInstance == null)
            {
                removePortPageInstance = new RemovePortPage(admin, page, cruise, pageStore, dataManager);
            }
            return removePortPageInstance;
        }
        public static IBasePage CreateEditPortsPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            if(editPortsPageInstance == null)
            {
                editPortsPageInstance = new EditPortsPage(admin, page, cruise, pageStore, dataManager);
            }
            return editPortsPageInstance;
        }
        public static IBasePage CreateSelectPortToEditPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            if(selectPortToEditPageInstance == null)
            {
                selectPortToEditPageInstance = new SelectPortToEditPage(admin, page, cruise, pageStore, dataManager);
            }
            return selectPortToEditPageInstance;
        }
        public static IBasePage CreateAddTripPage(IUserModel admin, IBasePage page, CruiseModel cruise, PortModel port, IPageStore pageStore, IDataManager dataManager)
        {
            if(addTripPageInstance == null)
            {
                addTripPageInstance = new AddTripPage(admin, page, cruise, port, pageStore, dataManager);
            }
            return addTripPageInstance;
        }
        public static IBasePage CreateRemoveTripPage(IUserModel admin, IBasePage page, CruiseModel cruise, PortModel port, IPageStore pageStore, IDataManager dataManager)
        {
            if(removeTripPageInstance  == null)
            {
                removeTripPageInstance = new RemoveTripPage(admin, page, cruise, port, pageStore, dataManager);
            }
            return removeTripPageInstance;
        }
        public static IBasePage AddPassengerToTripPage(IUserModel admin, IBasePage page, CruiseModel cruise, PortModel port, IPageStore pageStore, IDataManager dataManager)
        {
            if(AddPassengerToTripPageInstance == null)
            {
                AddPassengerToTripPageInstance = new AddPassengerToTripPage(admin, page, cruise, port, pageStore, dataManager);
            }
            return AddPassengerToTripPageInstance;
        }
        public static IBasePage RemovePassengerFromTripPage(IUserModel admin, IBasePage page, CruiseModel cruise, PortModel port, IPageStore pageStore, IDataManager dataManager)
        {
            if (removePassengerFromTripPageInstance == null)
            {
                removePassengerFromTripPageInstance = new RemovePassengerFromTripPage(admin, page, cruise, port, pageStore, dataManager);
            }
            return removePassengerFromTripPageInstance;
        }

        public static void ResetInstances()
        {
            addCruisePageInstance = null;
            homePageInstance = null;
            viewAllCruisesPageInstance = null;
            editCruisePageInstance = null;
            addPassengerPageInstance = null;
            removePassengerPageInstance = null;
            editPassengerPageInstance = null;
            addPortPageInstance = null;
            removePortPageInstance = null;
            editPortsPageInstance = null;
            selectPortToEditPageInstance = null;
            addTripPageInstance = null;
            removeTripPageInstance = null;
            AddPassengerToTripPageInstance = null;
            removePassengerFromTripPageInstance = null;

        }

    }
}
