using System;

class Book
{
    // Public: Can be accessed from anywhere
    public string ISBN;

    // Protected: Can be accessed within this class and by subclasses
    protected string title;

    // Private: Can only be accessed inside this class
    private string author;

    // Constructor to initialize book details
    public Book(string ISBN, string title, string author)
    {
        this.ISBN = ISBN;
        this.title = title;
        this.author = author;
    }

    // Public method to get the author name
    public string GetAuthor()
    {
        return author;
    }

    // Public method to set the author name
    public void SetAuthor(string newAuthor)
    {
        author = newAuthor;
    }

    // Method to display book details
    public void DisplayBookDetails()
    {
        Console.WriteLine("ISBN: " + ISBN);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Author: " + author);
    }
}

// Subclass demonstrating protected and public access
class EBook : Book
{
    private double fileSize; // File size in MB

    // Constructor
    public EBook(string ISBN, string title, string author, double fileSize)
        : base(ISBN, title, author)  // Calling base class constructor
    {
        this.fileSize = fileSize;
    }

    // Method to display eBook details
    public void DisplayEBookDetails()
    {
        Console.WriteLine("ISBN: " + ISBN);  // Accessing public member
        Console.WriteLine("Title: " + title);  // Accessing protected member
        Console.WriteLine("File Size: " + fileSize + "MB");
    }
}

class Ebook
{
    static void Main()
    {
        // Creating a Book object
        Book b1 = new Book("123-456-789", "Zero To Best", "Charlie");
        Console.WriteLine("Book Details:");
        b1.DisplayBookDetails();

        // Modifying author name using public method
        b1.SetAuthor("Jane Smith");
        Console.WriteLine("\nUpdated Author: " + b1.GetAuthor());

        // Creating an EBook object
        EBook e1 = new EBook("987-654-321", "Learn C# Fast", "Mohit Mungal", 5.5);
        Console.WriteLine("\nEBook Details:");
        e1.DisplayEBookDetails();
    }
}
