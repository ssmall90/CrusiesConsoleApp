﻿using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using Spectre.Console;

namespace CrusiesConsoleAppUI.Pages
{
    public class SelectPortToEditPage : IBasePage
    {
        IUserModel _admin;
        CruiseModel _cruise;
        IBasePage _page;
        IPageStore _pageStore;
        IDataManager _dataManager;

        public SelectPortToEditPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            _admin = admin;
            _cruise = cruise;
            _page = page;
            _pageStore = pageStore;
            _dataManager = dataManager;
        }

        public void DisplayContent()
        {
            Console.Clear();

            AnsiConsole.MarkupLine(SpectreHelper.DisplayHeader("Select A Port"));

            AnsiConsole.Write(SpectreHelper.DisplayPortTable(_cruise.Ports, $"{_cruise.CruiseName} Ports"));

            if(_cruise.Ports.Count > 0) 
            {
                int selectedPort = SpectreHelper.GetSelection(_cruise.Ports, "port");

                Console.Clear();

                AnsiConsole.MarkupLine(SpectreHelper.DisplayHeader($"{_cruise.Ports[selectedPort-1].Name}"));

                AnsiConsole.Write(SpectreHelper.DisplayPort(_cruise.Ports[selectedPort-1]));

                int selectedOption = SpectreHelper.GetSelection(new List<string> { "Add A Trip To This Port", "Remove A Trip From This Port", "Add A Passenger To A Trip On This Port", "Remove A Passenger From A Trip On This Port" }, "Option");

                switch (selectedOption)

                {
                    case 1:
                        _page = PageFactory.CreateAddTripPage(_admin, _page, _cruise, _cruise.Ports[selectedPort - 1], _pageStore, _dataManager);
                        _page.DisplayContent();
                        break;

                    case 2:
                        if (_cruise.Ports[selectedPort - 1] != null)
                        {
                            _page = PageFactory.CreateRemoveTripPage(_admin, _page, _cruise, _cruise.Ports[selectedPort - 1], _pageStore, _dataManager);
                            _page.DisplayContent();
                            break;
                        }
                        else
                        {
                            SpectreHelper.ReturnToMainMenu("This Port Has No Trips to Delete","red3");

                            _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                            _page.DisplayContent();
                            break;
                        }
                    case 3:
                        _page = PageFactory.AddPassengerToTripPage(_admin, _page, _cruise, _cruise.Ports[selectedPort - 1], _pageStore, _dataManager);
                        _page.DisplayContent();
                        break;

                    case 4:
                        _page = PageFactory.RemovePassengerFromTripPage(_admin, _page, _cruise, _cruise.Ports[selectedPort - 1], _pageStore, _dataManager);
                        _page.DisplayContent();
                        break;
                    case 5:
                        _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                        _page.DisplayContent();
                        break;
                }
            }
            else
            {
                SpectreHelper.ReturnToMainMenu("The Selected Cruise Does Not Have Any Ports", "red3");

                _page = _pageStore.CurrentPage;
                _page.DisplayContent();
            }
           
        }

    }
}

