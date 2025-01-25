using System;

class YoungestAndTallest
{
    static void Main(string[] args)
    {
        string[] friends = { "Amar", "Akbar", "Anthony" };
        int[] ages = new int[3];
        double[] heights = new double[3];

        // Input ages and heights
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Enter details for {friends[i]}:");

            // Input age
            while (true)
            {
                Console.Write("Enter Age: ");
                if (int.TryParse(Console.ReadLine(), out int age) && age > 0)
                {
                    ages[i] = age;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer for age.");
                }
            }

            // Input height
            while (true)
            {
                Console.Write("Enter Height (in cm): ");
                if (double.TryParse(Console.ReadLine(), out double height) && height > 0)
                {
                    heights[i] = height;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive number for height.");
                }
            }
        }

        // Find the youngest
        int youngestIndex = 0;
        for (int i = 1; i < 3; i++)
        {
            if (ages[i] < ages[youngestIndex])
            {
                youngestIndex = i;
            }
        }

        // Find the tallest
        int tallestIndex = 0;
        for (int i = 1; i < 3; i++)
        {
            if (heights[i] > heights[tallestIndex])
            {
                tallestIndex = i;
            }
        }

        // Output results
        Console.WriteLine($"\nThe youngest friend is {friends[youngestIndex]} with an age of {ages[youngestIndex]} years.");
        Console.WriteLine($"The tallest friend is {friends[tallestIndex]} with a height of {heights[tallestIndex]} cm.");
    }
}
