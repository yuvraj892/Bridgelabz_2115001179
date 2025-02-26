using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace EmailValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the JSON schema with email validation
            string schemaJson = @"{
                'type': 'object',
                'required': ['name', 'email'],
                'properties': {
                    'name': { 'type': 'string' },
                    'email': { 
                        'type': 'string',
                        'format': 'email',
                        'pattern': '^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$'
                    }
                }
            }";

            // Test cases with valid and invalid emails
            string[] testJsons = {
                @"{ 'name': 'John Doe', 'email': 'john.doe@example.com' }",
                @"{ 'name': 'Jane Smith', 'email': 'jane.smith@company.org' }",
                @"{ 'name': 'Invalid Email', 'email': 'not-an-email' }",
                @"{ 'name': 'Missing Domain', 'email': 'user@' }",
                @"{ 'name': 'No Email', 'email': '' }"
            };

            try
            {
                // Parse the schema
                JSchema schema = JSchema.Parse(schemaJson);

                // Validate each test case
                Console.WriteLine("Email Validation Results:");
                Console.WriteLine("------------------------");

                foreach (string testJson in testJsons)
                {
                    // Parse the test JSON
                    JObject json = JObject.Parse(testJson);

                    // Extract the name and email for display
                    string name = json["name"].ToString();
                    string email = json["email"].ToString();

                    // Validate against the schema
                    bool isValid = json.IsValid(schema, out IList<string> errorMessages);

                    // Print validation result
                    Console.WriteLine("Name: " + name);
                    Console.WriteLine("Email: " + email);
                    Console.WriteLine("Valid: " + isValid);

                    // Print any validation errors
                    if (!isValid)
                    {
                        Console.WriteLine("Errors:");
                        foreach (string error in errorMessages)
                        {
                            Console.WriteLine(" - " + error);
                        }
                    }

                    Console.WriteLine();
                }
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
