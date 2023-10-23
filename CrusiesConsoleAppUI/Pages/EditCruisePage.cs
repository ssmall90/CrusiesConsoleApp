using CrusiesConsoleAppUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Pages
{
    public class EditCruisePage 
    {
        private readonly UserModel _admin;
        private readonly CruiseModel _selectedCruise;

        public EditCruisePage(CruiseModel selectedCruise, UserModel admin)
        {
            _selectedCruise = selectedCruise;
            _admin = admin;
        }

    }
}
