using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CsvHelper;

class SearchRecords
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the name: ");
        string InputName = Console.ReadLine();

        using (var reader = new StreamReader("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\student_details.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<Student>().ToList(); 

            bool found = false;
            foreach (var record in records)
            {
                if (record.Name.ToLower() == InputName.ToLower())
                {
                    Console.WriteLine("Age: " + record.Age + ", Marks: " + record.Marks);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No record found for the given name.");
            }
        }
    }
}

class Student
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }
}
