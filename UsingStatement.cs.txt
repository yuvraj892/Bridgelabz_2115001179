using System;
using System.IO;

class UsingStatement
{
    public static void Main(string[] args)
    {
        try
        {
            string filePath = "info.txt";

            using(StreamReader reader = new StreamReader(filePath))
            {
                string firstLine = reader.ReadLine();

                Console.WriteLine(firstLine);
            }
        }
        catch(IOException)
        {
            Console.WriteLine("Error reading file");
        }
        
    }

}