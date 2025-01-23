using System;
class PrintOddEven
{
    static void Main()
    {
        Console.Write("Enter a positive integer: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if (n <= 0)
        {
            Console.WriteLine("The number is not a natural number.");
            return;
        }
        for (int i = 1; i <= n; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i + " is even.");
            }
            else
            {
                Console.WriteLine(i + " is odd.");
            }
        }
    }
}