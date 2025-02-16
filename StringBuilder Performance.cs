using System;
using System.Text;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int iterations = 100000;

        Console.WriteLine("Comparing Performance:");

        // Measure time for string concatenation
        Stopwatch stopwatch = Stopwatch.StartNew();
        string str = "";
        for (int i = 0; i < iterations; i++)
        {
            str += "A"; 
        }
        stopwatch.Stop();
        Console.WriteLine($"String Concatenation Time: {stopwatch.ElapsedMilliseconds} ms");

        // Measure time for StringBuilder
        stopwatch.Restart();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < iterations; i++)
        {
            sb.Append("A"); 
        }
        stopwatch.Stop();
        Console.WriteLine($"StringBuilder Time: {stopwatch.ElapsedMilliseconds} ms");
    }
}

