using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonRecordFilter
{
    class Program
    {
        // Class to represent a Person
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string City { get; set; }
        }

        static void Main(string[] args)
        {
            // JSON array of people as string
            string jsonPeople = @"[
                { 'Name': 'John', 'Age': 22, 'City': 'New York' },
                { 'Name': 'Alice', 'Age': 28, 'City': 'Boston' },
                { 'Name': 'Bob', 'Age': 31, 'City': 'Chicago' },
                { 'Name': 'Emma', 'Age': 24, 'City': 'Miami' },
                { 'Name': 'David', 'Age': 35, 'City': 'Seattle' }
            ]";

            try
            {
                // Parse JSON array to list of Person objects
                List<Person> people = JsonConvert.DeserializeObject<List<Person>>(jsonPeople);

                // Filter people with age > 25
                List<Person> filteredPeople = people.Where(p => p.Age > 25).ToList();

                // Print filtered people
                Console.WriteLine("People with Age > 25:");
                Console.WriteLine("--------------------");

                foreach (Person person in filteredPeople)
                {
                    Console.WriteLine("Name: " + person.Name);
                    Console.WriteLine("Age: " + person.Age);
                    Console.WriteLine("City: " + person.City);
                    Console.WriteLine();
                }

                // Convert filtered list back to JSON
                string filteredJson = JsonConvert.SerializeObject(filteredPeople, Formatting.Indented);
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
