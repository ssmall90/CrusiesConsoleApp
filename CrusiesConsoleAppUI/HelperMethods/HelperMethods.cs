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

            index = 1;
        }

       
    }


}


