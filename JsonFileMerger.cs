using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonFileMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths to JSON files
                string file1Path = "D:\\Cspract\\26 feb\\data1.json";
                string file2Path = "D:\\Cspract\\26 feb\\data2.json";
                string outputPath = "merged.json";

                // Create sample data if files don't exist
                if (!File.Exists(file1Path))
                {
                    string sampleJson1 = @"{
                        'personalInfo': {
                            'name': 'John Doe',
                            'age': 30,
                            'email': 'john@example.com'
                        },
                        'address': {
                            'street': '123 Main St',
                            'city': 'New York',
                            'zip': '10001'
                        }
                    }";
                    File.WriteAllText(file1Path, sampleJson1);
                    Console.WriteLine("Sample data1.json created");
                }

                if (!File.Exists(file2Path))
                {
                    string sampleJson2 = @"{
                        'workInfo': {
                            'company': 'ABC Corp',
                            'position': 'Senior Developer',
                            'yearsOfExperience': 8
                        },
                        'skills': [
                            'C#',
                            'JavaScript',
                            'SQL',
                            'Azure'
                        ]
                    }";
                    File.WriteAllText(file2Path, sampleJson2);
                    Console.WriteLine("Sample data2.json created");
                }

                // Read the JSON files
                string json1Content = File.ReadAllText(file1Path);
                string json2Content = File.ReadAllText(file2Path);

                // Parse the JSON content
                JObject json1 = JObject.Parse(json1Content);
                JObject json2 = JObject.Parse(json2Content);

                // Merge the second object into the first
                json1.Merge(json2);

                // Convert the merged object back to string
                string mergedJson = json1.ToString(Formatting.Indented);

                // Save the merged JSON to a new file
                File.WriteAllText(outputPath, mergedJson);

                // Print the merged JSON
                Console.WriteLine("\nMerged JSON:");
                Console.WriteLine(mergedJson);
                Console.WriteLine("\nMerged JSON saved to " + outputPath);
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
