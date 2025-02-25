using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CsvHelper;

class DetectDuplicates
{
    public static void Main(string[] args)
    {
        // Dictionary to track occurrences of each ID
        Dictionary<int, List<Record>> recordsById = new Dictionary<int, List<Record>>();

        // Read the CSV file
        using (var reader = new StreamReader("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\data.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            // Get all records from the CSV file
            var records = csv.GetRecords<Record>();

            // Process each record to find duplicates
            foreach (var record in records)
            {
                // Check if this ID has been seen before
                if (!recordsById.ContainsKey(record.ID))
                {
                    // If not, create a new list for this ID
                    recordsById[record.ID] = new List<Record>();
                }

                // Add the record to the list for this ID
                recordsById[record.ID].Add(record);
            }
        }

        // Flag to track if any duplicates were found
        bool duplicatesFound = false;

        // Print all duplicate records
        Console.WriteLine("Duplicate Records by ID:");
        foreach (var entry in recordsById)
        {
            // Check if there are multiple records with the same ID
            if (entry.Value.Count > 1)
            {
                // Display the duplicate ID
                Console.WriteLine("Duplicate ID: " + entry.Key);

                // Display each duplicate record
                foreach (var record in entry.Value)
                {
                    Console.WriteLine("  - Name: " + record.Name +
                                    ", Department: " + record.Department +
                                    ", Salary: " + record.Salary);
                }

                // Add empty line between duplicate sets
                Console.WriteLine();

                // Set flag indicating duplicates were found
                duplicatesFound = true;
            }
        }

        // If no duplicates were found, display message
        if (!duplicatesFound)
        {
            Console.WriteLine("No duplicate records found.");
        }
    }
}

// Class to represent a record
class Record
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
}