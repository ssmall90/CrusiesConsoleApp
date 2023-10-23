using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Models
{
    public class PassengerModel : IPassengerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }

        public PassengerModel()
        {

        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
