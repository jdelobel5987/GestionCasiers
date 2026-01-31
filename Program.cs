// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;
using GestionCasiers.Models;

List<Casier> casiers = new List<Casier>();


Console.WriteLine("This is a locker management system.");

mainMenu:
Console.WriteLine("Choose an option:");
Console.WriteLine("1. Create a new Casier");
if (casiers.Count > 0)  // don't display options that require existing casiers
{
    Console.WriteLine("2. Get Casier info");
    Console.WriteLine("3. Deposit items");
    Console.WriteLine("4. Withdraw items");
}
Console.WriteLine("5. Exit");

int option;
// while (true)
// {
//     Console.Write("Enter option number: ");
//     var input = Console.ReadLine();
//     if (!int.TryParse(input, out option))
//     {
//         Console.WriteLine("Invalid input — please enter a number.");
//         continue;
//     }
//     // Don't allow options 2-4 when there are no casiers yet
//     if (casiers.Count == 0 && (option == 2 || option == 3 || option == 4))
//     {
//         Console.WriteLine("Unavailable option. Please create a Casier first.");
//         continue;
//     }
//     if (option < 1 || option > 5)
//     {
//         Console.WriteLine("Please choose a valid option between 1 and 5.");
//         continue;
//     }
//     break;
// }

Console.WriteLine("\nEnter option number: ");

while (!int.TryParse(Console.ReadLine(), out option))
{
    Console.WriteLine("Invalid input - please enter a number.");
    goto mainMenu;
}

switch (option)
{
    case 1:
        Console.WriteLine("Creating a new Casier...");
        int id = casiers.Count + 1;
        Console.WriteLine("Enter dimension (Small, Medium, Large):");
        string dimension = Console.ReadLine() ?? "Medium";
        Console.WriteLine("Enter location (Room 1, Room 2, Room 3):");
        string location = Console.ReadLine() ?? "undefined";
        Casier newCasier = new Casier(id, dimension, location);
        casiers.Add(newCasier);
        Console.WriteLine($"Casier {id} created successfully.");
        goto mainMenu;

    case 2 or 3 or 4 when casiers.Count == 0:
        Console.WriteLine("Unavailable option. Please create a Casier first.");
        goto mainMenu;

    case 2:
        Console.WriteLine("List of existing Casiers:");
        foreach (var casier in casiers)
        {
            Console.WriteLine($"casier ID: {casier.Id}");
        }
        Console.WriteLine("Enter the ID of the Casier you want details for:");
        int casierId = int.Parse(Console.ReadLine() ?? "0");
        casiers[casierId - 1].Info();

        Console.WriteLine("Press any key to return to main menu.");
        Console.ReadKey();
        goto mainMenu;

    case 3:
        goto mainMenu;
    case 4:
        goto mainMenu;
    case 5:
        Console.WriteLine("Exiting...");
        break;
    default:
        Console.WriteLine("Invalid option");
        goto mainMenu;
}
