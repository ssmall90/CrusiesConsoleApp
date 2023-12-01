using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


    namespace CrusiesConsoleAppUI.Models
    {
    public class PassengerModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }


        public PassengerModel(string firstName, string lastName, int passportNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PassportNumber = $"PN-{passportNumber++}";
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
