using CrusiesConsoleAppUI.Models;

namespace CrusiesConsoleAppUI.Services
{
    public interface IDataManager
    {
        void AddPortToCruise(string filePath, string outputFilePath, CruiseModel cruise, PortModel port);
        void AddTripToPort(string filePath, string cruiseIdentifier, string portName, TripModel trip);
        void AppendCruiseToXml(string filePath, CruiseModel cruise);
        List<CruiseModel> DeserializeCruiseFromXml(string filePath);
        PassengerModel DeserializePassengerFromXml(string filePath);
        PortModel DeserializePortFromXml(string filePath);
        TripModel DeserializeTripFromXml(string filePath);
        void RemoveTripFromPort(string filePath, string tripId);
    }
}