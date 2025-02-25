using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using CsvHelper;

class UpdateCSV
{
    public static void Main(string[] args)
    {
        // List to store all employee records
        List<Employee> employees = new List<Employee>();

        // Read the original CSV file
        using (var reader = new StreamReader("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\employees.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            // Get all records from the CSV file
            var records = csv.GetRecords<Employee>();

            // Process each record
            foreach (var record in records)
            {
                // Check if employee is from IT department
                if (record.Department == "IT")
                {
                    // Increase salary by 10%
                    record.Salary = record.Salary * 1.1m;
                }

                // Add the record to our list
                employees.Add(record);
            }
        }

        // Write updated records to a new CSV file
        using (var writer = new StreamWriter("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\employees_updated.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            // Write all records to the new file
            csv.WriteRecords(employees);
        }

        // Display confirmation message
        Console.WriteLine("CSV file updated successfully. IT department salaries increased by 10%.");
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