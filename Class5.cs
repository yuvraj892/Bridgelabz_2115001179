using System;

class CircularTour
{
    public static int FindStartingPoint(int[] petrol, int[] distance)
    {
        int n = petrol.Length;
        int start = 0, deficit = 0, surplus = 0;

        for (int i = 0; i < n; i++)
        {
            surplus += petrol[i] - distance[i];

            // If surplus becomes negative, reset the starting point
            if (surplus < 0)
            {
                start = i + 1;  // Move to the next pump
                deficit += surplus;  // Accumulate the deficit
                surplus = 0;  // Reset surplus
            }
        }

        // If total petrol (surplus + deficit) is non-negative, return start
        return (surplus + deficit >= 0) ? start : -1;
    }

    public static void Main(string[] args)
    {
        int[] petrol = { 4, 6, 7, 4 };
        int[] distance = { 6, 5, 3, 5 };

        int startingPoint = FindStartingPoint(petrol, distance);

        if (startingPoint == -1)
        {
            Console.WriteLine("No starting point possible for the circular tour.");
        }
        else
        {
            Console.WriteLine($"The starting point for the circular tour is pump index: {startingPoint}");
        }
    }
}
