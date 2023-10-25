using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Models
{
    public class PortModel : IPortModel
    {
        private static int _nextId = 0; 
        public static int NextId { get { return _nextId; } set { NextId = value; } }
        public string Name { get; set; }
        public int PortId { get; set; }
        public int LengthOfStay { get; set; }
        public List<TripModel> Trips { get; set; }

        static PortModel()
        {
            _nextId = 113;
        }


        public PortModel(string portName, int lengthOfStay)
        {
            Name = portName;
            PortId = _nextId++;
            LengthOfStay = lengthOfStay;
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
