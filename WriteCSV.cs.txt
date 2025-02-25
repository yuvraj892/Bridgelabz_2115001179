//using System;
//using System.IO;
//using System.Collections.Generic;
//using CsvHelper;
//using System.Globalization;

//class WriteCSV
//{
//    public static void Main(string[] args)
//    {
//        using (var writer = new StreamWriter("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\student_details.csv"))
//        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
//        {
//            var records = new List<Students>
//            {
//                new Students {ID = 106, Name = "Frank Harris", Age = 21, Marks = 76},
//                new Students {ID = 107, Name = "Grace Miller", Age = 22, Marks = 89},
//                new Students {ID = 108, Name = "Henry Wilson", Age = 20, Marks = 82},
//                new Students {ID = 109, Name = "Isabella Moore", Age = 23, Marks = 95},
//                new Students {ID = 110, Name = "Jack Taylor", Age = 21, Marks = 80}
//            };

//            csv.WriteRecords(records);
//        }
//        Console.WriteLine("CSV file written successfully using CsvHelper!");
//    }
//}

//class Students
//{
//    public int ID { get; set; }
//    public string Name { get; set; }
//    public int Age { get; set; }
//    public int Marks { get; set; }
//}
