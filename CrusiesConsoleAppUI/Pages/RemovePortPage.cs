using CrusiesConsoleAppUI.Models;
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
        public RemovePortPage(IUserModel admin)
        {
            _admin = admin;
        }
        public void DisplayContent()
        {
            throw new NotImplementedException();
        }
    }
}
