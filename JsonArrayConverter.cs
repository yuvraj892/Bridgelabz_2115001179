using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JsonArrayConverter
{
    class Program
    {
        // Class to represent a Product
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }
        }

        static void Main(string[] args)
        {
            // Create a list of products
            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 999.99m, Category = "Electronics" },
                new Product { Id = 2, Name = "Smartphone", Price = 499.99m, Category = "Electronics" },
                new Product { Id = 3, Name = "Headphones", Price = 89.99m, Category = "Accessories" }
            };

            try
            {
                // Convert the list to JSON array
                string jsonArray = JsonConvert.SerializeObject(products, Formatting.Indented);

                // Print the JSON array
                Console.WriteLine("Products JSON Array:");
                Console.WriteLine(jsonArray);
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
