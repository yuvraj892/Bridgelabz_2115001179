using System;
using System.Reflection;

namespace ReflectionPractice
{
    public class JsonConverter
    {
        // Method to convert an object to a JSON-like string
        public static string ToJson(object obj)
        {
            // Get type of the object
            Type type = obj.GetType();

            // Get properties of the object
            PropertyInfo[] properties = type.GetProperties();

            // Start JSON format
            string json = "{ ";

            // Loop through properties to get names and values
            foreach (var prop in properties)
            {
                string name = prop.Name;
                object value = prop.GetValue(obj);

                // Append property name and value
                json += "\"" + name + "\": \"" + value.ToString() + "\", ";
            }

            // Remove last comma and space, then close JSON
            json = json.TrimEnd(',', ' ') + " }";

            return json;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create sample object
            Student student = new Student { Name = "Alice", Age = 22 };

            // Convert object to JSON
            string jsonString = JsonConverter.ToJson(student);

            // Display JSON output
            Console.WriteLine("JSON Representation:");
            Console.WriteLine(jsonString);

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }

    public class Student
    {
        // Public property for name
        public string Name { get; set; }

        // Public property for age
        public int Age { get; set; }
    }
}
