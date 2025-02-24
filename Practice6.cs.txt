using System;
using System.Text;
using System.Reflection;

namespace Practice6
{
    // Define JsonField attribute that takes a name parameter
    [AttributeUsage(AttributeTargets.Field)]
    public class JsonFieldAttribute : Attribute
    {
        // Constructor to set the JSON field name
        public JsonFieldAttribute(string name)
        {
            Name = name;
        }

        // Read-only property for JSON field name
        public string Name { get; private set; }
    }

    public class User
    {
        // Apply JsonField attributes with custom JSON names
        [JsonField("user_name")]
        private string username;

        [JsonField("user_email")]
        private string email;

        // Constructor to initialize user data
        public User(string username, string email)
        {
            this.username = username;
            this.email = email;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a test user
            var user = new User("john_doe", "john@example.com");
            
            // Convert user to JSON and print
            string json = ToJson(user);
            Console.WriteLine(json);
        }

        // Helper method to convert object to JSON string
        static string ToJson(object obj)
        {
            var sb = new StringBuilder();
            sb.Append("{");

            // Get all private fields using reflection
            var fields = obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            bool first = true;

            // Process each field
            foreach (var field in fields)
            {
                // Get JsonField attribute if present
                var attr = field.GetCustomAttribute<JsonFieldAttribute>();
                if (attr != null)
                {
                    if (!first) sb.Append(",");
                    first = false;

                    // Add field to JSON string
                    sb.Append("\"" + attr.Name + "\":\"" + field.GetValue(obj) + "\"");
                }
            }

            sb.Append("}");
            return sb.ToString();
        }
    }
}