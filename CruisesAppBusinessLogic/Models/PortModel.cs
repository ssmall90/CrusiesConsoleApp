using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Models
{
    public class PortModel 
    {

        private static int _nextId = LoadNextIdNumber();
        private static string ConfigFilePath
        {
            get
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string txtFileName = "LastPortNumber.txt";

                string parentDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(baseDirectory)?.FullName!)?.FullName!)?.FullName!)?.FullName!)?.FullName!;
                string txtFilePath = Path.Combine(parentDirectory, "CruisesAppLibrary", "Text Files", txtFileName);

                return txtFilePath;
            }
        }


        public string Name { get; set; }
        public string PortId { get; set; }
        public int LengthOfStay { get; set; }
        public List<TripModel> Trips { get; set; }


        public PortModel(string portName, int lengthOfStay)
        {
            Name = portName;
            PortId = $"PI-{_nextId++}";
            LengthOfStay = lengthOfStay;
            Trips = new List<TripModel>();
            _nextId = _nextId++;

            SaveLastIdNumber(_nextId);

        }

        public PortModel()
        {

        }

        public void AddTrip(TripModel trip)
        {
            Trips.Add(trip);
        }

        public void RemoveTrip(TripModel trip)
        {
            Trips.Remove(trip);
        }

        public override string ToString()
        {
            return $"{PortId} + {Name}";
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
            return 0;
        }

        private static void SaveLastIdNumber(int number)
        {
            File.WriteAllText(ConfigFilePath, number.ToString());
        }


    }
}
