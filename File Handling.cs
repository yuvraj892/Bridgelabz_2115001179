using System;
using System.IO;

namespace FileHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define source and destination file paths
            string sourceFilePath = @"source.txt";
            string destFilePath = @"destination.txt";

            try
            {
                // Check if source file exists
                if (!File.Exists(sourceFilePath))
                {
                    // Display appropriate message if source file doesn't exist
                    Console.WriteLine("Source file does not exist: " + sourceFilePath);
                    return;
                }

                // Create FileStream for reading from source file
                using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
                {
                    // Create FileStream for writing to destination file (creates if doesn't exist)
                    using (FileStream destStream = new FileStream(destFilePath, FileMode.Create, FileAccess.Write))
                    {
                        // Create a buffer to hold file data during transfer
                        byte[] buffer = new byte[4096];
                        int bytesRead;

                        // Read from source and write to destination in chunks
                        while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            // Write the read bytes to destination
                            destStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }

                // Inform user of successful file copy
                Console.WriteLine("File copied successfully from " + sourceFilePath + " to " + destFilePath);
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
  