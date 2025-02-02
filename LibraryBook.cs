using System;

class Book
{
    private string title;
    private string author;
    private double price;
    private bool Available;
    // Constructor
    public Book(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
        this.Available = true; // Book is available by default
    }

    // Method to borrow a book
    public void BorrowBook()
    {
        if (Available)
        {
            Available = false;
            Console.WriteLine("You have borrowed: " + title);
        }
        else
        {
            Console.WriteLine("Sorry, " + title + " is not available.");
        }
    }

    // Method to display book details
    public void DisplayBook()
    {
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Author: " + author);
        Console.WriteLine("Price: $" + price);
        Console.WriteLine("Available: " + (Available ? "Yes" : "No"));
    }
}


class LibraryBook
{
    static void Main()
    {
        Book book1 = new Book("Tell me why", "Times of India", 35);
        Console.WriteLine("Book Details:");
		
        book1.DisplayBook();
        Console.WriteLine("\nTrying to borrow the book...");
        book1.BorrowBook(); // First borrow should work
		
        Console.WriteLine("\nTrying to borrow again...");
        book1.BorrowBook(); // Second borrow should show "not available"
		
        Console.WriteLine("\nUpdated Book Details:");
        book1.DisplayBook();
		
		
    }
}
