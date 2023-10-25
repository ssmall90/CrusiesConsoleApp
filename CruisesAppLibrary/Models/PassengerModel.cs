using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Models
{
    public class PassengerModel : IPassengerModel
    {
        private static int _nextPassportNumber = 0;
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _passportNumber;

        public static int NextPassportNumber { get { return _nextPassportNumber; } set { NextPassportNumber = value; } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }

        static PassengerModel()
        {
            _nextPassportNumber = 103113;
        }

        public PassengerModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            PassportNumber = $"PN-{_nextPassportNumber + 1}";

        }

        public PassengerModel()
        {

        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + PassportNumber;
        }
    }
}
