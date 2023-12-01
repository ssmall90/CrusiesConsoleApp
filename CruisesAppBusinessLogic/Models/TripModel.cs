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
        private static int _nextId = LoadNextIdNumber();

        private static string ConfigFilePath
        {
            get
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string txtFileName = "LastTripNumber.txt";

                string parentDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(baseDirectory)?.FullName!)?.FullName!)?.FullName!)?.FullName!)?.FullName!;
                string txtFilePath = Path.Combine(parentDirectory, "CruisesAppLibrary", "Text Files", txtFileName);

                return txtFilePath;
            }
        }

        public List<PassengerModel> AttendingPassengers { get; set; }

        public string NameOfActivity { get; set; }

        public string ActivityId { get; set; }

        public int Cost { get; set; }


        public TripModel(string tripName, int costOfTrip)
        {
            NameOfActivity = tripName;
            Cost = costOfTrip;
            ActivityId = $"AI-{_nextId++}";
            AttendingPassengers = new List<PassengerModel>();

            SaveLastIdNumber(_nextId);

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
            return 7093;
        }

        private static void SaveLastIdNumber(int number)
        {
            File.WriteAllText(ConfigFilePath, number.ToString());
        }
    }
}
