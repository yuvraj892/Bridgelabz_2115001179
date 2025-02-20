using System;
using System.IO;
using System.Diagnostics;

namespace BufferedStreamsCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define source and destination file paths
            string sourceFile = @"largefile.bin";
            string destFileNormal = @"copy_normal.bin";
            string destFileBuffered = @"copy_buffered.bin";
           
            // Create a test file if it doesn't exist
            CreateLargeTestFile(sourceFile, 100 * 1024 * 1024); // 100MB

            // Copy using normal FileStream
            Stopwatch normalTimer = new Stopwatch();
            normalTimer.Start();
            CopyWithoutBuffer(sourceFile, destFileNormal);
            normalTimer.Stop();

            // Copy using BufferedStream
            Stopwatch bufferedTimer = new Stopwatch();
            bufferedTimer.Start();
            CopyWithBuffer(sourceFile, destFileBuffered);
            bufferedTimer.Stop();

            // Display results
            Console.WriteLine("File copy performance comparison:");
            Console.WriteLine("Normal FileStream: " + normalTimer.ElapsedMilliseconds + " ms");
            Console.WriteLine("Buffered FileStream: " + bufferedTimer.ElapsedMilliseconds + " ms");
            Console.WriteLine("Performance improvement: " +
                ((float)(normalTimer.ElapsedMilliseconds - bufferedTimer.ElapsedMilliseconds) /
                normalTimer.ElapsedMilliseconds * 100).ToString("0.00") + "%");

            // Wait for user input
            Console.ReadKey();
        }

        // Method to create a large test file
        static void CreateLargeTestFile(string filePath, long size)
        {
            // Check if file already exists
            if (File.Exists(filePath))
            {
                // Get file info to check size
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Length >= size)
                {
                    // File exists and is large enough
                    Console.WriteLine("Test file already exists: " + filePath);
                    return;
                }
            }

            // Create a new test file with random data
            Console.WriteLine("Creating test file of size " + (size / (1024 * 1024)) + "MB...");
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                // Initialize random number generator
                Random random = new Random();
                byte[] buffer = new byte[4096]; // 4KB buffer
               
                // Calculate how many buffers we need to write
                long bufferCount = size / buffer.Length;
               
                // Write random data to the file
                for (long i = 0; i < bufferCount; i++)
                {
                    // Fill buffer with random bytes
                    random.NextBytes(buffer);
                    // Write buffer to file
                    fs.Write(buffer, 0, buffer.Length);
                }
            }
            Console.WriteLine("Test file created successfully.");
        }

        // Method to copy file without buffering
        static void CopyWithoutBuffer(string source, string dest)
        {
            try
            {
                // Create FileStream objects for reading and writing
                using (FileStream sourceStream = new FileStream(source, FileMode.Open, FileAccess.Read))
                using (FileStream destStream = new FileStream(dest, FileMode.Create, FileAccess.Write))
                {
                    // Create a buffer for data transfer
                    byte[] buffer = new byte[4096]; // 4KB chunks
                    int bytesRead;
                   
                    // Read and write in chunks
                    while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        // Write read bytes to destination
                        destStream.Write(buffer, 0, bytesRead);
                    }
                }
                Console.WriteLine("Copy without buffer completed: " + source + " to " + dest);
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error copying without buffer: " + ex.Message);
            }
        }

        // Method to copy file with buffering
        static void CopyWithBuffer(string source, string dest)
        {
            try
            {
                // Create FileStream objects
                using (FileStream sourceStream = new FileStream(source, FileMode.Open, FileAccess.Read))
                using (FileStream destStream = new FileStream(dest, FileMode.Create, FileAccess.Write))
                // Wrap with BufferedStream
                using (BufferedStream bufferedSource = new BufferedStream(sourceStream, 4096))
                using (BufferedStream bufferedDest = new BufferedStream(destStream, 4096))
                {
                    // Create a buffer for data transfer
                    byte[] buffer = new byte[4096]; // 4KB chunks
                    int bytesRead;
                   
                    // Read and write in chunks
                    while ((bytesRead = bufferedSource.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        // Write read bytes to destination
                        bufferedDest.Write(buffer, 0, bytesRead);
                    }
                }
                Console.WriteLine("Copy with buffer completed: " + source + " to " + dest);
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error copying with buffer: " + ex.Message);
            }
        }
    }
}
