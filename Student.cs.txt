using System;
using System.Reflection;

namespace ReflectionPractice
{
    // Sample class to inspect
    public class Student
    {
        private string name;
        private int age;

        public Student() { }

        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void Study()
        {
            Console.WriteLine("Studying...");
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Student Information");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Get class name from user
            Console.WriteLine("Enter class name (e.g., Student):");
            string className = Console.ReadLine();

            try
            {
                // Get the current assembly
                Assembly assembly = Assembly.GetExecutingAssembly();
                
                // Get type information using the full namespace
                Type type = assembly.GetType("ReflectionPractice." + className);
                
                // Check if type exists
                if (type == null)
                {
                    Console.WriteLine("Class not found!");
                    return;
                }

                // Display methods
                Console.WriteLine("\nMethods:");
                foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                {
                    Console.WriteLine(method.Name);
                }

                // Display fields
                Console.WriteLine("\nFields:");
                foreach (FieldInfo field in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                {
                    Console.WriteLine(field.Name);
                }

                // Display constructors
                Console.WriteLine("\nConstructors:");
                foreach (ConstructorInfo constructor in type.GetConstructors())
                {
                    Console.WriteLine(constructor.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}