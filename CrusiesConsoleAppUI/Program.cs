using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Pages;
using CrusiesConsoleAppUI.Services;
using System.Xml.Serialization;

IUserModel admin =  ModelFactory.CreateUser("Sheldon");
IDataManager dataManager = ModelFactory.CreateDataManager();
admin.Cruises = dataManager.DeserializeCruiseFromXml("Cruises.xml");
IBasePage basePage = new BasePage(admin);


IBasePage homepage = PageFactory.CreateHomePage(admin, basePage);
homepage.DisplayContent();





