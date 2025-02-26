using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            // First JSON object as string
            string json1 = @"{
                'name': 'John Doe',
                'age': 30,
                'city': 'New York'
            }";

            // Second JSON object as string
            string json2 = @"{
                'occupation': 'Developer',
                'skills': ['C#', 'JavaScript', 'SQL'],
                'experience': 5
            }";

            try
            {
                // Parse the JSON strings into JObject
                JObject obj1 = JObject.Parse(json1);
                JObject obj2 = JObject.Parse(json2);

                // Merge the second object into the first
                obj1.Merge(obj2);

                // Convert the merged object back to string
                string mergedJson = obj1.ToString(Formatting.Indented);

                // Print the merged JSON
                Console.WriteLine("Merged JSON:");
                Console.WriteLine(mergedJson);
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
