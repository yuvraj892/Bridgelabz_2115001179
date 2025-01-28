using System;
class Remainder {
    static void Main(string[] args) {
        // Take user input
        Console.WriteLine("number:");
        int num = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("divisor:");
        int div = Convert.ToInt32(Console.ReadLine());
        // Find and display the remainder and quotient
        int[] result = FindRemainderAndQuotient(num, div);
        Console.WriteLine("Quotient: " + result[1]);
        Console.WriteLine("Remainder: " + result[0]);
    }
    public static int[] RemainderAndQuotient(int number, int divisor) {
        int remainder = num % div; // Calculate remainder
        int quotient = num / div; // Calculate quotient
        return new int[] { remainder, quotient };
    }
}
