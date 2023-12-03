namespace CruisesAppDataAccess
{
    public static class FilePathConstants
    {

        public static string ConstructPath()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "database.xml";
            string parentDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(baseDirectory)?.FullName!)?.FullName!)?.FullName!)?.FullName!)?.FullName!;
            string xmlFilePath = Path.Combine(parentDirectory, "CruisesAppLibrary", "Xml Files", fileName);
            return xmlFilePath;
        }

        public static string ConstructTextFilePath(string fileName)
        {

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string txtFileName = "LastAppointment.txt";
                string parentDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(baseDirectory)?.FullName)?.FullName)?.FullName)?.FullName)?.FullName;
                string txtFilePath = Path.Combine(parentDirectory, "Student Supervisor Data Access", "TextFiles", txtFileName);

                return txtFilePath;
            }
        }
    }
    


