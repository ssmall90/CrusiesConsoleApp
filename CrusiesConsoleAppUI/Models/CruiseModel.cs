using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Models
{
    public class CruiseModel : ICruiseModel
    {
        public string CruiseName {  get; set; }   
        public string CruiseIdentifier { get; set; }
        public List<PortModel> Ports { get; set; }
        public List<PassengerModel> Passengers { get; set; }

        public CruiseModel()
        {

        }
        public CruiseModel(string cruiseName, string cruiseIdentifier)
        {
            CruiseName = cruiseName;
            CruiseIdentifier = cruiseIdentifier;
            Ports = new List<PortModel>();
            Passengers = new List<PassengerModel>();
        }

        public void AddPassenger(PassengerModel passenger)
        {
            Passengers.Add(passenger);
        }

        public void RemovePassenger(PassengerModel passenger)
        {
            Passengers.Remove(passenger);
        }

        public void AddPort(PortModel port)
        {
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
