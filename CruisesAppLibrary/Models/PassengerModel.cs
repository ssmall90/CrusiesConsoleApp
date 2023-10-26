using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


    namespace CrusiesConsoleAppUI.Models
    {
    public class PassengerModel : IPassengerModel
    {
        private static int _nextPassportNumber = LoadNextIdNumber();

        private const string ConfigFilePath = "C:\\Users\\ssmal\\source\\repos\\CrusiesConsoleApp\\CruisesAppLibrary\\TextFiles\\LastPassportNumber.txt";

        public static int NextPassportNumber
        {
            get { return _nextPassportNumber; }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }


        public PassengerModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            PassportNumber = $"PN-{_nextPassportNumber++}";

            // Save the updated _nextPassportNumber to the configuration file
            SaveLastIdNumber(_nextPassportNumber);
        }

        public PassengerModel()
        {

        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + PassportNumber;
        }

        private static int LoadNextIdNumber()
        {
            if (File.Exists(ConfigFilePath))
            {
                string content = File.ReadAllText(ConfigFilePath);
                if (int.TryParse(content, out int number))
                {
                    return number;
                }
            }
            return 103113; // Default value if no configuration file found
        }

        private static void SaveLastIdNumber(int number)
        {
            File.WriteAllText(ConfigFilePath, number.ToString());
        }
    }
}
