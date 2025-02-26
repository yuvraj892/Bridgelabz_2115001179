using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;

namespace DatabaseToJsonReport
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // In a real application, you would use a database connection
                // Since we don't have an actual database, we'll simulate database records

                // Create a DataTable to simulate database records
                DataTable employeesTable = new DataTable("Employees");

                // Add columns
                employeesTable.Columns.Add("EmployeeID", typeof(int));
                employeesTable.Columns.Add("FirstName", typeof(string));
                employeesTable.Columns.Add("LastName", typeof(string));
                employeesTable.Columns.Add("Department", typeof(string));
                employeesTable.Columns.Add("Salary", typeof(decimal));
                employeesTable.Columns.Add("HireDate", typeof(DateTime));

                // Add rows (simulate database records)
                employeesTable.Rows.Add(1, "John", "Doe", "Engineering", 75000.00m, new DateTime(2020, 3, 15));
                employeesTable.Rows.Add(2, "Jane", "Smith", "Marketing", 65000.00m, new DateTime(2019, 6, 10));
                employeesTable.Rows.Add(3, "Robert", "Johnson", "Finance", 80000.00m, new DateTime(2021, 1, 5));
                employeesTable.Rows.Add(4, "Lisa", "Brown", "HR", 60000.00m, new DateTime(2018, 9, 22));
                employeesTable.Rows.Add(5, "Michael", "Wilson", "IT", 85000.00m, new DateTime(2022, 2, 8));

                // Convert DataTable to a list of dictionaries
                List<Dictionary<string, object>> dataList = new List<Dictionary<string, object>>();

                foreach (DataRow row in employeesTable.Rows)
                {
                    Dictionary<string, object> rowData = new Dictionary<string, object>();

                    foreach (DataColumn col in employeesTable.Columns)
                    {
                        // Add each column value with its name
                        rowData[col.ColumnName] = row[col];
                    }

                    dataList.Add(rowData);
                }

                // Create a report structure
                Dictionary<string, object> report = new Dictionary<string, object>
                {
                    ["ReportName"] = "Employee Summary Report",
                    ["GeneratedDate"] = DateTime.Now,
                    ["TotalEmployees"] = employeesTable.Rows.Count,
                    ["Employees"] = dataList
                };

                // Convert to JSON
                string json = JsonConvert.SerializeObject(report, Formatting.Indented);

                // Save to JSON file
                string jsonFilePath = "employee_report.json";
                File.WriteAllText(jsonFilePath, json);

                // Print the result
                Console.WriteLine("Employee Report JSON:");
                Console.WriteLine("---------------------");
                Console.WriteLine(json);
                Console.WriteLine("\nJSON report saved to " + jsonFilePath);
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
