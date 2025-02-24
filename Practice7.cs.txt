using System;
using System.Collections.Generic;
using System.Threading;

namespace Practice7
{
    // Define CacheResult attribute (no parameters needed)
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheResultAttribute : Attribute
    {
    }

    public class Calculator
    {
        // Static dictionary to store cached results
        private static Dictionary<int, int> cache = new Dictionary<int, int>();

        // Apply CacheResult attribute to method
        [CacheResult]
        public int ExpensiveCalculation(int input)
        {
            // Check if result exists in cache
            if (cache.ContainsKey(input))
            {
                Console.WriteLine("Returning cached result for input: " + input);
                return cache[input];
            }

            // Perform expensive calculation (simulated with sleep)
            Console.WriteLine("Performing expensive calculation for input: " + input);
            Thread.Sleep(2000);
            int result = input * input;

            // Store result in cache
            cache[input] = result;
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create calculator instance
            var calc = new Calculator();

            // First calculation - will compute and cache
            Console.WriteLine("First calculation:");
            int result1 = calc.ExpensiveCalculation(5);
            Console.WriteLine("Result: " + result1 + "\n");

            // Second calculation - will use cached result
            Console.WriteLine("Second calculation (same input):");
            int result2 = calc.ExpensiveCalculation(5);
            Console.WriteLine("Result: " + result2 + "\n");

            // Third calculation - will compute new result
            Console.WriteLine("Third calculation (different input):");
            int result3 = calc.ExpensiveCalculation(10);
            Console.WriteLine("Result: " + result3);
        }
    }
}