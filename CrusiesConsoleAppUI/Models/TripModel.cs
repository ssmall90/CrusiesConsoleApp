using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Models
{
    public class TripModel
    {
        public string NameOfActivity { get; set; }
        public string ActivityId { get; set; }
        public int Cost { get; set; }
        public List<PassengerModel> PassengersAttending { get; set; }

        public TripModel()
        {

        }
    }
}
