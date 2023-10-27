using CrusiesConsoleAppUI.Models;

namespace CrusiesConsoleAppUI.Services
{
    public interface IDataManager
    {
        void AddPassengersToCruise(string filePath, string cruiseIdentifier, PassengerModel passenger);
        void AddPassengerToTrip(string filePath, string cruiseIdentifier, string portName, string tripName, PassengerModel passenger);
        void AddPortToCruise(string filePath, CruiseModel cruise, PortModel port);
        void AddTripToPort(string filePath, string cruiseIdentifier, string portId, TripModel trip);
        void AppendCruiseToXml(string filePath, CruiseModel cruise);
        List<CruiseModel> DeserializeCruiseFromXml(string filePath);
        void RemovePassengerFromCruise(string filePath, string cruiseIdentifier, string passportNumber);
        void RemovePassengerFromTrip(string filePath, string cruiseIdentifier, string portName, string tripName, string passportNumber);
        void RemoveTripFromPort(string filePath, string tripId);
    }
}