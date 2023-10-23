using CrusiesConsoleAppUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Pages
{
    public class BasePage 
    {
        private readonly UserModel _admin;

        public BasePage(UserModel admin)
        {
            _admin = admin;
        }

        public void DisplayPage()
        {

        }

    }
}
