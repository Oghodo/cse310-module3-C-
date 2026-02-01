using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Entry point for the Employee Management System
/// </summary>
class Program
{
    static List<Employee> employees = new List<Employee>();
    static string filePath = "employees.txt";

    static void Main()
    {
        LoadFromFile();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nEmployee Management System");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. List Employees");
            Console.WriteLine("3. Save and Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddEmployee();
                    break;
                case "2":
                    ListEmployees();
                    break;
                case "3":
                    SaveToFile();
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    /// <summary>
    /// Adds a new employee to the list
    /// </summary>
    static void AddEmployee()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.Write("Enter department: ");
        string deptName = Console.ReadLine();
        Department dept = new Department { Name = deptName };

        Console.Write("Employee type (1 = Full Time, 2 = Part Time): ");
        string type = Console.ReadLine();

        if (type == "1")
        {
            Console.Write("Enter salary: ");
            double salary = double.Parse(Console.ReadLine());
            employees.Add(new FullTimeEmployee(name, dept, salary));
        }
        else
        {
            Console.Write("Enter hourly rate: ");
            double rate = double.Parse(Console.ReadLine());
            employees.Add(new PartTimeEmployee(name, dept, rate));
        }
    }

    /// <summary>
    /// Displays all employees
    /// </summary>
    static void ListEmployees()
    {
        foreach (Employee emp in employees)
        {
            Console.WriteLine(emp.GetInfo());
        }
    }

    /// <summary>
    /// Saves employee data to a file
    /// </summary>
    static void SaveToFile()
    {
        using StreamWriter writer = new StreamWriter(filePath);
        foreach (Employee emp in employees)
        {
            writer.WriteLine(emp.ToFileString());
        }
    }

    /// <summary>
    /// Loads employee data from a file
    /// </summary>
    static void LoadFromFile()
    {
        if (!File.Exists(filePath)) return;

        foreach (string line in File.ReadAllLines(filePath))
        {
            string[] parts = line.Split('|');
            Department dept = new Department { Name = parts[2] };

            if (parts[0] == "FT")
                employees.Add(new FullTimeEmployee(parts[1], dept, double.Parse(parts[3])));
            else
                employees.Add(new PartTimeEmployee(parts[1], dept, double.Parse(parts[3])));
        }
    }
}
