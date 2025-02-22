using System;
using System.Text.RegularExpressions;

class CreditCardValidation
{
    static void Main(string[] args)
    {
        // Test cases for credit card validation
        string[] cardNumbers = {
            "4111111111111111",    // Valid Visa
            "5555555555554444",    // Valid MasterCard
            "411111111111111",     // Invalid (15 digits)
            "6111111111111111",    // Invalid (starts with 6)
            "4111-1111-1111-1111", // Invalid (contains hyphens)
            "5111111111111111"     // Valid MasterCard
        };

        // Regex patterns for Visa and MasterCard
        string visaPattern = @"^4\d{15}$";
        string masterCardPattern = @"^5\d{15}$";

        foreach (string card in cardNumbers)
        {
            // Check card type and validity
            bool isVisa = Regex.IsMatch(card, visaPattern);
            bool isMasterCard = Regex.IsMatch(card, masterCardPattern);
           
            // Format and display the result
            string result;
            if (isVisa)
            {
                result = string.Format("'{0}' is a valid Visa card", card);
            }
            else if (isMasterCard)
            {
                result = string.Format("'{0}' is a valid MasterCard", card);
            }
            else
            {
                result = string.Format("'{0}' is not a valid card number", card);
            }
            Console.WriteLine(result);
        }
    }
}
