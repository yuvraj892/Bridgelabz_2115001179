using System;
using System.Reflection;

namespace Practice2
{
    // Define Todo attribute
    [AttributeUsage(AttributeTargets.Method)]
    public class TodoAttribute : Attribute
    {
        // Constructor to set required properties
        public TodoAttribute(string task, string assignedTo, string priority = "MEDIUM")
        {
            Task = task;
            AssignedTo = assignedTo;
            Priority = priority;
        }

        // Properties to store todo information
        public string Task { get; private set; }
        public string AssignedTo { get; private set; }
        public string Priority { get; private set; }
    }

    public class ProjectTasks
    {
        // Apply Todo attributes to methods using constructor parameters
        [Todo("Implement login feature", "John", "HIGH")]
        public void LoginFeature()
        {
            Console.WriteLine("Login feature not implemented");
        }

        [Todo("Add error logging", "Jane")]
        public void ErrorLogging()
        {
            Console.WriteLine("Error logging not implemented");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Get all methods from the class
            var methods = typeof(ProjectTasks).GetMethods();
            
            // Find and print todos
            foreach (var method in methods)
            {
                // Get Todo attribute if exists
                var attr = method.GetCustomAttribute<TodoAttribute>();
                if (attr != null)
                {
                    Console.WriteLine("Method: " + method.Name);
                    Console.WriteLine("Task: " + attr.Task);
                    Console.WriteLine("Assigned To: " + attr.AssignedTo);
                    Console.WriteLine("Priority: " + attr.Priority);
                    Console.WriteLine();
                }
            }
        }
    }
}