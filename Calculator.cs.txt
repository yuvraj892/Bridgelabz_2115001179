using System;
using System.Reflection;

namespace ReflectionPractice
{
    public class Calculator
    {
        private int Multiply(int a, int b)
        {
            return a * b;
        }

        // Method to verify multiplication
        public void DisplayMultiplication(int a, int b)
        {
            Console.WriteLine("Regular multiplication: " + (a * b).ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create calculator instance
                Calculator calc = new Calculator();

                // Get type information
                Type type = typeof(Calculator);

                // Get private method info with specific binding flags
                MethodInfo multiplyMethod = type.GetMethod("Multiply",
                    BindingFlags.NonPublic |
                    BindingFlags.Instance |
                    BindingFlags.DeclaredOnly);

                if (multiplyMethod == null)
                {
                    Console.WriteLine("Method 'Multiply' not found!");
                    return;
                }

                // Get first number
                Console.WriteLine("Enter first number:");
                string input1 = Console.ReadLine();

                // Get second number
                Console.WriteLine("Enter second number:");
                string input2 = Console.ReadLine();

                int a, b; // Declare variables before using TryParse
                if (int.TryParse(input1, out a) && int.TryParse(input2, out b))
                {
                    // Invoke private method
                    object result = multiplyMethod.Invoke(calc, new object[] { a, b });
                    Console.WriteLine("Result using reflection: " + result.ToString());

                    // Verify with regular method
                    calc.DisplayMultiplication(a, b);
                }
                else
                {
                    Console.WriteLine("Invalid number input!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
