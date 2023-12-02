using CruisesAppDataAccess;
using CrusiesAppDataAccess.Factory;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Pages;
using CrusiesConsoleAppUI.Services;
using System.Xml.Serialization;

string xmlFilePath = FilePathConstants.ConstructPath();



IUserModel admin =  ModelFactory.CreateUser("Sheldon");

IDataManager dataManager = new DataManager();

admin.Cruises = dataManager.DeserializeCruiseFromXml(xmlFilePath);
admin.PassportNumbers = dataManager.ReadPassportNumbersFromXml(xmlFilePath);

IBasePage basePage = new BasePage(admin);

IPageStore pageStore = new PageStore(basePage);

IBasePage homepage = PageFactory.CreateHomePage(admin, basePage, pageStore, dataManager);

homepage.DisplayContent();







