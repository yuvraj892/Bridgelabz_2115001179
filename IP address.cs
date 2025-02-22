using System;
using System.Text.RegularExpressions;

class IpAddressValidation
{
    static void Main(string[] args)
    {
        // Test cases for IP address validation
        string[] ipAddresses = {
            "192.168.1.1",
            "256.1.2.3",
            "1.2.3.4",
            "192.168.001.1",
            "192.168.1.1.1",
            "192.168.1"
        };

        // Regex pattern for IPv4 validation
        // Matches numbers 0-255 separated by dots
        string pattern = @"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

        // Test each IP address
        foreach (string ip in ipAddresses)
        {
            // Check if IP matches the pattern
            bool isValid = Regex.IsMatch(ip, pattern);
           
            // Format and display the result
            string result = string.Format("IP Address '{0}' is {1}", ip, isValid ? "valid" : "invalid");
            Console.WriteLine(result);
        }
    }
}
