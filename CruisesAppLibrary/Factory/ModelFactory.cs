using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesAppDataAccess.Factory
{
    public static class ModelFactory
    {
        public static CruiseModel CreateCruise(string cruiseName)
        {
            CruiseModel cruise = new CruiseModel();
            cruise.CruiseName = cruiseName;
            return cruise;
        }

        public static PassengerModel CreatePassenger(string firstName, string LastName)
        {
            return new PassengerModel(firstName, LastName);
        }

        public static PortModel CreatePort(string portName, int lengthOfStay)
        {
            return new PortModel(portName,lengthOfStay);
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
