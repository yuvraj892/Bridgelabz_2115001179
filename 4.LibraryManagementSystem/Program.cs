// Main Program
using System;

class Program
{
    public static void Main()
    {
        // Creating an Author object for a famous Indian book by Chetan Bhagat
        Author author = new Author("The 3 Mistakes of My Life", 2008, "Chetan Bhagat", "An Indian author known for his bestselling novels that resonate with young readers.");

        // Displaying book and author details
        author.DisplayInfo();
    }
}
