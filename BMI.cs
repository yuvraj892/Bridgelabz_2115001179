using System;
class BMI
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of persons: ");
        int numPersons = int.Parse(Console.ReadLine());
        // Arrays to store data for multiple persons
        double[] weights = new double[numPersons];
        double[] heights = new double[numPersons];
        double[] bmiValues = new double[numPersons];
        string[] weightStatuses = new string[numPersons];
        for (int i = 0; i < numPersons; i++)
        {
            Console.WriteLine($"\nEnter details for person {i + 1}:");

            Console.Write("Enter height (in meters): ");
            heights[i] = double.Parse(Console.ReadLine());

            Console.Write("Enter weight (in kilograms): ");
            weights[i] = double.Parse(Console.ReadLine());
        }
        // Calculate BMI and determine weight status
        for (int i = 0; i < numPersons; i++)
        {
            bmiValues[i] = weights[i] / (heights[i] * heights[i]); // BMI formula
            // Determine weight status using BMI
            if (bmiValues[i] <= 18.4)
                weightStatuses[i] = "Underweight";
            else if (bmiValues[i] >= 18.5 && bmiValues[i] <= 24.9)
                weightStatuses[i] = "Normal";
            else if (bmiValues[i] >= 25.0 && bmiValues[i] <= 39.9)
                weightStatuses[i] = "Overweight";
            else
                weightStatuses[i] = "Obese";
        }
        // Display results
        Console.WriteLine("\nResults:");
        Console.WriteLine("Height (m)\tWeight (kg)\tBMI\t\tStatus");
        for (int i = 0; i < numPersons; i++)
        {
            Console.WriteLine($"{heights[i]:F2}\t\t{weights[i]:F2}\t\t{bmiValues[i]:F2}\t\t{weightStatuses[i]}");
        }
    }
}
