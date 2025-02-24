using System;
using System.Reflection;

namespace ReflectionPractice
{
    // Class with private field
    public class Person
    {
        private int age;

        public Person()
        {
            age = 25;
        }

        // Method to verify our changes
        public void DisplayAge()
        {
            Console.WriteLine("Age value: " + age.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create instance of Person
                Person person = new Person();

                // Get type information using the current assembly
                Type type = typeof(Person);

                // Get private field information with specific binding flags
                FieldInfo ageField = type.GetField("age",
                    BindingFlags.NonPublic |
                    BindingFlags.Instance |
                    BindingFlags.DeclaredOnly);

                if (ageField == null)
                {
                    Console.WriteLine("Field 'age' not found!");
                    return;
                }

                // Display current value
                int currentAge = (int)ageField.GetValue(person);
                Console.WriteLine("Current age: " + currentAge.ToString());

                // Get new age from user
                Console.WriteLine("Enter new age:");
                string input = Console.ReadLine();

                int newAge; // Declare variable first
                if (int.TryParse(input, out newAge)) // Pass it as out parameter
                {
                    // Modify private field value
                    ageField.SetValue(person, newAge);
                    Console.WriteLine("Age updated successfully!");

                    // Verify the change
                    person.DisplayAge();
                }
                else
                {
                    Console.WriteLine("Invalid age input!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
