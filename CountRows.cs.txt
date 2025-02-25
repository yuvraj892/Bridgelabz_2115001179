//using System;
//using System.IO;
//using System.Collections.Generic;
//using CsvHelper;
//using System.Globalization;


//class CountRows
//{
//    public static void Main(string[] args)
//    {
//        using (var reader = new StreamReader("D:/AVS/BridgeLabz/assignment/25 feb/student_details.csv"))
//        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//        {
//            var records = csv.GetRecords<Student>();

//            int count = 0;
//            foreach (var record in records)
//            {
//                count++;
//            }
//            Console.WriteLine(count);
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
