using CrusiesConsoleAppUI.Models;


namespace CrusiesAppDataAccess.Factory
{
    public static class ModelFactory
    {
        public static CruiseModel CreateCruise(string cruiseName)
        {
        
            return new CruiseModel(cruiseName);
        }

        public static PassengerModel CreatePassenger(string firstName, string LastName, int passportNumber)
        {
            return new PassengerModel(firstName, LastName, passportNumber);
        }

        public static PortModel CreatePort(string portName, int lengthOfStay)
        {
            return new PortModel(portName,lengthOfStay);
        }

        public static TripModel CreateTrip(string tripName, int costOfTrip)
        {
            return new TripModel(tripName,costOfTrip);
        }

        public static IUserModel CreateUser(string name)
        {
            return new UserModel(name);
        }


    }
}
