using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace CrusiesConsoleAppUI.Models
{
    public class CruiseModel : ICruiseModel
    {
        private static int _nextId;

        public static int NextCruiseIdentifier { get { return _nextId; } set { NextCruiseIdentifier = value; } }
        public string CruiseName {  get; set; }   
        public string CruiseIdentifier { get; set; }
        public List<PortModel> Ports { get; set; }
        public List<PassengerModel> Passengers { get; set; }

        static CruiseModel()
        {
            _nextId = 501249;
        }
        public CruiseModel()
        {

        }
        public CruiseModel(string cruiseName)
        {
            CruiseName = cruiseName;
            CruiseIdentifier = $"CI-{_nextId++}";
            Ports =  new List<PortModel>();
            Passengers = new List<PassengerModel>();
            _nextId = _nextId++;

        }

        public void AddPassenger(PassengerModel passenger)
        {
            Passengers = Passengers ?? new List<PassengerModel>();
            Passengers.Add(passenger);
        }

        public void RemovePassenger(PassengerModel passenger)
        {

            Passengers.Remove(passenger);
        }

        public void AddPort(PortModel port)
        {
            Ports = Ports ?? new List<PortModel>();
            Ports.Add(port);
        }

        public void RemovePort(PortModel port)
        {
            Ports.Remove(port);
        }

        public override string ToString()
        {
            return CruiseName;
        }

    }
}
