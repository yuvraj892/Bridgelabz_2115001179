using System;
class FactorialWithFor
{
    static void Main()
    {
        Console.Write("Enter a positive integer: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if (n < 0)
        {
            Console.WriteLine("The number is not a positive integer.");
            return;
        }

        int factorial = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
        }
        Console.WriteLine("The factorial of " + n + " is: " + factorial);
    }
}
