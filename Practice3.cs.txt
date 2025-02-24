using System;
using System.Diagnostics;
using System.Threading;

namespace Practice3
{
    // Define LogExecutionTime attribute
    // This attribute doesn't need any parameters
    [AttributeUsage(AttributeTargets.Method)]
    public class LogExecutionTimeAttribute : Attribute
    {
    }

    public class PerformanceTester
    {
        // Apply attribute to methods that need timing
        [LogExecutionTime]
        public void SlowOperation()
        {
            // Simulate slow operation with sleep
            Thread.Sleep(2000);
        }

        [LogExecutionTime]
        public void FastOperation()
        {
            // Simulate fast operation with sleep
            Thread.Sleep(500);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create instance of performance tester
            var tester = new PerformanceTester();
            
            // Create stopwatch for timing
            var stopwatch = new Stopwatch();
            
            // Test slow operation
            Console.WriteLine("Running slow operation:");
            stopwatch.Start();
            tester.SlowOperation();
            stopwatch.Stop();
            Console.WriteLine("Time taken: " + stopwatch.ElapsedMilliseconds + "ms\n");

            // Test fast operation
            Console.WriteLine("Running fast operation:");
            stopwatch.Restart();
            tester.FastOperation();
            stopwatch.Stop();
            Console.WriteLine("Time taken: " + stopwatch.ElapsedMilliseconds + "ms");
        }
    }
}