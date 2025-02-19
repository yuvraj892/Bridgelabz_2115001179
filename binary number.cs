using System;
using System.Collections.Generic;

class GenerateBinaryNumbers
{
    // Method to generate the first N binary numbers using a queue
    public static List<string> GenerateBinary(int n)
    {
        // Create a list to store the results
        List<string> binaryNumbers = new List<string>();
       
        // Check if n is valid
        if (n <= 0)
        {
            // Return empty list for invalid input
            return binaryNumbers;
        }
       
        // Create a queue to generate binary numbers
        Queue<string> queue = new Queue<string>();
       
        // Enqueue the first binary number
        queue.Enqueue("1");
       
        // Generate the first n binary numbers
        for (int i = 0; i < n; i++)
        {
            // Dequeue a binary number from the front
            string current = queue.Dequeue();
           
            // Add it to the result list
            binaryNumbers.Add(current);
           
            // Append 0 to the current binary number and enqueue
            queue.Enqueue(current + "0");
           
            // Append 1 to the current binary number and enqueue
            queue.Enqueue(current + "1");
        }
       
        // Return the list of binary numbers
        return binaryNumbers;
    }
   
    static void Main(string[] args)
    {
        // Number of binary numbers to generate
        int n = 10;
       
        // Generate binary numbers
        List<string> binaryNumbers = GenerateBinary(n);
       
        // Print the generated binary numbers
        Console.WriteLine("First " + n + " binary numbers:");
        // Iterate through the generated binary numbers
        for (int i = 0; i < binaryNumbers.Count; i++)
        {
            // Print each binary number with its decimal equivalent
            Console.WriteLine((i + 1) + ". " + binaryNumbers[i] + " (Decimal: " + Convert.ToInt32(binaryNumbers[i], 2) + ")");
        }
       
        // Test with different value of n
        n = 5;
       
        // Generate binary numbers for new n
        binaryNumbers = GenerateBinary(n);
       
        // Print the new set of binary numbers
        Console.WriteLine("\nFirst " + n + " binary numbers:");
        // Iterate through the generated binary numbers
        for (int i = 0; i < binaryNumbers.Count; i++)
        {
            // Print each binary number with its decimal equivalent
            Console.WriteLine((i + 1) + ". " + binaryNumbers[i] + " (Decimal: " + Convert.ToInt32(binaryNumbers[i], 2) + ")");
        }
       
        // Test with invalid input
        n = 0;
       
        // Generate binary numbers for invalid n
        binaryNumbers = GenerateBinary(n);
       
        // Print the result for invalid input
        Console.WriteLine("\nBinary numbers for n = " + n + ":");
        // Check if the list is empty
        if (binaryNumbers.Count == 0)
        {
            // Print a message for empty list
            Console.WriteLine("No binary numbers generated for invalid input.");
        }
    }
}
 