using CrusiesConsoleAppUI.Models;
using System.Collections.Generic;

namespace CrusiesConsoleAppUI.Services
{
    public interface IDataManager
    {
        void AppendCruiseToXml(string filePath, CruiseModel cruise);
        List<CruiseModel> DeserializeCruiseFromXml(string filePath);
        PassengerModel DeserializePassengerFromXml(string filePath);
        PortModel DeserializePortFromXml(string filePath);
        TripModel DeserializeTripFromXml(string filePath);
    }
}