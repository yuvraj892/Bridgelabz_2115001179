using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JsonSchemaValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the JSON schema as a string
            string schemaJson = @"{
                'type': 'object',
                'required': ['name', 'age', 'email'],
                'properties': {
                    'name': {'type': 'string'},
                    'age': {'type': 'integer', 'minimum': 18},
                    'email': {'type': 'string', 'format': 'email'}
                }
            }";

            // JSON to validate
            string jsonToValidate = @"{
                'name': 'John Doe',
                'age': 25,
                'email': 'john.doe@example.com'
            }";

            try
            {
                // Parse the schema
                JSchema schema = JSchema.Parse(schemaJson);

                // Parse the JSON to validate
                JObject json = JObject.Parse(jsonToValidate);

                // Validate the JSON against the schema
                bool isValid = json.IsValid(schema, out IList<string> errorMessages);

                // Print validation result
                Console.WriteLine("JSON Validation Result: " + (isValid ? "Valid" : "Invalid"));

                // Print any validation errors
                if (!isValid)
                {
                    Console.WriteLine("Validation Errors:");
                    foreach (string error in errorMessages)
                    {
                        Console.WriteLine(" - " + error);
                    }
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
