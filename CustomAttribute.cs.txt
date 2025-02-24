using System;

namespace CustomAttribute
{
    // Define custom attribute
    [AttributeUsage(AttributeTargets.Method)]
    public class TaskInfoAttribute : Attribute
    {
        // Properties for the attribute
        public string Priority { get; set; }
        public string AssignedTo { get; set; }
    }

    public class TaskManager
    {
        // Apply custom attribute to method
        [TaskInfo(Priority = "High", AssignedTo = "John")]
        public void ImportantTask()
        {
            Console.WriteLine("Executing important task");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Get method info
            var method = typeof(TaskManager).GetMethod("ImportantTask");
            // Get custom attribute
            var attr = (TaskInfoAttribute)Attribute.GetCustomAttribute(method, typeof(TaskInfoAttribute));
            // Print attribute details
            Console.WriteLine("Task Priority: " + attr.Priority);
            Console.WriteLine("Assigned To: " + attr.AssignedTo);
        }
    }
}