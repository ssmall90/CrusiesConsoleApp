using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Models
{
    public class PortModel : IPortModel
    {
        public string Name { get; set; }
        public int PortId { get; set; }
        public int LengthOfStay { get; set; }
        public List<TripModel> Trips { get; set; }

        public PortModel(string portName)
        {
            Name = portName;
            PortId = 0;
            LengthOfStay = 0;
            Trips = new List<TripModel>();
        }

        public PortModel()
        {
        }

        public override string ToString()
        {
            return $"{PortId } + { Name}";
        }
    }
}
