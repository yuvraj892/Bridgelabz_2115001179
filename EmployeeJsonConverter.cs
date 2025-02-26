using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmployeeJsonConverter
{
    class Program
    {
        // Class to represent an Employee
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public decimal Salary { get; set; }
            public DateTime JoinDate { get; set; }
        }

        static void Main(string[] args)
        {
            // Create a list of employees
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id = 101,
                    Name = "Jane Smith",
                    Department = "Engineering",
                    Salary = 75000.00m,
                    JoinDate = new DateTime(2020, 5, 15)
                },
                new Employee
                {
                    Id = 102,
                    Name = "John Doe",
                    Department = "Marketing",
                    Salary = 65000.00m,
                    JoinDate = new DateTime(2019, 3, 10)
                },
                new Employee
                {
                    Id = 103,
                    Name = "Robert Johnson",
                    Department = "Finance",
                    Salary = 80000.00m,
                    JoinDate = new DateTime(2021, 1, 20)
                }
            };

            try
            {
                // Convert the list to JSON array
                string jsonArray = JsonConvert.SerializeObject(employees, Formatting.Indented);

                // Print the JSON array
                Console.WriteLine("Employees JSON Array:");
                Console.WriteLine(jsonArray);

                // Optionally save to file
                File.WriteAllText("employees.json", jsonArray);
                Console.WriteLine("\nJSON array saved to employees.json");
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
