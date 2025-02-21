using System;
using System.IO;

class FileNotFound
{
    public static void Main(string[] args)
    {
        try
        {
            string content = File.ReadAllText("data.txt");
            Console.WriteLine(content);
        }
        catch (FileNotFoundException fnf)
        {
            Console.WriteLine("Error: File Not Found \n" + fnf);
        }
    }
}