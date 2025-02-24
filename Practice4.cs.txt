using System;

namespace Practice4
{
    // Define MaxLength attribute that takes a value parameter
    [AttributeUsage(AttributeTargets.Field)]
    public class MaxLengthAttribute : Attribute
    {
        // Constructor to set the maximum length
        public MaxLengthAttribute(int value)
        {
            MaxValue = value;
        }

        // Read-only property for maximum length
        public int MaxValue { get; private set; }
    }

    public class User
    {
        // Apply MaxLength attribute with a limit of 10 characters
        [MaxLength(10)]
        private string username;

        // Constructor that validates the username length
        public User(string username)
        {
            // Get field info using reflection
            var field = typeof(User).GetField("username", 
                System.Reflection.BindingFlags.NonPublic | 
                System.Reflection.BindingFlags.Instance);
            
            // Get MaxLength attribute from the field
            var attr = (MaxLengthAttribute)Attribute.GetCustomAttribute(field, typeof(MaxLengthAttribute));
            
            // Validate the length against the attribute's MaxValue
            if (username.Length > attr.MaxValue)
            {
                throw new ArgumentException("Username cannot exceed " + attr.MaxValue + " characters");
            }
            
            this.username = username;
        }

        // Method to display the username
        public void PrintUsername()
        {
            Console.WriteLine("Username: " + username);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Test with valid username
                Console.WriteLine("Testing with valid username:");
                var user1 = new User("John");
                user1.PrintUsername();

                // Test with invalid username
                Console.WriteLine("\nTesting with invalid username:");
                var user2 = new User("VeryLongUsername");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}