using System;
public class FriendDetail
{
    // Method to find the youngest one
    public static string FindYoungest(string[] names, int[] ages)
    {
        int minAge = ages[0];
        int youngIndex = 0;

        for (int i = 1; i < ages.Length; i++)
        {
            if (ages[i] < minAge)
            {
                minAge = ages[i];
                youngIndex = i;
            }
        }
        return names[youngIndex];
    }
    // Method to find the tallest friend
    public static string FindTallest(string[] names, double[] heights)
    {
        double maxHeight = heights[0];
        int tallestIndex = 0;

        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] > maxHeight)
            {
                maxHeight = heights[i];
                tallestIndex = i;
            }
        }
        return names[tallestIndex];
    }
    static void Main()
    {
        string[] names = { "Amar", "Akbar", "Anthony" };
        int[] ages = new int[3];
        double[] heights = new double[3];
        Console.WriteLine("Enter the age and height of Amar, Akbar, and Anthony:");
        // Taking input for ages and heights
        for (int i = 0; i < names.Length; i++)
        {
            Console.Write($"Enter age of {names[i]}: ");
            bool validAge = int.TryParse(Console.ReadLine(), out ages[i]);
            if (!validAge || ages[i] <= 0)
            {
                Console.WriteLine("Invalid age. Please enter a valid positive number.");
                i--; // Retry for the same friend
                continue;
            }
            Console.Write($"Enter height of {names[i]} (in meters): ");
            bool validHeight = double.TryParse(Console.ReadLine(), out heights[i]);
            if (!validHeight || heights[i] <= 0)
            {
                Console.WriteLine("Invalid height. Please enter a valid positive number.");
                i--; // Retry for the same friend
            }
        }
        // Finding the youngest and tallest
        string youngest = FindYoungest(names, ages);
        string tallest = FindTallest(names, heights);
        Console.WriteLine($"\nThe youngest friend is: {youngest}");
        Console.WriteLine($"The tallest friend is: {tallest}");
    }
}
