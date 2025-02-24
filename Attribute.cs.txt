using System;

namespace ReflectionPractice
{
    // Define custom attribute
    [AttributeUsage(AttributeTargets.Class)]
    public class AuthorAttribute : Attribute
    {
        // Private field to store author name
        private string authorName;

        // Constructor for attribute
        public AuthorAttribute(string name)
        {
            this.authorName = name;
        }

        // Property to access author name
        public string AuthorName
        {
            get { return authorName; }
        }
    }

    // Apply custom attribute to test class
    [Author("John Doe")]
    public class TestClass
    {
        // Empty constructor
        public TestClass()
        {
        }

        // Sample method
        public void DisplayInfo()
        {
            Console.WriteLine("This is a test class");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Get type information for TestClass
                Type type = typeof(TestClass);

                // Get custom attributes of type AuthorAttribute
                object[] attributes = type.GetCustomAttributes(typeof(AuthorAttribute), false);

                // Check if attribute exists
                if (attributes.Length > 0)
                {
                    // Get the first AuthorAttribute
                    AuthorAttribute authorAttribute = (AuthorAttribute)attributes[0];

                    // Display the author name
                    Console.WriteLine("Author Name: " + authorAttribute.AuthorName);
                }
                else
                {
                    // Display message if no attribute found
                    Console.WriteLine("No Author attribute found.");
                }
            }
            catch (Exception ex)
            {
                // Display any errors that occur
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            // Wait for user input before closing
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}