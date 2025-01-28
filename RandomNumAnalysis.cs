using System;
class RandomNumAnalysis
{
    // Method to generate an array of 4-digit random numbers
    public static int[] Generate4DigitRandomArray(int size)
    {
        Random random = new Random();
        int[] numbers = new int[size];
        for (int i = 0; i < size; i++)
        {
            numbers[i] = random.Next(1000, 10000); // Generate 4-digit random numbers
        }
        return numbers;
    }
    // Method to find the average, minimum, and maximum of an array
    public static double[] FindAverageMinMax(int[] numbers)
    {
        int min = numbers[0];
        int max = numbers[0];
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
            min = Math.Min(min, num);
            max = Math.Max(max, num);
        }
        double average = (double)sum / numbers.Length;
        return new double[] { average, min, max };
    }
    static void Main()
    {
        int[] randomNum = Generate4DigitRandomArray(5);
        //Display the random numbers
        Console.WriteLine("Generated 4-digit random numbers:");
        foreach (int num in randomNum)
        {
            Console.WriteLine(num);
        }
        // Find the average, minimum, and maximum
        double[] results = FindAverageMinMax(randomNum);
        Console.WriteLine($"\nAverage: {results[0]:F2}");
        Console.WriteLine($"Minimum: {results[1]}");
        Console.WriteLine($"Maximum: {results[2]}");
    }
}
