namespace CrusiesConsoleAppUI.HelperMethods
{
    public static class HelperMethods
    {
        public static int GetItemInRange(int pMin, int pMax, string message) // Get User Inputs For Menus
        {

            Console.WriteLine();

            if (pMin > pMax)
            {
                throw new Exception($"Minimum value {pMin} cannot be greater than maximum value {pMax}");

            }

            int result;


            do
            {

                Console.WriteLine($"{message}\r\n\r\nPlease Enter A Number Between {pMin} And {pMax} Inclusive.");

                string userInput = Console.ReadLine();

                Console.WriteLine("");

                try
                {
                    result = int.Parse(userInput);
                }
                catch
                {
                    Console.WriteLine($"{userInput} Is Not A Number");
                    continue;
                }

                if (result >= pMin && result <= pMax)
                {

                    return result;

                }


                Console.WriteLine($"{result} Is Not Between {pMin} And {pMax} Inclusive.");

            } while (true);

        }

        public static void DisplayPageHeader(string pageTitle)
        {
            Console.WriteLine($"------------------------------{pageTitle}------------------------------");
        }

        public static void DisplayList<T>(List<T> list, string listName)
        {
            int index = 1;
            string _listName = listName;

            Console.WriteLine($"--------------------");
            Console.WriteLine($"{listName}");
            Console.WriteLine($"--------------------");
            
            if (list != null)
            {
                foreach (var item in list)
                {
                    Console.WriteLine($"{index}: {item}");
                    index++;
                }
            }

        }

        public static int DisplayEditingOptions(string options)
        {

            if(options == "confirmOrCancel")
            {
                List<string> createOrCancelOptions = new List<string>();
                createOrCancelOptions.Add("1: Confirm");
                createOrCancelOptions.Add("2: Cancel");
                DisplayList(createOrCancelOptions, " Confirm or Cancel");
                return createOrCancelOptions.Count();

            }

            if (options == "editCruisePage")
            {
                List<string> editCruisePageOptions = new List<string>();
                editCruisePageOptions.Add("Edit Ports");
                editCruisePageOptions.Add("Edit Passengers");
                editCruisePageOptions.Add("Remove Cruise From System");
                editCruisePageOptions.Add("Return To Main Menu");
                DisplayList(editCruisePageOptions, "Editing Options");
                return editCruisePageOptions.Count();
            }

            if (options == "editTrip")
            {
                List<string> editTripOptions = new List<string>();
                editTripOptions.Add("Add Trip");
                editTripOptions.Add("Remove Trip");
                editTripOptions.Add("Add Passenger To A Trip");
                editTripOptions.Add("Remove Passenger From A Trip");
                editTripOptions.Add("Return To Main Menu");
                DisplayList(editTripOptions, "Editing Options");
                return editTripOptions.Count();
            }


            else if (options == "editPortPage")
            {

                List<string> addPortPageOptions = new List<string>();
                addPortPageOptions.Add("Add New Port");
                addPortPageOptions.Add("Remove Port");
                addPortPageOptions.Add("Edit Exisiting Port");
                addPortPageOptions.Add("Return To Main Menu");
                DisplayList(addPortPageOptions, "Editing Options");
                return addPortPageOptions.Count();
            }
            else if (options == "editPassengerPage")
            {

                List<string> addPortPageOptions = new List<string>();
                addPortPageOptions.Add("Add New Passenger");
                addPortPageOptions.Add("Remove Passenger");
                addPortPageOptions.Add("Return To Main Menu");
                DisplayList(addPortPageOptions, "Editing Options");
                return addPortPageOptions.Count();
            }
            else
            {
                return 0;
            }







        }

        public static string GetValidName(string nameType, string model )
        {
            bool isValid = false;

            string result = string.Empty;

            do
            {

                Console.WriteLine($"Please Enter the {nameType} for the {model} You Would Like to Add");

                string userInput = Console.ReadLine();

                Console.WriteLine("");

                if (userInput.Length >= 3)
                {
                    isValid = true;
                    result = userInput;
                }
                else
                {
                    Console.WriteLine("Enter a Name at Least 3 Characters In Length.");
                }

            } while (!isValid);

            return result;
        }

        public static int GetValidInt(string message)
        {
            bool isValid = false;

            int result = 0;

            do
            {

                Console.WriteLine($"{message}");

                string userInput = Console.ReadLine();

                Console.WriteLine("");

                try
                {
                    result = int.Parse(userInput);
                }
                catch
                {
                    Console.WriteLine($"{userInput} Is Not A Number");
                    continue;
                }

                if (result > 0 && result < 365)
                {
                    isValid = true;
                    return result;
                }
                else
                {
                    Console.WriteLine("You must enter a number between 1 & 365 to continue");
                    continue;
                }


            } while (!isValid);

            return result;
        }

        public static int ConfirmAction()
        {
            bool isValid = false;
            int response = 3;

            do

            {
                Console.WriteLine("Press Y to confirm or N to cancel");

                string userInput = Console.ReadLine().ToLower();

                Console.WriteLine("");

                if (userInput.Length > 0)
                {
                    if (userInput == "Y".ToLower())
                    {
                        isValid = true;
                        response = 1;

                    }
                    else if (userInput == "N".ToLower())
                    {
                        isValid = true;
                        response = 0;
                        return 0;
                    }
                    else
                    {
                        isValid = false;
                    }
                }

                else
                {
                    return 0;
                }

            } while (!isValid);

            return response;
        }

        public static void ReturnToMainMenu(string pMessage) // Exit Option Back To Main Menu View
        {

            Console.SetCursorPosition(Console.WindowLeft, Console.CursorTop + 3);
            Console.WriteLine(pMessage);
            Console.SetCursorPosition(Console.WindowLeft, Console.CursorTop + 1);
            Console.WriteLine("Press Any Key To Return To The Main Menu");
            Console.ReadKey();

        }
    }
}

         
        





