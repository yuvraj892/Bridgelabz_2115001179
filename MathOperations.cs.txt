using System;
using System.Reflection;

namespace ReflectionPractice
{
    // Class containing math operations
    public class MathOperations
    {
        // Method to add two numbers
        public int Add(int a, int b)
        {
            return a + b;
        }

        // Method to subtract two numbers
        public int Subtract(int a, int b)
        {
            return a - b;
        }

        // Method to multiply two numbers
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create instance of MathOperations
            MathOperations math = new MathOperations();

            try
            {
                // Display available operations
                Console.WriteLine("Available operations: Add, Subtract, Multiply");

                // Get method name from user
                Console.WriteLine("Enter operation name:");
                string methodName = Console.ReadLine();

                // Get type information
                Type type = typeof(MathOperations);

                // Get method info
                MethodInfo methodInfo = type.GetMethod(methodName);

                // Check if method exists
                if (methodInfo == null)
                {
                    Console.WriteLine("Operation not found!");
                    return;
                }

                // Get first number from user
                Console.WriteLine("Enter first number:");
                string input1 = Console.ReadLine();
                int num1;

                // Validate first number
                if (!int.TryParse(input1, out num1))
                {
                    Console.WriteLine("Invalid first number!");
                    return;
                }

                // Get second number from user
                Console.WriteLine("Enter second number:");
                string input2 = Console.ReadLine();
                int num2;

                // Validate second number
                if (!int.TryParse(input2, out num2))
                {
                    Console.WriteLine("Invalid second number!");
                    return;
                }

                // Create parameters array
                object[] parameters = new object[] { num1, num2 };

                // Invoke the method
                object result = methodInfo.Invoke(math, parameters);

                // Display result
                Console.WriteLine("Result: " + result.ToString());
            }
            catch (Exception ex)
            {
                // Display any errors that occur
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            // Wait for user input before closing
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}