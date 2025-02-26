using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonFieldExtractor
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
                JArray usersArray = JArray.Parse(jsonContent);

                // Extract and print specific fields from each object
                Console.WriteLine("Extracted Fields:");
                Console.WriteLine("----------------");

                foreach (JObject user in usersArray)
                {
                    // Extract only name and email fields
                    string name = user["name"].ToString();
                    string email = user["email"].ToString();

                    // Print the extracted fields
                    Console.WriteLine("Name: " + name);
                    Console.WriteLine("Email: " + email);
                    Console.WriteLine();
                }
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
