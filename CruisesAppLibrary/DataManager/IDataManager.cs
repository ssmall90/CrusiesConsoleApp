using CrusiesConsoleAppUI.Models;

namespace CrusiesConsoleAppUI.Services
{
    public interface IDataManager
    {
        void AddPassengersToCruise(string filePath, string cruiseIdentifier, PassengerModel passenger);
        void AddPortToCruise(string filePath, CruiseModel cruise, PortModel port);
        void AddTripToPort(string filePath, string cruiseIdentifier, string portId, TripModel trip);
        void AppendCruiseToXml(string filePath, CruiseModel cruise);
        List<CruiseModel> DeserializeCruiseFromXml(string filePath);
        void RemoveTripFromPort(string filePath, string tripId);
    }
}