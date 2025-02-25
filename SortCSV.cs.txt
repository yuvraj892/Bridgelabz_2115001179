using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CsvHelper;

class SortCSV
{
    public static void Main(string[] args)
    {
        // List to store all employee records
        List<Employee> employees = new List<Employee>();

        // Read the CSV file
        using (var reader = new StreamReader("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\employees.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            // Get all records from the CSV file and convert to list
            employees = csv.GetRecords<Employee>().ToList();
        }

        // Sort employees by salary in descending order
        var sortedEmployees = employees.OrderByDescending(e => e.Salary).ToList();

        // Print the top 5 highest-paid employees
        Console.WriteLine("Top 5 Highest-Paid Employees:");
        for (int i = 0; i < Math.Min(5, sortedEmployees.Count); i++)
        {
            // Print employee details
            Console.WriteLine("ID: " + sortedEmployees[i].ID +
                            ", Name: " + sortedEmployees[i].Name +
                            ", Department: " + sortedEmployees[i].Department +
                            ", Salary: " + sortedEmployees[i].Salary);
        }
    }
}

// Class to represent an employee record
class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
}