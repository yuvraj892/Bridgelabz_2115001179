using System;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace LargeFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file path
            string filePath = "large_log_file.txt";
            string searchWord = "error";

            try
            {
                // Create test file if it doesn't exist
                if (!File.Exists(filePath))
                {
                    // Generate large test file
                    GenerateLargeTestFile(filePath);
                }

                // Start stopwatch to measure performance
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                // Read file and find lines containing searchWord
                int totalLines = 0;
                int matchingLines = 0;
               
                // Call the line-by-line reader method
                ReadLargeFileForErrors(filePath, searchWord, ref totalLines, ref matchingLines);
               
                // Stop the stopwatch
                stopwatch.Stop();

                // Display results
                Console.WriteLine("\nFile processing completed.");
                Console.WriteLine("Total lines processed: " + totalLines);
                Console.WriteLine("Lines containing '" + searchWord + "': " + matchingLines);
                Console.WriteLine("Processing time: " + stopwatch.ElapsedMilliseconds + " ms");
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
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Method to read large file line by line and find error lines
        static void ReadLargeFileForErrors(string filePath, string searchWord, ref int totalLines, ref int matchingLines)
        {
            try
            {
                // Create FileStream with sequential optimization
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan))
                // Create StreamReader with appropriate encoding
                using (StreamReader reader = new StreamReader(fs, Encoding.UTF8))
                {
                    // Initialize line counter
                    string line;
                    totalLines = 0;
                    matchingLines = 0;
                   
                    // Create case-insensitive search
                    StringComparison comparison = StringComparison.OrdinalIgnoreCase;
                   
                    // Display progress indicators
                    Console.Write("Processing file");
                    int progressCounter = 0;
                   
                    // Read line by line
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Increment total line count
                        totalLines++;
                       
                        // Check if line contains the search word (case insensitive)
                        if (line.IndexOf(searchWord, comparison) >= 0)
                        {
                            // Increment matching lines count
                            matchingLines++;
                           
                            // Display the line if it contains the search word
                            Console.WriteLine("\n[Match #" + matchingLines + "]: " + line);
                        }
                       
                        // Display progress indicator every 10,000 lines
                        if (totalLines % 10000 == 0)
                        {
                            // Show spinning progress indicator
                            char[] spinChars = new char[] { '|', '/', '-', '\\' };
                            Console.Write("\rProcessing file " + spinChars[progressCounter % 4] + " Lines: " + totalLines);
                            progressCounter++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("\nError reading file: " + ex.Message);
                throw;
            }
        }

        // Method to generate a large test log file
        static void GenerateLargeTestFile(string filePath)
        {
            try
            {
                // Define log message templates
                string[] logLevels = { "INFO", "DEBUG", "WARN", "ERROR", "FATAL" };
                string[] logMessages = {
                    "Application started",
                    "User logged in: user_{0}",
                    "Database connection established",
                    "Query executed in {0}ms",
                    "Cache miss for key: {0}",
                    "API request received from IP: 192.168.1.{0}",
                    "Error processing request: Invalid parameter",
                    "Database query timeout after 30s",
                    "Out of memory error in module: AppModule",
                    "Fatal error: System could not initialize properly"
                };

                // Create a random number generator
                Random random = new Random();

                // Calculate number of lines for ~10MB file
                int targetLines = 100000; // Adjust as needed
               
                Console.WriteLine("Generating test file with " + targetLines + " lines...");

                // Create StreamWriter with buffer
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8, 65536))
                {
                    // Generate log entries
                    for (int i = 0; i < targetLines; i++)
                    {
                        // Get random log level (weighted to have fewer errors)
                        string logLevel = logLevels[GetWeightedRandom(random)];
                       
                        // Get random message template
                        string messageTemplate = logMessages[random.Next(logMessages.Length)];
                       
                        // Format message with random values
                        string message = string.Format(messageTemplate, random.Next(1000));
                       
                        // Generate timestamp
                        DateTime timestamp = DateTime.Now.AddMinutes(-random.Next(0, 24 * 60));
                       
                        // Write log entry
                        writer.WriteLine("[{0}] {1}: {2}",
                            timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                            logLevel,
                            message);
                    }
                }

                Console.WriteLine("Test file generated: " + filePath);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error generating test file: " + ex.Message);
                throw;
            }
        }

        // Helper method to generate weighted random index (to have fewer error logs)
        static int GetWeightedRandom(Random random)
        {
            // 70% INFO, 15% DEBUG, 10% WARN, 4% ERROR, 1% FATAL
            int value = random.Next(100);
           
            if (value < 70) return 0; // INFO
            if (value < 85) return 1; // DEBUG
            if (value < 95) return 2; // WARN
            if (value < 99) return 3; // ERROR
            return 4; // FATAL
        }
    }
}
