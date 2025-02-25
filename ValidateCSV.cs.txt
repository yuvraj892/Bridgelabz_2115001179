using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using CsvHelper;

class ValidateCSV
{
    public static void Main(string[] args)
    {
        // Read the CSV file
        using (var reader = new StreamReader("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\contacts.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            // Get all records from the CSV file
            var records = csv.GetRecords<Contact>();

            // Counter for row number
            int rowNumber = 1;

            // Process each record for validation
            foreach (var record in records)
            {
                // Increment row counter
                rowNumber++;

                // Flag to track if current record has errors
                bool hasError = false;

                // Validate email format using regex
                if (!IsValidEmail(record.Email))
                {
                    // Print error message for invalid email
                    Console.WriteLine("Row " + rowNumber + ": Invalid email format - " + record.Email);
                    hasError = true;
                }

                // Validate phone number (exactly 10 digits)
                if (!IsValidPhoneNumber(record.Phone))
                {
                    // Print error message for invalid phone number
                    Console.WriteLine("Row " + rowNumber + ": Invalid phone number - " + record.Phone);
                    hasError = true;
                }

                // Print full record if it has any errors
                if (hasError)
                {
                    Console.WriteLine("Invalid Record: ID=" + record.ID +
                                    ", Name=" + record.Name +
                                    ", Email=" + record.Email +
                                    ", Phone=" + record.Phone);
                    Console.WriteLine();
                }
            }
        }
    }

    // Method to validate email format
    private static bool IsValidEmail(string email)
    {
        // Check if email is null or empty
        if (string.IsNullOrEmpty(email))
            return false;

        // Use regex to validate email format
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, pattern);
    }

    // Method to validate phone number
    private static bool IsValidPhoneNumber(string phone)
    {
        // Check if phone is null or empty
        if (string.IsNullOrEmpty(phone))
            return false;

        // Remove any non-digit characters
        string digitsOnly = Regex.Replace(phone, @"\D", "");

        // Check if the result has exactly 10 digits
        return digitsOnly.Length == 10;
    }
}

// Class to represent a contact record
class Contact
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}