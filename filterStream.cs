using System;
using System.IO;
using System.Text;

namespace UppercaseToLowercase
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define source and destination file paths
            string sourceFilePath = "uppercase.txt";
            string destFilePath = "lowercase.txt";

            try
            {
                // Check if source file exists
                if (!File.Exists(sourceFilePath))
                {
                    // Create a sample file with uppercase text for testing
                    CreateSampleFile(sourceFilePath);
                }

                // Convert uppercase to lowercase
                ConvertUppercaseToLowercase(sourceFilePath, destFilePath);
               
                // Display success message
                Console.WriteLine("Conversion completed successfully from " + sourceFilePath + " to " + destFilePath);
               
                // Display a preview of both files
                DisplayFilePreview(sourceFilePath, "Source file preview");
                DisplayFilePreview(destFilePath, "Destination file preview");
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

        // Method to create a sample file with uppercase text
        static void CreateSampleFile(string filePath)
        {
            // Sample text with mixed case
            string sampleText = @"THIS IS AN EXAMPLE FILE with MIXED case Text.
SOME LINES ARE ALL UPPERCASE.
Some lines are mixed Case.
this line is mostly lowercase.
PROGRAMMING in C# IS FUN!
The End.";

            try
            {
                // Write sample text to file
                File.WriteAllText(filePath, sampleText);
                Console.WriteLine("Sample file created: " + filePath);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error creating sample file: " + ex.Message);
                throw;
            }
        }

        // Method to convert uppercase to lowercase
        static void ConvertUppercaseToLowercase(string sourcePath, string destPath)
        {
            try
            {
                // Define encoding to handle character encoding issues
                Encoding encoding = Encoding.UTF8;

                // Create file stream for reading
                using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                // Create buffered stream for efficient reading
                using (BufferedStream bufferedSource = new BufferedStream(sourceStream))
                // Create StreamReader with specific encoding
                using (StreamReader reader = new StreamReader(bufferedSource, encoding))
               
                // Create file stream for writing
                using (FileStream destStream = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                // Create buffered stream for efficient writing
                using (BufferedStream bufferedDest = new BufferedStream(destStream))
                // Create StreamWriter with same encoding
                using (StreamWriter writer = new StreamWriter(bufferedDest, encoding))
                {
                    string line;
                   
                    // Read and process line by line
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Convert the line to lowercase
                        string lowercaseLine = line.ToLower();
                       
                        // Write converted line to destination
                        writer.WriteLine(lowercaseLine);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error during conversion: " + ex.Message);
                throw;
            }
        }

        // Method to display a preview of file contents
        static void DisplayFilePreview(string filePath, string header)
        {
            try
            {
                // Read all text from file
                string content = File.ReadAllText(filePath);
               
                // Display header
                Console.WriteLine("\n" + header + ":");
                Console.WriteLine("----------------------------------------");
               
                // Display up to first 200 characters
                if (content.Length > 200)
                {
                    // Truncate and add ellipsis
                    Console.WriteLine(content.Substring(0, 200) + "...");
                }
                else
                {
                    // Display full content
                    Console.WriteLine(content);
                }
                Console.WriteLine("----------------------------------------");
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error displaying file preview: " + ex.Message);
            }
        }
    }
}
