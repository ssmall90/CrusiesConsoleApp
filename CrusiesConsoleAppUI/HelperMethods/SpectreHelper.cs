using CrusiesConsoleAppUI.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI
{
    public static class SpectreHelper
    {

        public static string DisplayHeader(string title)
        {
            var titlefiglet = new FigletText(title)
            .Color(Color.DodgerBlue1);

            titlefiglet.Justify(Justify.Center);

            AnsiConsole.WriteLine();
            AnsiConsole.Write(titlefiglet);
            AnsiConsole.WriteLine();
            return $"";
        }

        public static Table DisplayPortTable(List<PortModel> ports, string title)
        {
            var table = new Table();

            table.Title(title);

            table.Expand().Centered().Width(100);
            table.Border(TableBorder.Rounded);
            table.BorderColor(Color.DodgerBlue1);


            table.AddColumn("Port Id");
            table.AddColumn("Port Name");
            table.AddColumn("Duration of Stay");
            table.AddColumn("Trips Available");

            foreach (var port in ports)
            {
                table.AddRow($"{port.PortId}", $"{port.Name}", $"{port.LengthOfStay}", $"{port.Trips.Count}");
            }



            return table;
        }

        public static Table DisplayPort(PortModel port)
        {
            var table = new Table();

            table.Expand().Centered().Width(100);
            table.Border(TableBorder.Rounded);

            table.AddColumn("Port Id");
            table.AddColumn("Port Name");
            table.AddColumn("Duration of Stay");
            table.AddColumn("Trips Available");

            table.AddRow($"{port.PortId}", $"{port.Name}", $"{port.LengthOfStay}", $"{port.Trips.Count}");

            return table;
        }

        public static Table DisplayPassengerTable(List<PassengerModel> passengers, string title)
        {
            var table = new Table();

            table.Title(title);


            table.Expand().Centered().Width(100);
            table.Border(TableBorder.Rounded);
            table.BorderColor(Color.DodgerBlue1);

            table.AddColumn("First Name");
            table.AddColumn("Last Name");
            table.AddColumn("Passport Number");

            foreach (var p in passengers)
            {
                table.AddRow($"{p.FirstName}", $"{p.LastName}", $"{p.PassportNumber}");
            }

            return table;
        }

        public static Table DisplayPassenger(PassengerModel passenger)
        {
            var table = new Table();


            table.Expand().Centered().Width(100);
            table.Border(TableBorder.Rounded);

            table.AddColumn("First Name");
            table.AddColumn("Last Name");
            table.AddColumn("Passport Number");


            table.AddRow($"{passenger.FirstName}", $"{passenger.LastName}", $"{passenger.PassportNumber}");

            return table;
        }

        public static Table DisplayCruiseTable(List<CruiseModel> cruises, string title)
        {
            var table = new Table();

            table.Title(title);


            table.Expand().Centered().Width(100);
            table.Border(TableBorder.Rounded);
            table.BorderColor(Color.DodgerBlue1);


            table.AddColumn("Cruise Id");
            table.AddColumn("Cruise Name");
            table.AddColumn("Number of Ports");
            table.AddColumn("Number of Passengers");

            foreach (var c in cruises)
            {
                table.AddRow($"{c.CruiseIdentifier}", $"{c.CruiseName}", $"{c.Ports.Count}", $"{c.Passengers.Count}");
            }

            return table;
        }

        public static Table DisplayCruise(CruiseModel cruise)
        {
            var table = new Table();

            table.Expand().Centered().Width(100);
            table.Border(TableBorder.Rounded);

            table.AddColumn("Cruise Id");
            table.AddColumn("Cruise Name");
            table.AddColumn("Number of Ports");
            table.AddColumn("Number of Passengers");

            table.AddRow($"{cruise.CruiseIdentifier}", $"{cruise.CruiseName}", $"{cruise.Ports.Count}", $"{cruise.Passengers.Count}");

            return table;
        }

        public static Table DisplayTripTable(List<TripModel> trips, string title)
        {
            var table = new Table();

            table.Title(title);

            table.Expand().Centered().Width(100);
            table.Border(TableBorder.Rounded);
            table.BorderColor(Color.DodgerBlue1);

            table.AddColumn("Trip Id");
            table.AddColumn("Trip Name");
            table.AddColumn("Cost");
            table.AddColumn("Number of Attendees");

            foreach (var trip in trips)
            {
                table.AddRow($"{trip.ActivityId}", $"{trip.NameOfActivity}", $"{trip.Cost}", $"{trip.AttendingPassengers.Count}");
            }

            return table;
        }

        public static Table DisplayTrip(TripModel trip)
        {
            var table = new Table();

            table.Expand().Centered().Width(100);
            table.Border(TableBorder.Rounded);

            table.AddColumn("Trip Id");
            table.AddColumn("Trip Name");
            table.AddColumn("Cost");
            table.AddColumn("Number of Attendees");

            table.AddRow($"{trip.ActivityId}", $"{trip.NameOfActivity}", $"{trip.Cost}", $"{trip.AttendingPassengers.Count}");

            return table;
        }

        public static int GetSelection<T>(List<T> list, string option)
        {
            AnsiConsole.MarkupLine($"[bold yellow]Please Select {option}[/]");

            var prompt = new SelectionPrompt<string>();

            prompt.Title("");
            prompt.PageSize(10);
            prompt.MoreChoicesText("[grey](Move up and down to reveal more items)[/]");

            for (int i = 0; i < list.Count; i++)
            {
                prompt.AddChoice($"{i + 1}: {list[i]}");
            }
            prompt.AddChoice($"{list.Count + 1}: Return To Main Menu");

            var selected = AnsiConsole.Prompt(prompt);

            int selectedIndex = int.Parse(selected.Split(":")[0]) - 1;

            if (selectedIndex != -1)
            {
                return selectedIndex + 1;
            }
            else
            {

                return -1; 
            }


        }

        public static int GetSelectionHomePage<T>(List<T> list)
        {
            AnsiConsole.MarkupLine($"[bold yellow] Please select an option from the menu below [/]");

            var prompt = new SelectionPrompt<string>();

            prompt.Title("");
            prompt.PageSize(10);
            prompt.MoreChoicesText("[grey](Move up and down to reveal more items)[/]");

            for (int i = 0; i < list.Count; i++)
            {
                prompt.AddChoice($"{i + 1}: {list[i]}");
            }
            prompt.AddChoice($"{list.Count + 1}: Exit");

            var selected = AnsiConsole.Prompt(prompt);

            int selectedIndex = int.Parse(selected.Split(":")[0]) - 1;

            if (selectedIndex != -1)
            {
                return selectedIndex + 1;
            }
            else
            {

                return -1;
            }


        }

        public static void ReturnToMainMenu(string pMessage, string colour) 
        {

            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine($"[invert {colour}]{pMessage}[/]");
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[bold yellow]Press Any Key To Return To The Main Menu[/]");
            Console.ReadKey();
            

        }

        public static string GetValidName(string nameType, string model)
        {
            bool isValid = false;

            string result = string.Empty;

            do
            {

                AnsiConsole.MarkupLine($"[bold yellow]Please Enter the {nameType} for the {model} You Would Like to Add[/]");

                string userInput = Console.ReadLine()!;

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

        public static int GetValidInt(string message, int range)
        {
            bool isValid = false;

            int result = 0;

            do
            {

                AnsiConsole.MarkupLine($"[bold yellow]{message}[/]");

                string userInput = Console.ReadLine()!;

                AnsiConsole.WriteLine("");

                try
                {
                    result = int.Parse(userInput);
                }
                catch
                {
                    AnsiConsole.MarkupLine($"[red3]{userInput} Is Not A Number[/]");
                    continue;
                }

                if (result > 0 && result < range)
                {
                    isValid = true;
                    return result;
                }
                else
                {
                    AnsiConsole.MarkupLine($"[red3]You must enter a number between 1 & {range} to continue[/]");
                    continue;
                }


            } while (!isValid);

            return result;
        }

    }
}
