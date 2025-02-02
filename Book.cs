using System;
class Book
{
    private string title;
    private string author;
    private double price;
    // Default constructor
    public Book()
    {
        title = "Unknown";
        author = "Unknown";
        price = 0.0;
    }
    // Parameterized constructor
    public Book(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
    }
    // Method to display book details
    public void AboutBook()
    {
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Author: " + author);
        Console.WriteLine("Price: " + price);
    }
}
class Trail
{
    static void Main()
    {
        Book book1 = new Book();  // Default constructor
        book1.AboutBook();

        Console.WriteLine();
        Book book2 = new Book("Aotmic habits", "James Clear", 349);  // Parameterized constructor
        book2.AboutBook();
    }
}