namespace CrusiesConsoleAppUI.Models
{
    public class UserModel : IUserModel
    {
        private static int _nextId = LoadNextIdNumber();

        private static string ConfigFilePath
        {
            get
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string txtFileName = "LastUserNumber.txt";

                string parentDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(baseDirectory)?.FullName!)?.FullName!)?.FullName!)?.FullName!)?.FullName!;
                string txtFilePath = Path.Combine(parentDirectory, "CruisesAppLibrary", "Text Files", txtFileName); // Only Suitable For Debugging

                return txtFilePath;

            }
        }

        public string Id { get; set; }
        public string DisplayName { get; set; }
        public List<CruiseModel> Cruises { get; set; }
        public List<string> PassportNumbers { get; set; }


        public UserModel(string displayName)
        {
            DisplayName = displayName;
            Id = "123";
            Cruises = new List<CruiseModel>();
            _nextId = _nextId++;
            PassportNumbers = new List<string>();
            SaveLastIdNumber(_nextId);
        }

        public void AddCruise(CruiseModel cruise)
        {
            Cruises.Add(cruise);
        }

        public void RemoveCruise(CruiseModel cruise)
        {
            Cruises.Remove(cruise);
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
