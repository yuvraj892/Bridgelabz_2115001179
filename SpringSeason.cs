using System;
public class SpringSeason
{
    public static bool Season(int month, int day)
    {
        if (month == 3 && day >= 20 && day <= 31) // Mar 20 - Mar31
            return true;
        else if (month == 4 && day >= 1 && day <= 30) // Apr
            return true;
        else if (month == 5 && day >= 1 && day <= 31) // May
            return true;
        else if (month == 6 && day >= 1 && day <= 20) // June 1 - June 20
            return true;
        return false;
    }

    public static void Main()
    {
        try
        {
            // Taking input
            Console.Write("month: ");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.Write("day : ");
            int day = Convert.ToInt32(Console.ReadLine());
			// Check if it's a spring season
            bool Spring = Season(month, day);
            if (Spring)
                Console.WriteLine("It's a Spring Season.");
            else
                Console.WriteLine("Not a Spring Season.");
        }
    }
}
