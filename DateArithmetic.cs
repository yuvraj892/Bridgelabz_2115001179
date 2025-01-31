using System;
class DateArithmatics
{
    static void Main()
    {
        Console.Write("Enter a date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        // Add 7 days, 1 month, and 2 years
        date = date.AddDays(7);
        date = date.AddMonths(1);
        date = date.AddYears(2);
        date = date.AddDays(-21);
        Console.WriteLine("Final date: " + date.ToString("yyyy-MM-dd"));
    }
}
