namespace CrusiesConsoleAppUI.Models
{
    public class CruiseModel
    {
        private static int _nextId = LoadNextIdNumber();

        private static string ConfigFilePath
        {
            get
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string txtFileName = "LastCruiseId.txt";

                //string parentDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(baseDirectory)?.FullName!)?.FullName!)?.FullName!)?.FullName!)?.FullName!;
                //string txtFilePath = Path.Combine(parentDirectory, "CruisesAppLibrary", "Text Files", txtFileName);// Only Suitable For Debugging

                //return txtFilePath;

                string textFilePathPublished = Path.Combine(baseDirectory, "Text Files", txtFileName);

                return textFilePathPublished;
            }
        }


        public string CruiseName {  get; set; }   
        public string CruiseIdentifier { get; set; }
        public List<PortModel> Ports { get; set; }
        public List<PassengerModel> Passengers { get; set; }

        public CruiseModel()
        {

        }
        public CruiseModel(string cruiseName)
        {
            CruiseName = cruiseName;
            CruiseIdentifier = $"CI-{_nextId++}";
            Ports =  new List<PortModel>();
            Passengers = new List<PassengerModel>();
            _nextId = _nextId++;

            SaveLastIdNumber(_nextId);

        }

        public void AddPassenger(PassengerModel passenger)
        {
            Passengers = Passengers ?? new List<PassengerModel>();
            Passengers.Add(passenger);
        }

        public void RemovePassenger(PassengerModel passenger)
        {

            Passengers.Remove(passenger);
        }

        public void AddPort(PortModel port)
        {
            Ports = Ports ?? new List<PortModel>();
            Ports.Add(port);
        }

        public void RemovePort(PortModel port)
        {
            Ports.Remove(port);
        }

        public override string ToString()
        {
            return CruiseName;
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
