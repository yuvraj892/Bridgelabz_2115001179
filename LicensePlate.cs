using System;
using System.Text.RegularExpressions;

class LicensePlateValidation
{
    static void Main(string[] args)
    {
        // Test cases for license plate validation
        string[] plates = { "AB1234", "A12345", "ABC123", "12ABCD" };

        // Regex pattern: Two uppercase letters followed by exactly 4 digits
        string pattern = @"^[A-Z]{2}\d{4}$";

        foreach (string plate in plates)
        {
            // Check if license plate matches the pattern
            bool isValid = Regex.IsMatch(plate, pattern);
           
            // Format and display the result
            string result = string.Format("License plate '{0}' is {1}", plate, isValid ? "valid" : "invalid");
            Console.WriteLine(result);
        }
    }
}
