using System;
class CalendarProgram
{
    // Array to store month names
    static string[] monthNames = { "January", "February", "March", "April", "May", "June",
                                   "July", "August", "September", "October", "November", "December" };
    // Array to store the number of days in each month
    static int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    // Method to check if a year is a leap year
    static bool IsLeapYear(int year)
    {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }
    // Method to get the number of days in a month
    static int GetDaysInMonth(int month, int year)
    {
        if (month == 2 && IsLeapYear(year))  // February in leap year
            return 29;
        return daysInMonth[month - 1];  // Return days from array
    }
    // Method to get the first day of the month using Zeller's Congruence formula
    static int GetFirstDayOfMonth(int month, int year)
    {
        int y0 = year - (14 - month) / 12;
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
        int m0 = month + 12 * ((14 - month) / 12) - 2;
        int d0 = (1 + x + (31 * m0) / 12) % 7;
        return d0;  // 0 = Sunday, 1 = Monday, ..., 6 = Saturday
    }
    // Method to display the calendar
    static void DisplayCalendar(int month, int year)
    {
        string monthName = monthNames[month - 1];
        int days = GetDaysInMonth(month, year);
        int startDay = GetFirstDayOfMonth(month, year);
        // Print the header
        Console.WriteLine($"\n   {monthName} {year}");
        Console.WriteLine(" Sun Mon Tue Wed Thu Fri Sat");
        // Print spaces for the first day
        for (int i = 0; i < startDay; i++)
            Console.Write("    ");
        // Print the days
        for (int day = 1; day <= days; day++)
        {
            Console.Write($"{day,4}");  // Right-aligned width of 4
            if ((day + startDay) % 7 == 0)  // Move to next line after Saturday
                Console.WriteLine();
        }
        Console.WriteLine("\n");
    }
    static void Main()
    {
        Console.Write("Enter month (1-12): ");
        int month = int.Parse(Console.ReadLine());
        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());
        if (month < 1 || month > 12 || year < 1)
        {
            Console.WriteLine("Invalid input! Please enter a valid month (1-12) and year (>0).");
        }
        else
        {
            DisplayCalendar(month, year);
        }
    }
}
