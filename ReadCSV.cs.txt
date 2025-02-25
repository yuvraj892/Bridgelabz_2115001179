//using System;
//using System.IO;
//using System.Collections.Generic;
//using CsvHelper;
//using System.Globalization;

//class ReadCSV
//{
//    public static void Main(string[] args)
//    {
//        using (var reader = new StreamReader("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\student_details.csv"))
//        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//        {
//            var records = csv.GetRecords<Student>();

//            foreach (var record in records)
//            {
//                Console.WriteLine("ID: " + record.ID + ", Name: " + record.Name + ", Age: " + record.Age + ", Marks: " + record.Marks);
//            }
//        }
//    }
//}

//class Student
//{
//    public int ID { get; set; }
//    public string Name { get; set; }
//    public int Age { get; set; }
//    public int Marks { get; set; }
//}
