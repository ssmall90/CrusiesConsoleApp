using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Services
{
    public class PageManager
    {
        private readonly UserModel _admin;
        private readonly BasePage _page;

        public PageManager(UserModel admin, BasePage page)
        {
            _admin = admin;
            _page = page;
        }

        public BasePage BuildPage(BasePage page)
        {
           return new BasePage(_admin);
        }
    }
}
