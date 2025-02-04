using System;

class Book
{
    private static string LibraryName = "Vidya Library";
    public readonly string ISBN;
    public string Title;
    public string Author;

    public Book(string Title, string Author, string ISBN)
    {
        this.Title = Title;
        this.Author = Author;
        this.ISBN = ISBN;
    }

    public static void DisplayLibraryName()
    {
        Console.WriteLine("Library Name: " + LibraryName);
    }

    public void DisplayBookDetails()
    {
        if (this is Book)
        {
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("ISBN: " + ISBN);
        }
    }

    static void Main()
    {
        Console.WriteLine("Enter number of books: ");
        int count = int.Parse(Console.ReadLine());
        Book[] books = new Book[count];

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Enter title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter author: ");
            string author = Console.ReadLine();
            Console.WriteLine("Enter ISBN: ");
            string isbn = Console.ReadLine();
            books[i] = new Book(title, author, isbn);
        }

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Library Name");
            Console.WriteLine("2. Display All Books");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayLibraryName();
                    break;
                case 2:
                    foreach (var book in books)
                    {
                        book.DisplayBookDetails();
                    }
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
