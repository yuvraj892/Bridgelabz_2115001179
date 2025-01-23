using System;
class Factorial
{
    static void Main()
    {
        //input a number
        Console.Write("Enter a positive integer: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if (n < 0)
        {
            Console.WriteLine("The number is not a positive integer.");
            return;
        }
        int factorial = 1; //store the factorial
        int i = 1;
        // Using a while loop to calculate the factorial
        while (i <= n)
        {
            factorial *= i; // Multiplying the current number to the factorial
            i++; // Incrementing the counter
        }
        Console.WriteLine("The factorial of " + n + " is: " + factorial);
    }
}