using CrusiesConsoleAppUI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Services
{
    public class PageStore : IPageStore
    {
        IBasePage _currentPage;

        public IBasePage CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; }
        }
        public PageStore(IBasePage currentPage)
        {
            _currentPage = currentPage;
        }

    }
}
