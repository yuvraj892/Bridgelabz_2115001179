using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace EmployeeSerialization
{
    // Employee class with required fields
    [Serializable]
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        // Override ToString for easy display
        public override string ToString()
        {
            return "ID: " + Id + ", Name: " + Name + ", Department: " + Department + ", Salary: $" + Salary;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // File paths for different serialization formats
            string binaryFilePath = "employees.bin";
            string jsonFilePath = "employees.json";

            try
            {
                // Create a list of employees
                List<Employee> employees = new List<Employee>
                {
                    new Employee { Id = 1, Name = "John Smith", Department = "IT", Salary = 75000.00m },
                    new Employee { Id = 2, Name = "Sarah Johnson", Department = "HR", Salary = 68000.00m },
                    new Employee { Id = 3, Name = "Michael Brown", Department = "Finance", Salary = 85000.00m },
                    new Employee { Id = 4, Name = "Jennifer Davis", Department = "Marketing", Salary = 72000.00m }
                };

                // Display original employees
                Console.WriteLine("Original Employees:");
                foreach (var emp in employees)
                {
                    Console.WriteLine(emp);
                }
                Console.WriteLine();

                // 1. Binary Serialization
                SerializeBinary(employees, binaryFilePath);
                List<Employee> deserializedEmployeesBinary = DeserializeBinary(binaryFilePath);
               
                // Display binary deserialized employees
                Console.WriteLine("Employees after Binary Deserialization:");
                foreach (var emp in deserializedEmployeesBinary)
                {
                    Console.WriteLine(emp);
                }
                Console.WriteLine();

                // 2. JSON Serialization
                SerializeJSON(employees, jsonFilePath);
                List<Employee> deserializedEmployeesJson = DeserializeJSON(jsonFilePath);
               
                // Display JSON deserialized employees
                Console.WriteLine("Employees after JSON Deserialization:");
                foreach (var emp in deserializedEmployeesJson)
                {
                    Console.WriteLine(emp);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            // Wait for user to press a key before closing
            Console.ReadKey();
        }

        // Method to serialize using Binary Formatter
        static void SerializeBinary(List<Employee> employees, string filePath)
        {
            try
            {
                // Create a file stream to write to
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    // Create binary formatter
                    BinaryFormatter formatter = new BinaryFormatter();
                    // Serialize the employees list
                    formatter.Serialize(fs, employees);
                }
                Console.WriteLine("Binary serialization completed successfully to " + filePath);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error during binary serialization: " + ex.Message);
                throw;
            }
        }

        // Method to deserialize using Binary Formatter
        static List<Employee> DeserializeBinary(string filePath)
        {
            try
            {
                // Check if file exists
                if (!File.Exists(filePath))
                {
                    // Throw exception if file doesn't exist
                    throw new FileNotFoundException("The binary file does not exist.", filePath);
                }

                // Create a file stream to read from
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    // Create binary formatter
                    BinaryFormatter formatter = new BinaryFormatter();
                    // Deserialize and cast to List<Employee>
                    return (List<Employee>)formatter.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error during binary deserialization: " + ex.Message);
                throw;
            }
        }

        // Method to serialize using JSON
        static void SerializeJSON(List<Employee> employees, string filePath)
        {
            try
            {
                // Convert employees to JSON string
                string jsonString = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true });
                // Write JSON to file
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine("JSON serialization completed successfully to " + filePath);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error during JSON serialization: " + ex.Message);
                throw;
            }
        }

        // Method to deserialize using JSON
        static List<Employee> DeserializeJSON(string filePath)
        {
            try
            {
                // Check if file exists
                if (!File.Exists(filePath))
                {
                    // Throw exception if file doesn't exist
                    throw new FileNotFoundException("The JSON file does not exist.", filePath);
                }

                // Read JSON from file
                string jsonString = File.ReadAllText(filePath);
                // Deserialize JSON to List<Employee>
                return JsonSerializer.Deserialize<List<Employee>>(jsonString);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error during JSON deserialization: " + ex.Message);
                throw;
            }
        }
    }
}
