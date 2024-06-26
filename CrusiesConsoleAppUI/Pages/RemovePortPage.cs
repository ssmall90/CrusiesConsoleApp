﻿using CruisesAppDataAccess;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using Spectre.Console;


namespace CrusiesConsoleAppUI.Pages
{
    public class RemovePortPage : IBasePage
    {
        IUserModel _admin;
        CruiseModel _cruise;
        IBasePage _page;
        IPageStore _pageStore;
        IDataManager _dataManager;

        public RemovePortPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
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
            AnsiConsole.MarkupLine(SpectreHelper.DisplayHeader("Remove Port"));

            AnsiConsole.Write(SpectreHelper.DisplayPortTable(_cruise.Ports , $"{_cruise.CruiseName} Ports"));

            if (_cruise.Ports.Count > 0)
            {
                int selectedPort = SpectreHelper.GetSelection(_cruise.Ports, "The Port You Would Like To Remove");

                Console.Clear();

                AnsiConsole.MarkupLine(SpectreHelper.DisplayHeader($"{_cruise.Ports[selectedPort - 1].Name}"));

                AnsiConsole.Write(SpectreHelper.DisplayPort(_cruise.Ports[selectedPort - 1]));

                AnsiConsole.WriteLine();

                AnsiConsole.MarkupLine("[red3]Are You Sure You Want To Remove This Port?[/]");

                AnsiConsole.WriteLine();

                int selectedOption = SpectreHelper.GetSelection(new List<string> { "Confirm" }, "Option");

                switch (selectedOption)
                {
                    case 1:
                        _dataManager.RemovePortFromCruise(FilePathConstants.ConstructPath(), _cruise.Ports[selectedPort - 1].PortId);
                        _cruise.RemovePort(_cruise.Ports[selectedPort - 1]);
                        SpectreHelper.ReturnToMainMenu("The Selected Port Has Been Removed From The Cruise", "green");
                        _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                        _page.DisplayContent();
                        break;

                    case 2:
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
