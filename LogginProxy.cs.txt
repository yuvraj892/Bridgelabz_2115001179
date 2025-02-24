using System;
using System.Reflection;

namespace ReflectionPractice
{
    public interface IGreeting
    {
        void SayHello();
    }

    public class Greeting : IGreeting
    {
        // Implementation of SayHello
        public void SayHello()
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class LoggingProxy
    {
        // Method to log method calls before execution
        public static void InvokeWithLogging(object obj, string methodName)
        {
            // Get type of the object
            Type type = obj.GetType();

            // Get method information
            MethodInfo method = type.GetMethod(methodName);

            // Check if method exists
            if (method != null)
            {
                Console.WriteLine("Executing method: " + methodName);
                
                // Invoke the method
                method.Invoke(obj, null);
            }
            else
            {
                Console.WriteLine("Method not found!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create instance of Greeting class
            IGreeting greeting = new Greeting();

            // Invoke method with logging
            LoggingProxy.InvokeWithLogging(greeting, "SayHello");

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
