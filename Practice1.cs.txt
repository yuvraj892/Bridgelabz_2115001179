using System;
using System.Reflection;

namespace Practice1
{
    // Define custom attribute for important methods
    [AttributeUsage(AttributeTargets.Method)]
    public class ImportantMethodAttribute : Attribute
    {
        // Constructor to set the level
        public ImportantMethodAttribute(string level = "HIGH")
        {
            Level = level;
        }

        // Property to store importance level
        public string Level { get; private set; }
    }

    public class SampleClass
    {
        // Apply attribute to methods with different levels
        [ImportantMethod("HIGH")]
        public void CriticalOperation()
        {
            Console.WriteLine("Critical operation executing");
        }

        [ImportantMethod("MEDIUM")]
        public void ModerateOperation()
        {
            Console.WriteLine("Moderate operation executing");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Get all methods from the class
            var methods = typeof(SampleClass).GetMethods();
            
            // Loop through methods and find important ones
            foreach (var method in methods)
            {
                // Get ImportantMethod attribute if exists
                var attr = method.GetCustomAttribute<ImportantMethodAttribute>();
                if (attr != null)
                {
                    Console.WriteLine("Method: " + method.Name);
                    Console.WriteLine("Importance Level: " + attr.Level);
                    Console.WriteLine();
                }
            }
        }
    }
}