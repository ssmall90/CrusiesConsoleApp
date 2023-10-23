using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Pages
{
    public class RemovePortPage : IBasePage
    {
        IUserModel _admin;
        CruiseModel _cruise;
        IBasePage _page;
        IPageStore _pageStore;

        public RemovePortPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore)
        {
            _admin = admin;
            _cruise = cruise;
            _page = page;
            _pageStore = pageStore;
        }
        public void DisplayContent()
        {
            Console.Clear();
            HelperMethods.HelperMethods.DisplayPageHeader($"Remove Port");
            HelperMethods.HelperMethods.DisplayList(_cruise.Ports, "Ports");
            Console.WriteLine("Enter The Number Of The Port You Want To Delete");
            int selectedPort =  HelperMethods.HelperMethods.GetItemInRange(1, _cruise.Ports.Count - 1);
            _cruise.RemovePort(_cruise.Ports[selectedPort]);

            foreach ( var port in _cruise.Ports ) { Console.WriteLine(port.ToString()); }


            
            

        }
    }
}
