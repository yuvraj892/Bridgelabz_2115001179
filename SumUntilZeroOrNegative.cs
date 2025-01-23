using System;
class SumUntilZeroOrNegative
{
    static void Main()
    {
        double total = 0;
        Console.WriteLine("Enter numbers:");
        while (true)
        {
            double userInput = Convert.ToDouble(Console.ReadLine());
            if (userInput <= 0)
            {
                break;
            }
            total += userInput;
        }
        Console.WriteLine("The total sum is: " + total);
    }
}