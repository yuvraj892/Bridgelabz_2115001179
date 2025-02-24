using System;
using System.Collections;

namespace SuppressWarning
{
    class Program
    {
        static void Main(string[] args)
        {
            // Disable warning for using non-generic collection
            #pragma warning disable CS0618
            // Create ArrayList without generics
            ArrayList list = new ArrayList();
            // Add items
            list.Add("Item 1");
            list.Add("Item 2");
            // Print items
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
            #pragma warning restore CS0618
        }
    }
}