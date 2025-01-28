using System;
class NaturalNumberSum
{
    // Recursive method to calculate sum of n natural numbers
    static int SumRecursive(int n)
    {
        if (n == 1) return 1; // Base case
        return n + SumRecursive(n - 1);
    }

    // Method to calculate sum using formula
    static int SumFormula(int n)
    {
        return n * (n + 1) / 2;
    }

    static void Main()
    {
        Console.Write("Enter a natural number: ");
        int n;
        if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Invalid input! Please enter a natural number (n > 0).");
            return;
        }

        // Compute sum using recursion and formula
        int sumRec = SumRecursive(n);
        int sumForm = SumFormula(n);
        // Display results
        Console.WriteLine($"Sum using recursion: {sumRec}");
        Console.WriteLine($"Sum using formula: {sumForm}");
        // Verify both methods give the same result
        Console.WriteLine(sumRec == sumForm ? "Both methods give the same result" : "Results do not match");
    }
}
