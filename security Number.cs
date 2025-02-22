using System;
using System.Text.RegularExpressions;

class SSNValidation
{
    static void Main(string[] args)
    {
        // Test cases for SSN validation
        string[] ssnNumbers = {
            "123-45-6789",
            "123456789",
            "123-45-678",
            "123-456-789",
            "12345-6789",
            "900-45-6789"
        };

        // Regex pattern for SSN
        // Format: XXX-XX-XXXX where X is a digit
        string pattern = @"^\d{3}-\d{2}-\d{4}$";

        foreach (string ssn in ssnNumbers)
        {
            // Check if SSN matches the pattern
            bool isValid = Regex.IsMatch(ssn, pattern);
           
            // Format and display the result
            string result = string.Format("SSN '{0}' is {1}", ssn, isValid ? "valid" : "invalid");
            Console.WriteLine(result);
        }
    }
}
