using CrusiesConsoleAppUI.Models;

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
