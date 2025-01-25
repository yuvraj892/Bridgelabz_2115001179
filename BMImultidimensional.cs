using System;
class BMImultidimensional
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of persons: ");
        int numPersons = int.Parse(Console.ReadLine());
        // 2D array to store height, weight, and BMI
        double[,] personData = new double[numPersons, 3];
        string[] weightStatus = new string[numPersons];

        // Input height and weight for each person
        for (int i = 0; i < numPersons; i++)
        {
            Console.WriteLine($"\nEnter details for person {i + 1}:");

            // Input and validate height
            while (true)
            {
                Console.Write("Enter height (in meters): ");
                double height = double.Parse(Console.ReadLine());
                if (height > 0)
                {
                    personData[i, 0] = height;
                    break;
                }
                Console.WriteLine("Height must be positive. Please try again.");
            }

            // Input and validate weight
            while (true)
            {
                Console.Write("Enter weight (in kilograms): ");
                double weight = double.Parse(Console.ReadLine());
                if (weight > 0)
                {
                    personData[i, 1] = weight;
                    break;
                }
                Console.WriteLine("Weight must be positive. Please try again.");
            }
        }
        // Calculate BMI and determine weight status
        for (int i = 0; i < numPersons; i++)
        {
            double height = personData[i, 0];
            double weight = personData[i, 1];
            // Calculate BMI
            personData[i, 2] = weight / (height * height);
            double bmi = personData[i, 2];
            if (bmi <= 18.4)
                weightStatus[i] = "Underweight";
            else if (bmi >= 18.5 && bmi <= 24.9)
                weightStatus[i] = "Normal";
            else if (bmi >= 25.0 && bmi <= 39.9)
                weightStatus[i] = "Overweight";
            else
                weightStatus[i] = "Obese";
        }
        // Display results
        Console.WriteLine("\nResults:");
        Console.WriteLine("Height (m)\tWeight (kg)\tBMI\t\tStatus");
        for (int i = 0; i < numPersons; i++)
        {
            Console.WriteLine($"{personData[i, 0]:F2}\t\t{personData[i, 1]:F2}\t\t{personData[i, 2]:F2}\t\t{weightStatus[i]}");
        }
    }
}
