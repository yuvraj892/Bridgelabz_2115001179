using System;

class LeapYear
{
    static void Main(string[] args)
    {
        // Step 1: Get the input year
        Console.Write("Enter a year: ");
        int year = int.Parse(Console.ReadLine());

        // Step 2: Check if the year is valid for the Gregorian calendar
        if (year >= 1582)
        {
            // Step 3: Single if statement with multiple logical conditions
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                Console.WriteLine($"{year} is a Leap Year.");
            }
            else
            {
                Console.WriteLine($"{year} is not a Leap Year.");
            }
        }
        else
        {
            Console.WriteLine("Year must be greater than or equal to 1582.");
        }
    }
}