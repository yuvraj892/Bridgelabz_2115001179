using System;
class LeapYearLogicalOperator
{
    static void Main(string[] args)
    {
        //input year
        Console.Write("Enter a year: ");
        int year = int.Parse(Console.ReadLine());

        //Check if the year is valid
        if (year >= 1582 && ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0)))
        {
            Console.WriteLine($"{year} is a Leap Year.");
        }
        else if (year >= 1582)
        {
            Console.WriteLine($"{year} is not a Leap Year.");
        }
        else
        {
            Console.WriteLine("Year must be greater than or equal to 1582.");
        }
    }
}