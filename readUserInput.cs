using System;
using System.IO;

namespace ConsoleInputReader
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create StreamReader to read from console
                using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
                {
                    // Create StreamWriter to write to file
                    using (StreamWriter writer = new StreamWriter("user_info.txt"))
                    {
                        // Prompt for name
                        Console.Write("Enter your name: ");
                        // Read user's name
                        string name = reader.ReadLine();

                        // Prompt for age
                        Console.Write("Enter your age: ");
                        // Read user's age
                        string age = reader.ReadLine();

                        // Prompt for favorite programming language
                        Console.Write("Enter your favorite programming language: ");
                        // Read user's favorite programming language
                        string language = reader.ReadLine();

                        // Write collected information to file
                        writer.WriteLine("User Information:");
                        writer.WriteLine("Name: " + name);
                        writer.WriteLine("Age: " + age);
                        writer.WriteLine("Favorite Programming Language: " + language);
                        writer.WriteLine("Date Recorded: " + DateTime.Now.ToString());

                        // Inform user that information was saved
                        Console.WriteLine("Information saved successfully to user_info.txt");
                    }
                }
            }
            catch (IOException ex)
            {
                // Handle IO exceptions
                Console.WriteLine("An IO error occurred: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            // Wait for user to press a key before closing
            Console.ReadKey();
        }
    }
}
