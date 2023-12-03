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

        public static Table DisplayPortTable(List<PortModel> ports)
        {
            var table = new Table();

            table.Title("Ports");

            table.Centered().Expand().Width(100);
            table.Border(TableBorder.Rounded);

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

        public static Table DisplayPassengerTable(List<PassengerModel> passengers)
        {
            var table = new Table();

            table.Title("Passengers");

            table.Expand().Centered().Width(100);
            table.Border(TableBorder.Rounded);

            table.AddColumn("First Name");
            table.AddColumn("Last Name");
            table.AddColumn("Passport Number");

            foreach (var p in passengers)
            {
                table.AddRow($"{p.FirstName}", $"{p.LastName}", $"{p.PassportNumber}");
            }

            return table;
        }

        public static Table DisplayCruiseTable(List<CruiseModel> cruises)
        {
            var table = new Table();

            table.Title("Cruises");

            table.Expand().Centered().Width(100);
            table.Border(TableBorder.Rounded);

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

        public static int GetSelection<T>(List<T> list, string option)
        {
            AnsiConsole.MarkupLine($"Please select a [bold yellow]{option}[/]");

            var prompt = new SelectionPrompt<string>();

            prompt.Title("Cruises");
            prompt.PageSize(10);
            prompt.MoreChoicesText("[grey](Move up and down to reveal more items)[/]");

            for (int i = 0; i < list.Count; i++)
            {
                prompt.AddChoice($"{i + 1}: {list[i]}");
            }
            prompt.AddChoice($"{list.Count + 1}: Return To Main Menu");

            var selected = AnsiConsole.Prompt(prompt);

            // Find the index of the selected item in the list
            int selectedIndex = int.Parse(selected.Split(":")[0]) - 1;

            if (selectedIndex != -1)
            {
                // Return the index (adding 1 to match the displayed index)
                return selectedIndex + 1;
            }
            else
            {
                // Handle case where the selected item is not found in the list
                return -1; // Or any other value to indicate failure
            }


        }


    }
}
