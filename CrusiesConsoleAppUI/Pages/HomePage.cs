using CrusiesConsoleAppUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Pages
{
    public class HomePage 
    {
        private readonly UserModel _admin;

        public HomePage(UserModel admin)
        {
            _admin = admin;
        }

    }
}
