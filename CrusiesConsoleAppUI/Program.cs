using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Pages;
using CrusiesConsoleAppUI.Services;
using System.Xml.Serialization;

UserModel admin = new UserModel("Sheldon");
DataManager dataManager = new DataManager();
HomePage homePAge = new HomePage(admin);
PageManager pageManager = new PageManager(admin, homePAge)



admin.Cruises = dataManager.DeserializeCruiseFromXml("Cruises.xml");

pageManager.BuildPage()
