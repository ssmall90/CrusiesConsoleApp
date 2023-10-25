using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.HelperMethods
{
    public class HelperMethods
    {
        public static int GetItemInRange(int pMin, int pMax) // Get User Inputs For Menus
        {

            Console.WriteLine();

            if (pMin > pMax)
            {
                throw new Exception($"Minimum value {pMin} cannot be greater than maximum value {pMax}");

            }

            int result;


            do
            {

                Console.WriteLine($"To Select A Menu Option Please Enter A Number Between {pMin} And {pMax} Inclusive.");

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

            foreach (var item in list)
            {
                Console.WriteLine($"{index}: {item}");
                index++;
            }

        }

        public static int DisplayEditingOptions(string options)
        {
            if (options == "editCruisePage")
            {
                List<string> editCruisePageOptions = new List<string>();
                editCruisePageOptions.Add("1: Edit Ports");
                editCruisePageOptions.Add("2: Edit Passengers");
                editCruisePageOptions.Add("3: Go Back");
                DisplayList(editCruisePageOptions, "Editing Options");
                return editCruisePageOptions.Count();
            }
            else if (options == "editPortPage")
            {

                List<string> addPortPageOptions = new List<string>();
                addPortPageOptions.Add("1: Add New Port");
                addPortPageOptions.Add("2: Remove Port");
                addPortPageOptions.Add("3: Edit Exisiting Port");
                addPortPageOptions.Add("3: Go Back");
                DisplayList(addPortPageOptions, "Editing Options");
                return addPortPageOptions.Count();
            }
            else
            {
                return 0;
            }







        }

        public static string GetValidName(string model)
        {
            bool isValid = false;

            string result = string.Empty;

            do
            {

                Console.WriteLine($"Please Enter a Name for the {model} You Would Like to Add");

                string userInput = Console.ReadLine();

                Console.WriteLine("");

                if (userInput.Length > 0)
                {
                    isValid = true;
                    result = userInput;
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

                if (result > 0 && result < 7)
                {
                    isValid = true;
                    return result;
                }
                else
                {
                    Console.WriteLine("You must enter a number between 1 & 7 to continue");
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
                    if(userInput == "Y".ToLower())
                    {
                        isValid = true;
                        response = 1;

                    }
                    else if(userInput == "N".ToLower())
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

    }
}




