using System;
using System.Text.RegularExpressions;

class UsernameValidation
{
    static void Main(string[] args)
    {
        // Test cases for username validation
        string[] usernames = { "user_123", "123user", "us", "valid_username", "invalid@user" };

        // Regex pattern: Start with letter, followed by 4-14 letters/numbers/underscores
        string pattern = @"^[a-zA-Z][a-zA-Z0-9_]{4,14}$";

        foreach (string username in usernames)
        {
            // Check if username matches the pattern
            bool isValid = Regex.IsMatch(username, pattern);
           
            // Format and display the result
            string result = string.Format("Username '{0}' is {1}", username, isValid ? "valid" : "invalid");
            Console.WriteLine(result);
        }
    }
}
