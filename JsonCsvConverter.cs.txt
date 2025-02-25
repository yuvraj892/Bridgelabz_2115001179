using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using CsvHelper;

class JsonCsvConverter
{
    public static void Main(string[] args)
    {
        // Call the JSON to CSV conversion method
        Console.WriteLine("Converting JSON to CSV...");
        ConvertJsonToCsv();

        // Call the CSV to JSON conversion method
        Console.WriteLine("\nConverting CSV to JSON...");
        ConvertCsvToJson();
    }

    // Method to convert JSON file to CSV
    private static void ConvertJsonToCsv()
    {
        try
        {
            // Read JSON file content
            string jsonContent = File.ReadAllText("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\students.json");

            // Deserialize JSON to list of Student objects
            List<Student> students = JsonSerializer.Deserialize<List<Student>>(jsonContent);

            // Write to CSV file
            using (var writer = new StreamWriter("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\students_from_json.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                // Write all records to the file
                csv.WriteRecords(students);
            }

            // Display success message
            Console.WriteLine("JSON to CSV conversion completed successfully.");
        }
        catch (Exception ex)
        {
            // Display error message
            Console.WriteLine("Error converting JSON to CSV: " + ex.Message);
        }
    }

    // Method to convert CSV file to JSON
    private static void ConvertCsvToJson()
    {
        try
        {
            // List to store student objects
            List<Student> students = new List<Student>();

            // Read CSV file
            using (var reader = new StreamReader("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\students.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Get all records and convert to list
                students = csv.GetRecords<Student>().ToList();
            }

            // Serialize to JSON
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true // For pretty-printing the JSON
            };
            string jsonString = JsonSerializer.Serialize(students, options);

            // Write to JSON file
            File.WriteAllText("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\students_from_csv.json", jsonString);

            // Display success message
            Console.WriteLine("CSV to JSON conversion completed successfully.");
        }
        catch (Exception ex)
        {
            // Display error message
            Console.WriteLine("Error converting CSV to JSON: " + ex.Message);
        }
    }
}

// Class to represent a student record
class Student
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }
}