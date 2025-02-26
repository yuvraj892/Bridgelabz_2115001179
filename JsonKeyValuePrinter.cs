using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace JsonKeyValuePrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the JSON file
                string filePath = "D:\\Cspract\\26 feb\\users.json";

                // Read the JSON file content
                string jsonContent = File.ReadAllText(filePath);

                // Parse the JSON content
                JToken jsonData = JToken.Parse(jsonContent);

                // Print all keys and values
                Console.WriteLine("JSON Keys and Values:");
                Console.WriteLine("--------------------");

                // Call recursive function to print all keys and values
                PrintJsonKeyValues(jsonData);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadKey();
        }

        // Recursive function to print all keys and values in JSON
        static void PrintJsonKeyValues(JToken token, string prefix = "")
        {
            // Handle different token types
            switch (token.Type)
            {
                case JTokenType.Object:
                    // Process each property in the object
                    foreach (JProperty prop in token.Children<JProperty>())
                    {
                        // Print property name
                        Console.WriteLine(prefix + "Key: " + prop.Name);

                        // Process property value
                        PrintJsonKeyValues(prop.Value, prefix + "  ");
                    }
                    break;

                case JTokenType.Array:
                    // Process each item in the array
                    int index = 0;
                    foreach (JToken item in token.Children())
                    {
                        // Print array index
                        Console.WriteLine(prefix + "Index: " + index);

                        // Process array item
                        PrintJsonKeyValues(item, prefix + "  ");
                        index++;
                    }
                    break;

                default:
                    // Print simple value
                    Console.WriteLine(prefix + "Value: " + token.ToString());
                    break;
            }
        }
    }
}
