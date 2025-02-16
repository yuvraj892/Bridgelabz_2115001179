using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string filePath = "D:\\Capgemini-Tranning\\Assignments\\Assignment16\\ByteStreamToCharacterStream\\sample.txt";

        try
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8)) // Converts byte stream to character stream
            {
                string content = reader.ReadToEnd();
                Console.WriteLine("File Content:");
                Console.WriteLine(content);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

