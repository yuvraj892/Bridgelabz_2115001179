using System;
using System.Diagnostics;
using System.Reflection;

namespace ReflectionPractice
{
    public class TimerUtility
    {
        // Method to measure execution time of another method
        public static void MeasureExecutionTime(object obj, string methodName)
        {
            // Get type of the object
            Type type = obj.GetType();

            // Get method information
            MethodInfo method = type.GetMethod(methodName);

            // Check if method exists
            if (method != null)
            {
                // Start stopwatch
                Stopwatch stopwatch = Stopwatch.StartNew();

                // Invoke the method
                method.Invoke(obj, null);

                // Stop stopwatch
                stopwatch.Stop();

                // Display execution time
                Console.WriteLine("Execution time for " + methodName + ": " + stopwatch.ElapsedMilliseconds.ToString() + " ms");
            }
            else
            {
                Console.WriteLine("Method not found!");
            }
        }
    }

    public class SampleTask
    {
        public void PerformTask()
        {
            // Simulating work
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Task completed.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create instance of SampleTask
            SampleTask task = new SampleTask();

            // Measure execution time of PerformTask method
            TimerUtility.MeasureExecutionTime(task, "PerformTask");

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
