using System;
class FootballTeam
{
    static void Main(string[] args)
    {
        int[] heights = new int[11];
        Random random = new Random();
        for (int i = 0; i < heights.Length; i++)
        {
            heights[i] = random.Next(150, 251); // Random height between 150 and 250
        }

        Console.WriteLine("Player Heights (in cms): " + string.Join(", ", heights));

        int shortest = FindShortest(heights);
        int tallest = FindTallest(heights);
        double mean = CalculateMean(heights);

        Console.WriteLine("Shortest Height: " + shortest + " cms");
        Console.WriteLine("Tallest Height: " + tallest + " cms");
        Console.WriteLine("Mean Height: " + mean.ToString("0.00") + " cms");
    }
    // Method to find the shortest height
    static int FindShortest(int[] heights)
    {
        int shortest = heights[0];
        foreach (int height in heights)
        {
            if (height < shortest)
            {
                shortest = height;
            }
        }
        return shortest;
    }

    // Method to find the tallest height
    static int FindTallest(int[] heights)
    {
        int tallest = heights[0];
        foreach (int height in heights)
        {
            if (height > tallest)
            {
                tallest = height;
            }
        }
        return tallest;
    }
    // Method to calculate the mean height
    static double CalculateMean(int[] heights)
    {
        int sum = 0;
        foreach (int height in heights)
        {
            sum += height;
        }
        return (double)sum / heights.Length;
    }
}
