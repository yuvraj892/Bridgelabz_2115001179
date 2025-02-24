using System;

namespace Practice5
{
    // Define RoleAllowed attribute that takes a role parameter
    [AttributeUsage(AttributeTargets.Method)]
    public class RoleAllowedAttribute : Attribute
    {
        // Constructor to set the allowed role
        public RoleAllowedAttribute(string role)
        {
            Role = role;
        }

        // Read-only property for role
        public string Role { get; private set; }
    }

    public class AdminOperations
    {
        // Apply RoleAllowed attribute specifying ADMIN role
        [RoleAllowed("ADMIN")]
        public void DeleteUser()
        {
            Console.WriteLine("User deleted successfully");
        }
    }

    public class User
    {
        // Property to store user's role
        public string Role { get; private set; }

        // Constructor to set user's role
        public User(string role)
        {
            Role = role;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create instance of AdminOperations
            var operations = new AdminOperations();
            
            // Test with admin user
            Console.WriteLine("Attempting with ADMIN user:");
            var adminUser = new User("ADMIN");
            TryOperation(operations, adminUser);

            // Test with regular user
            Console.WriteLine("\nAttempting with REGULAR user:");
            var regularUser = new User("REGULAR");
            TryOperation(operations, regularUser);
        }

        // Helper method to check role and execute operation
        static void TryOperation(AdminOperations ops, User user)
        {
            // Get method information using reflection
            var method = typeof(AdminOperations).GetMethod("DeleteUser");
            // Get RoleAllowed attribute from method
            var attr = (RoleAllowedAttribute)Attribute.GetCustomAttribute(method, typeof(RoleAllowedAttribute));
            
            // Check if user has required role
            if (user.Role == attr.Role)
            {
                ops.DeleteUser();
            }
            else
            {
                Console.WriteLine("Access Denied!");
            }
        }
    }
}