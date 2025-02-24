using System;

namespace RepeatableAttribute
{
    // Define repeatable attribute
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class BugReportAttribute : Attribute
    {
        // Property for bug description
        public string Description { get; set; }
    }

    public class BuggyCode
    {
        // Apply multiple bug reports to method
        [BugReport(Description = "First bug found")]
        [BugReport(Description = "Second bug found")]
        public void ProblematicMethod()
        {
            Console.WriteLine("This method has known bugs");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Get method info
            var method = typeof(BuggyCode).GetMethod("ProblematicMethod");
            // Get all bug reports
            var bugReports = method.GetCustomAttributes(typeof(BugReportAttribute), false);
            // Print all bug reports
            foreach (BugReportAttribute report in bugReports)
            {
                Console.WriteLine("Bug Report: " + report.Description);
            }
        }
    }
}