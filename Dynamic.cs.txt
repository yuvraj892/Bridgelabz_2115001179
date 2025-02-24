using System;
using System.Reflection;

namespace ReflectionPractice
{
    public class Student
    {
        // Public property for student name
        public string Name { get; set; }

        // Public property for student age
        public int Age { get; set; }

        // Constructor initializing default values
        public Student()
        {
            Name = "Default Student";
            Age = 18;
        }

        // Method to display student information
        public void DisplayInfo()
        {
            Console.WriteLine("Student Name: " + Name);
            Console.WriteLine("Student Age: " + Age.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Get the currently executing assembly
                Assembly assembly = Assembly.GetExecutingAssembly();

                // Get type information of the Student class using full namespace
                Type studentType = assembly.GetType("ReflectionPractice.Student");

                // Check if Student class was found
                if (studentType == null)
                {
                    Console.WriteLine("Student class not found!");
                    return;
                }

                // Dynamically create an instance of the Student class
                object studentObj = Activator.CreateInstance(studentType);

                // Check if instance creation was successful
                if (studentObj == null)
                {
                    Console.WriteLine("Failed to create Student instance!");
                    return;
                }

                // Cast the object to Student type
                Student student = (Student)studentObj;

                // Display default values of student properties
                Console.WriteLine("Default values:");
                student.DisplayInfo();

                // Get property information for "Name" and "Age"
                PropertyInfo nameProperty = studentType.GetProperty("Name");
                PropertyInfo ageProperty = studentType.GetProperty("Age");

                // Check if both properties exist
                if (nameProperty != null && ageProperty != null)
                {
                    // Prompt user to enter new student name
                    Console.WriteLine("\nEnter student name:");
                    string name = Console.ReadLine();

                    // Set the new value for the Name property
                    nameProperty.SetValue(student, name);

                    // Prompt user to enter new student age
                    Console.WriteLine("Enter student age:");
                    int age; // Declare age variable before TryParse
                    if (int.TryParse(Console.ReadLine(), out age))
                    {
                        // Set the new value for the Age property
                        ageProperty.SetValue(student, age);
                    }

                    // Display updated student details
                    Console.WriteLine("\nModified values:");
                    student.DisplayInfo();
                }
            }
            catch (Exception ex)
            {
                // Handle and display any exceptions that occur
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            // Wait for user input before exiting
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
