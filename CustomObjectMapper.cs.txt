using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectionPractice
{
    public class CustomMapper
    {
        // Generic method to map dictionary values to an object's properties
        public static T ToObject<T>(Dictionary<string, object> properties) where T : new()
        {
            // Create instance of T
            T obj = new T();

            // Get type information
            Type type = typeof(T);

            // Loop through each property in dictionary
            foreach (var property in properties)
            {
                // Get corresponding property info in the class
                PropertyInfo propInfo = type.GetProperty(property.Key);

                // Check if property exists and can be set
                if (propInfo != null && propInfo.CanWrite)
                {
                    // Set the value to the object
                    propInfo.SetValue(obj, property.Value);
                }
            }

            return obj;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create dictionary with property values
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                { "Name", "John Doe" },
                { "Age", 30 }
            };

            // Convert dictionary to object
            Person person = CustomMapper.ToObject<Person>(properties);

            // Display mapped values
            Console.WriteLine("Mapped Person Object:");
            Console.WriteLine("Name: " + person.Name);
            Console.WriteLine("Age: " + person.Age.ToString());

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }

    public class Person
    {
        // Public property for name
        public string Name { get; set; }

        // Public property for age
        public int Age { get; set; }
    }
}
