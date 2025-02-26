using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CsvToJsonConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the CSV file
                string csvFilePath = "data.csv";
                string jsonFilePath = "output.json";

                // Create sample CSV if file doesn't exist
                if (!File.Exists(csvFilePath))
                {
                    string sampleCsv = @"Id,Name,Department,Salary
1,John Doe,Engineering,75000
2,Jane Smith,Marketing,65000
3,Bob Johnson,Finance,80000
4,Alice Brown,Human Resources,60000
5,Mike Wilson,IT,85000";

                    File.WriteAllText(csvFilePath, sampleCsv);
                    Console.WriteLine("Sample CSV file created: data.csv");
                }

                // Read all lines from the CSV file
                string[] csvLines = File.ReadAllLines(csvFilePath);

                // Get the header row and parse column names
                string[] headers = csvLines[0].Split(',');

                // Process each data row
                List<Dictionary<string, string>> dataList = new List<Dictionary<string, string>>();

                // Start from index 1 to skip the header row
                for (int i = 1; i < csvLines.Length; i++)
                {
                    string[] values = csvLines[i].Split(',');
                    Dictionary<string, string> rowData = new Dictionary<string, string>();

                    // Add each column value with its header
                    for (int j = 0; j < headers.Length; j++)
                    {
                        // Ensure we don't go out of bounds if a row has fewer columns
                        if (j < values.Length)
                        {
                            rowData[headers[j]] = values[j];
                        }
                        else
                        {
                            rowData[headers[j]] = "";
                        }
                    }

                    dataList.Add(rowData);
                }

                // Convert to JSON
                string json = JsonConvert.SerializeObject(dataList, Formatting.Indented);

                // Save to JSON file
                File.WriteAllText(jsonFilePath, json);

                // Print the result
                Console.WriteLine("\nConverted JSON:");
                Console.WriteLine("--------------");
                Console.WriteLine(json);
                Console.WriteLine("\nJSON saved to " + jsonFilePath);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}
