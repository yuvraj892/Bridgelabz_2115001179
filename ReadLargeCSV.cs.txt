using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

class ReadLargeCSV
{
    public static void Main(string[] args)
    {
        // Path to the large CSV file
        string filePath = "D:\\AVS\\BridgeLabz\\assignment\\25 feb\\large_data.csv";

        // Counter for total records processed
        int totalRecordsProcessed = 0;

        // Chunk size (number of records to process at once)
        int chunkSize = 100;

        // Create CSV configuration
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            // Set to true to allow handling missing fields
            MissingFieldFound = null,
            // Set to true to allow handling bad data
            BadDataFound = null
        };

        // Open file stream for reading
        using (var stream = new StreamReader(filePath))
        using (var csv = new CsvReader(stream, config))
        {
            // Register class map if your CSV has headers
            csv.Context.RegisterClassMap<DynamicRecordMap>();

            // Read records in chunks
            var records = new List<dynamic>();
            int currentChunkSize = 0;

            // Read and process each record
            while (csv.Read())
            {
                // Parse the current record
                var record = csv.GetRecord<dynamic>();

                // Process the record (simply counting here)
                currentChunkSize++;
                totalRecordsProcessed++;

                // When chunk size is reached, process the chunk
                if (currentChunkSize >= chunkSize)
                {
                    // Display progress
                    Console.WriteLine("Processed " + totalRecordsProcessed + " records so far...");

                    // Reset for next chunk
                    currentChunkSize = 0;
                    records.Clear();
                }
            }
        }

        // Display final count
        Console.WriteLine("Processing complete. Total records processed: " + totalRecordsProcessed);
    }
}

// Class to map CSV columns to properties dynamically
public sealed class DynamicRecordMap : ClassMap<dynamic>
{
    public DynamicRecordMap()
    {
        // Map automatically without needing to know the schema
        AutoMap(CultureInfo.InvariantCulture);
    }
}