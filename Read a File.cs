using System;
using System.IO;

class Program
{
    public static void Main()
    {
        string filePath = "D:\\Capgemini-Tranning\\Assignments\\Assignment16\\ReadLineUsingStreamReader\\sample.txt";

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
