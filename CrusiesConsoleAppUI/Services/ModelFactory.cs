using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Services
{
    public static class ModelFactory
    {
        public static CruiseModel CreateCruise(string cruiseName)
        {
            CruiseModel cruise = new CruiseModel();
            cruise.CruiseName = cruiseName;
            return cruise;
        }

        public static PassengerModel CreatePassenger()
        {
            return new PassengerModel();
        }

        public static PortModel CreatePort(string portName)
        {
            return new PortModel(portName);
        }

        public static TripModel CreateTrip()
        {
            return new TripModel();
        }

        public static IUserModel CreateUser(string name)
        {
            return new UserModel(name);
        }

        public static IDataManager CreateDataManager()
        {
            return new DataManager();
        }

    }
}
