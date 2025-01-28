using System;
class BMICalculator
{
        public static void CalculateBMI(double[,] data)
    {
        for (int i = 0; i < data.GetLength(0); i++)
        {
            double weight = data[i, 0];
            double heightInMeters = data[i, 1] / 100; // Convert cm to meters
            double bmi = weight / (heightInMeters * heightInMeters);
            data[i, 2] = bmi; // Store BMI in the third column
        }
    }

    // Method to determine BMI status
    public static string[] GetBMIStatus(double[,] data)
    {
        string[] statuses = new string[data.GetLength(0)];
        for (int i = 0; i < data.GetLength(0); i++)
        {
            double bmi = data[i, 2];
            if (bmi <= 18.4)
                statuses[i] = "Underweight";
            else if (bmi <= 24.9)
                statuses[i] = "Normal";
            else if (bmi <= 39.9)
                statuses[i] = "Overweight";
            else
                statuses[i] = "Obese";
        }
        return statuses;
    }
    static void Main()
    {
        double[,] data = new double[10, 3]; // 10 rows, 3 columns (weight, height, BMI)

        // Take user input for weight (kg) and height (cm)
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Enter weight (kg) for person {i + 1}: ");
            data[i, 0] = Convert.ToDouble(Console.ReadLine());

            Console.Write($"Enter height (cm) for person {i + 1}: ");
            data[i, 1] = Convert.ToDouble(Console.ReadLine());
        }
        // Calculate BMI
        CalculateBMI(data);
        // Get BMI statuses
        string[] statuses = GetBMIStatus(data);
        // Display results
        Console.WriteLine("\nHeight (cm) | Weight (kg) | BMI     | Status");
        Console.WriteLine("-------------------------------------------");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{data[i, 1],-10} | {data[i, 0],-10} | {data[i, 2]:F2}  | {statuses[i]}");
        }
    }
}
