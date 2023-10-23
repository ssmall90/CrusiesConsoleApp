using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Pages
{
    public class BasePage : IBasePage
    {
        IUserModel _admin;

        public BasePage(IUserModel admin)
        {
            _admin = admin;
        }

        public void DisplayContent()
        {

        }
    }
}
