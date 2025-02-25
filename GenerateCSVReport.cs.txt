using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Data.SqlClient;
using CsvHelper;

class GenerateCSVReport
{
    public static void Main(string[] args)
    {
        // Connection string for your database
        string connectionString = "Data Source=YOURSERVER;Initial Catalog=YOURDATABASE;Integrated Security=True";

        // SQL query to fetch employee data
        string query = "SELECT EmployeeID, Name, Department, Salary FROM Employees";

        // List to store employee records
        List<Employee> employees = new List<Employee>();

        // Connect to database and fetch records
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Create SQL command
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                // Open the connection
                connection.Open();

                // Execute the query and process results
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Read each row from the database
                    while (reader.Read())
                    {
                        // Create new employee object
                        Employee employee = new Employee
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Department = reader.GetString(2),
                            Salary = reader.GetDecimal(3)
                        };

                        // Add to list
                        employees.Add(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                // Display error message
                Console.WriteLine("Database error: " + ex.Message);
                return;
            }
        }

        // Write employee data to CSV file
        using (var writer = new StreamWriter("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\employee_report.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            // Write header row
            csv.WriteHeader<Employee>();
            csv.NextRecord();

            // Write all records to the file
            csv.WriteRecords(employees);
        }

        // Display confirmation message
        Console.WriteLine("CSV report generated successfully with " + employees.Count + " employee records.");
    }
}

// Class to represent an employee record
class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
}