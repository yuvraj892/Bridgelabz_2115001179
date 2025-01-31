using System;
class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public double Price { get; set; }
    public void DisplayDetails()
    {
        Console.WriteLine("Book Details:");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Price: {Price:C}"); 
    }
}

class BookDetails
{
    static void Main()
    {
        Book book = new Book();
        Console.WriteLine("Enter the book title:");
        book.Title = Console.ReadLine();
        Console.WriteLine("Enter the author's name:");
        book.Author = Console.ReadLine();
        Console.WriteLine("Enter the price of the book:");
        book.Price = double.Parse(Console.ReadLine());
        book.DisplayDetails();
    }
}
