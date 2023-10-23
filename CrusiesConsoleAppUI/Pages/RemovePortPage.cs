using CrusiesConsoleAppUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Pages
{
    public class RemovePortPage 
    {
        private readonly UserModel _admin;

        public RemovePortPage(UserModel admin)
        {
            _admin = admin;
        }
    }
}
