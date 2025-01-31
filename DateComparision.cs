using System;
class DateComparision
{
    static void Main()
    {
		Console.Write("Enter the first date (yyyy-MM-dd): ");
        DateTime date1 = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter the second date (yyyy-MM-dd): ");
        DateTime date2 = DateTime.Parse(Console.ReadLine());
// Compare the dates
        if (date1 < date2)
        {
            Console.WriteLine("The first date is before the second date.");
        }
        else if (date1 > date2)
        {
            Console.WriteLine("The first date is after the second date.");
        }
        else
        {
            Console.WriteLine("The first date is the same as the second date.");
        }
    }
}