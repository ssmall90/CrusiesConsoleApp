using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            AnsiConsole.MarkupLine(SpectreHelper.DisplayHeader("Select A Exisiting Port Page"));

            AnsiConsole.Write(SpectreHelper.DisplayPortTable(_cruise.Ports, $"{_cruise.CruiseName} Ports"));

            if(_cruise.Ports.Count > 0) 
            {
                int selectedPort = SpectreHelper.GetSelection(_cruise.Ports, "port");

                Console.Clear();
                AnsiConsole.Write(SpectreHelper.DisplayPort(_cruise.Ports[selectedPort-1]));

                int selectedOption = SpectreHelper.GetSelection(new List<string> { "Add Trip", "Remove Trip","Add Passenger", "Remove Passenger" }, "Option");

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

