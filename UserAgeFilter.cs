using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace UserAgeFilter
{
    class Program
    {
        // Class to represent a User
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
        }

        static void Main(string[] args)
        {
            try
            {
                // Path to the JSON file
                string filePath = "users.json";

                // Check if file exists
                if (!File.Exists(filePath))
                {
                    // Create sample data if file doesn't exist
                    List<User> sampleUsers = new List<User>
                    {
                        new User { Id = 1, Name = "Alice Smith", Age = 22, Email = "alice@example.com" },
                        new User { Id = 2, Name = "Bob Johnson", Age = 27, Email = "bob@example.com" },
                        new User { Id = 3, Name = "Charlie Brown", Age = 31, Email = "charlie@example.com" },
                        new User { Id = 4, Name = "Diana Ross", Age = 24, Email = "diana@example.com" },
                        new User { Id = 5, Name = "Edward Lee", Age = 29, Email = "edward@example.com" }
                    };

                    // Save sample data
                    string sampleJson = JsonConvert.SerializeObject(sampleUsers, Formatting.Indented);
                    File.WriteAllText(filePath, sampleJson);
                    Console.WriteLine("Sample users data created in users.json");
                }

                // Read the JSON file
                string jsonContent = File.ReadAllText(filePath);

                // Deserialize JSON to list of User objects
                List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonContent);

                // Filter users older than 25 years
                List<User> filteredUsers = users.Where(u => u.Age > 25).ToList();

                // Print filtered users
                Console.WriteLine("\nUsers older than 25 years:");
                Console.WriteLine("------------------------");

                foreach (User user in filteredUsers)
                {
                    Console.WriteLine("ID: " + user.Id);
                    Console.WriteLine("Name: " + user.Name);
                    Console.WriteLine("Age: " + user.Age);
                    Console.WriteLine("Email: " + user.Email);
                    Console.WriteLine();
                }

                // Convert filtered list back to JSON
                string filteredJson = JsonConvert.SerializeObject(filteredUsers, Formatting.Indented);
                Console.WriteLine("Filtered JSON:");
                Console.WriteLine(filteredJson);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}
