using System;
using System.Reflection;

namespace ReflectionPractice
{
    // Configuration class with static field
    public class Configuration
    {
        // Private static field for API key
        private static string API_KEY = "default_key_12345";

        // Method to verify API key
        public static void DisplayApiKey()
        {
            Console.WriteLine("Current API Key: " + API_KEY);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Get type information
                Type type = typeof(Configuration);

                // Get field info for static field
                FieldInfo fieldInfo = type.GetField("API_KEY", 
                    BindingFlags.NonPublic | BindingFlags.Static);

                // Check if field exists
                if (fieldInfo == null)
                {
                    Console.WriteLine("API_KEY field not found!");
                    return;
                }

                // Display current value
                string currentKey = (string)fieldInfo.GetValue(null);
                Console.WriteLine("Current API Key: " + currentKey);

                // Get new key from user
                Console.WriteLine("Enter new API Key:");
                string newKey = Console.ReadLine();

                // Update the static field
                fieldInfo.SetValue(null, newKey);

                // Verify the change
                Console.WriteLine("API Key updated successfully!");
                Configuration.DisplayApiKey();
            }
            catch (Exception ex)
            {
                // Display any errors that occur
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            // Wait for user input before closing
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}