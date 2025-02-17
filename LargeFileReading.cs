using System;
using System.Diagnostics;
using System.IO;
using System.Text;

class FileReading{
    //Method to read using StreamReader
    static void ReadWithStreamReader(string filePath){
        Stopwatch sw = Stopwatch.StartNew();
        using (StreamReader sr = new StreamReader(filePath)){
            while (sr.Read() != -1) { }
        }
        sw.Stop();
        Console.WriteLine($"StreamReader Time: {sw.ElapsedMilliseconds} ms");
    }
    //Method to read using FileStream
    static void ReadWithFileStream(string filePath){
        Stopwatch sw = Stopwatch.StartNew();
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read)){
            byte[] buffer = new byte[4096];
            while (fs.Read(buffer, 0, buffer.Length) > 0) { }
        }
        sw.Stop();
        Console.WriteLine($"FileStream Time: {sw.ElapsedMilliseconds} ms");
    }
    //Main method
    static void Main(){   
        string[] filePaths = {"1.txt","2.txt","3.txt"};
        foreach(string filePath in filePaths){
        Console.WriteLine("Reading file using StreamReader...");
        ReadWithStreamReader(filePath);
        Console.WriteLine("Reading file using FileStream...");
        ReadWithFileStream(filePath);}
    }
}
