using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "D:\\Capgemini-Tranning\\Assignments\\Assignment16\\ReadUserInput\\sample.txt";

        try
        {
            Console.WriteLine("Enter text to save in the file (Type 'exit' to stop):");

            using (StreamWriter writer = new StreamWriter(filePath, false)) // Overwrites file
            {
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input.ToLower() == "exit") // Stop condition
                        break;

                    writer.WriteLine(input);
                }
            }

            Console.WriteLine("User input has been successfully saved to the file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
