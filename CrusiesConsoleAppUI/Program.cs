using CruisesAppDataAccess;
using CrusiesAppDataAccess.Factory;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Pages;
using CrusiesConsoleAppUI.Services;



IntPtr handle = ProgramSetup.GetConsoleWindow();

IntPtr sysMenu = ProgramSetup.GetSystemMenu(handle, false);

if (handle != IntPtr.Zero)
{
    ProgramSetup.DeleteMenu(sysMenu, ProgramSetup.SC_CLOSE, ProgramSetup.MF_BYCOMMAND);
    ProgramSetup.DeleteMenu(sysMenu, ProgramSetup.SC_MINIMIZE, ProgramSetup.MF_BYCOMMAND);
    ProgramSetup.DeleteMenu(sysMenu, ProgramSetup.SC_MAXIMIZE, ProgramSetup.MF_BYCOMMAND);
    ProgramSetup.DeleteMenu(sysMenu, ProgramSetup.SC_SIZE, ProgramSetup.MF_BYCOMMAND);
}


string xmlFilePath = FilePathConstants.ConstructPath();

IUserModel admin = ModelFactory.CreateUser("Sheldon");

IDataManager dataManager = new DataManager();

admin.Cruises = dataManager.DeserializeCruiseFromXml(xmlFilePath);

admin.PassportNumbers = dataManager.ReadPassportNumbersFromXml(xmlFilePath);

IBasePage basePage = new BasePage(admin);

IPageStore pageStore = new PageStore(basePage);

IBasePage homepage = PageFactory.CreateHomePage(admin, basePage, pageStore, dataManager);

homepage.DisplayContent();







