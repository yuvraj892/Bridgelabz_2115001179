using System;
class LeapYearChecker
{
    // Method to check if a year is a leap year
    static bool IsLeapYear(int year)
    {
        if (year < 1582)
        {
            Console.WriteLine("The LeapYear program only works for years >= 1582.");
            return false;
        }
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }

    static void Main()
    {
        Console.Write("Enter a year: ");
        int year;
        if (!int.TryParse(Console.ReadLine(), out year) || year < 0)
        {
            Console.WriteLine("Invalid input! Please enter a valid positive year.");
            return;
        }

        // Check and display whether it's a leap year
        if (IsLeapYear(year))
            Console.WriteLine($"{year} is a Leap Year.");
        else
            Console.WriteLine($"{year} is NOT a Leap Year.");
    }
}
