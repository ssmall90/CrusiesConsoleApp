﻿using CruisesAppDataAccess;
using CrusiesAppDataAccess.Factory;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using Spectre.Console;


namespace CrusiesConsoleAppUI.Pages
{
    public class AddPortPage : IBasePage
    {
        IUserModel _admin;
        IBasePage _page;
        IPageStore _pageStore;
        IDataManager _dataManager;
        CruiseModel _cruise;


        public AddPortPage (IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            _admin = admin;
            _page = page;
            _cruise = cruise;
            _pageStore = pageStore;
            _dataManager = dataManager;
        }
        public void DisplayContent()
        {

            Console.Clear();
            AnsiConsole.MarkupLine(SpectreHelper.DisplayHeader("Add Port"));

            string portName = SpectreHelper.GetValidName("Name", "Port");
            int lengthOfStay = SpectreHelper.GetValidInt("Enter the Duration of the Stay at This Port", 14);

            int selectedOption = SpectreHelper.GetSelection(new List<string> { "Confirm" }, "Option");


            switch (selectedOption)
            {
                case 1:

                    _cruise.AddPort(ModelFactory.CreatePort(portName, lengthOfStay));
                    PortModel newPort = _cruise.Ports.Where(p => p.Name == portName).FirstOrDefault()!;

                    _dataManager.AddPortToCruise(FilePathConstants.ConstructPath(),_cruise, newPort);

                    SpectreHelper.ReturnToMainMenu($"Your Port Has Been Successfully Added to {_cruise.CruiseName}","green");
                    
                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _page.DisplayContent();

                    break;

                case 2:
                    SpectreHelper.ReturnToMainMenu($"Action Aborted", "red3");

                    _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                    _pageStore.CurrentPage = _page;
                    _page.DisplayContent();

                    break;

            }

        }
        

    }
}
