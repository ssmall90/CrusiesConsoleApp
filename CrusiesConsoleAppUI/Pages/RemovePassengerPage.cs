using CrusiesConsoleAppUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Pages
{
    public class RemovePassengerPage : IBasePage
    {
        IUserModel _admin;
        public RemovePassengerPage(IUserModel admin)
        {
            _admin = admin;
        }
        public void DisplayContent()
        {
            throw new NotImplementedException();
        }
    }
}
