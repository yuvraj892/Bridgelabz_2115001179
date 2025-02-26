using System;
using Newtonsoft.Json;

namespace CarJsonConverter
{
    class Program
    {
        // Class to represent a Car
        public class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public string Color { get; set; }
            public bool IsElectric { get; set; }
        }

        static void Main(string[] args)
        {
            // Create a new Car object
            Car myCar = new Car
            {
                Make = "Toyota",
                Model = "Camry",
                Year = 2022,
                Color = "Blue",
                IsElectric = false
            };

            // Convert the Car object to JSON string
            string jsonString = JsonConvert.SerializeObject(myCar, Formatting.Indented);

            // Print the JSON string
            Console.WriteLine("Car JSON:");
            Console.WriteLine(jsonString);

            Console.ReadKey();
        }
    }
}
