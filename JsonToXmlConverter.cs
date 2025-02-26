using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace JsonToXmlConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Sample JSON string
                string jsonString = @"{
                    'book': {
                        'title': 'C# Programming Guide',
                        'author': 'John Smith',
                        'year': 2022,
                        'price': 49.99,
                        'chapters': [
                            'Introduction to C#',
                            'Object-Oriented Programming',
                            'LINQ',
                            'Async Programming',
                            'JSON Handling'
                        ]
                    }
                }";

                // Parse JSON to XML
                XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(jsonString, "root");

                // Format the XML with indentation
                using (StringWriter stringWriter = new StringWriter())
                {
                    XmlWriterSettings settings = new XmlWriterSettings
                    {
                        Indent = true,
                        IndentChars = "  ",
                        NewLineChars = "\r\n",
                        NewLineHandling = NewLineHandling.Replace
                    };

                    using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
                    {
                        xmlDoc.Save(xmlWriter);
                    }

                    // Get the formatted XML
                    string formattedXml = stringWriter.ToString();

                    // Print the XML
                    Console.WriteLine("Converted XML:");
                    Console.WriteLine("--------------");
                    Console.WriteLine(formattedXml);

                    // Save the XML to a file
                    File.WriteAllText("output.xml", formattedXml);
                    Console.WriteLine("\nXML saved to output.xml");
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}
