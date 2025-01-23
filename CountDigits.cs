using System;

class CountDigits
{
    static void Main(string[] args)
    {
        //integer input
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        //count variable
        int count = 0;

        //negative numbers
        if (number < 0)
        {
            number = -number;
        }

        //loop to count digits
        do
        {
            number /= 10;
            count++;
        }
        while (number != 0);

        //Display the result
        Console.WriteLine($"The number of digits is: {count}");
    }
}
