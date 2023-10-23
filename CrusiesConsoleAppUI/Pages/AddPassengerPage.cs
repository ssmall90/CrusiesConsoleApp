using CrusiesConsoleAppUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Pages
{
    public class AddPassengerPage : IBasePage
    {
        IUserModel _admin;

        public AddPassengerPage(IUserModel admin)
        {
            _admin = admin;
        }
        public void DisplayContent()
        {
            throw new NotImplementedException();
        }
    }
}
