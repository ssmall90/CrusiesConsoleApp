using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CrusiesConsoleAppUI.Models
{
    public class TripModel
    {
        private static int _nextId;
        private readonly string _nameOfActivity;
        private readonly string _activityId;
        private readonly int _cost;
        private readonly List<PassengerModel> _attendingPassengers;


        public List<PassengerModel> AttendingPassengers { get; set; }

        public static int NextId1 { get => _nextId; set => _nextId = value; }

        public string NameOfActivity { get; set; }

        public string ActivityId { get; set; }

        public int Cost { get; set; }

        static TripModel()
        {
            _nextId = 7093;
        }
        public TripModel(string tripName, int costOfTrip)
        {
            NameOfActivity = tripName;
            ActivityId = $"AI-{NextId1++}";
            Cost = costOfTrip;
            AttendingPassengers = new List<PassengerModel>();
            _nextId = _nextId++;

        }
        public TripModel()
        {

        }

        public override string ToString()
        {
            return $"Id: {ActivityId}" +
                   $" {NameOfActivity} " +
                   $"Price: £{Cost}";
        }
    }
}
