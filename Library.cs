using System;

// Define a node class to store book information
class BookNode
{
    // Book attributes
    public string Title;
    public string Author;
    public string Genre;
    public int BookID;
    public bool IsAvailable;
    public BookNode next;
    public BookNode prev;
    
    // Constructor to initialize a book node
    public BookNode(string Title, string Author, string Genre, int BookID)
    {
        this.Title = Title;
        this.Author = Author;
        this.Genre = Genre;
        this.BookID = BookID;
        this.IsAvailable = true;
        this.next = null;
        this.prev = null;
    }
}

// Define the library management class
class LibraryManager
{
    private BookNode head;
    private BookNode tail;
    private int totalBooks;
    
    // Constructor to initialize empty library
    public LibraryManager()
    {
        head = null;
        tail = null;
        totalBooks = 0;
    }
    
    // Method to add book at the beginning
    public void AddBookAtBeginning(string Title, string Author, string Genre, int BookID)
    {
        BookNode newBook = new BookNode(Title, Author, Genre, BookID);
        
        if (head == null)
        {
            head = tail = newBook;
        }
        else
        {
            newBook.next = head;
            head.prev = newBook;
            head = newBook;
        }
        totalBooks++;
        Console.WriteLine("Book " + Title + " added successfully at beginning.");
    }
    
    // Method to add book at the end
    public void AddBookAtEnd(string Title, string Author, string Genre, int BookID)
    {
        BookNode newBook = new BookNode(Title, Author, Genre, BookID);
        
        if (head == null)
        {
            head = tail = newBook;
        }
        else
        {
            tail.next = newBook;
            newBook.prev = tail;
            tail = newBook;
        }
        totalBooks++;
        Console.WriteLine("Book " + Title + " added successfully at end.");
    }
    
    // Method to add book at specific position
    public void AddBookAtPosition(string Title, string Author, string Genre, int BookID, int position)
    {
        if (position < 1 || position > totalBooks + 1)
        {
            Console.WriteLine("Invalid position");
            return;
        }
        
        if (position == 1)
        {
            AddBookAtBeginning(Title, Author, Genre, BookID);
            return;
        }
        
        if (position == totalBooks + 1)
        {
            AddBookAtEnd(Title, Author, Genre, BookID);
            return;
        }
        
        BookNode newBook = new BookNode(Title, Author, Genre, BookID);
        BookNode temp = head;
        
        for (int i = 1; i < position - 1; i++)
        {
            temp = temp.next;
        }
        
        newBook.next = temp.next;
        newBook.prev = temp;
        temp.next.prev = newBook;
        temp.next = newBook;
        
        totalBooks++;
        Console.WriteLine("Book " + Title + " added successfully at position " + position);
    }
    
    // Method to remove book by ID
    public void RemoveBook(int BookID)
    {
        if (head == null)
        {
            Console.WriteLine("Library is empty");
            return;
        }
        
        BookNode temp = head;
        
        // Search for the book
        while (temp != null && temp.BookID != BookID)
        {
            temp = temp.next;
        }
        
        if (temp == null)
        {
            Console.WriteLine("Book not found");
            return;
        }
        
        // If book is at head
        if (temp == head)
        {
            head = head.next;
            if (head != null)
                head.prev = null;
            else
                tail = null;
        }
        // If book is at tail
        else if (temp == tail)
        {
            tail = tail.prev;
            tail.next = null;
        }
        // If book is in middle
        else
        {
            temp.prev.next = temp.next;
            temp.next.prev = temp.prev;
        }
        
        totalBooks--;
        Console.WriteLine("Book with ID " + BookID + " removed successfully");
    }
    
    // Method to search book by title
    public void SearchByTitle(string Title)
    {
        BookNode temp = head;
        bool found = false;
        
        while (temp != null)
        {
            if (temp.Title.ToLower() == Title.ToLower())
            {
                DisplayBook(temp);
                found = true;
            }
            temp = temp.next;
        }
        
        if (!found)
        {
            Console.WriteLine("No books found with title: " + Title);
        }
    }
    
    // Method to search book by author
    public void SearchByAuthor(string Author)
    {
        BookNode temp = head;
        bool found = false;
        
        while (temp != null)
        {
            if (temp.Author.ToLower() == Author.ToLower())
            {
                DisplayBook(temp);
                found = true;
            }
            temp = temp.next;
        }
        
        if (!found)
        {
            Console.WriteLine("No books found by author: " + Author);
        }
    }
    
    // Method to update book availability
    public void UpdateAvailability(int BookID, bool IsAvailable)
    {
        BookNode temp = head;
        
        while (temp != null)
        {
            if (temp.BookID == BookID)
            {
                temp.IsAvailable = IsAvailable;
                Console.WriteLine("Availability updated for book: " + temp.Title);
                return;
            }
            temp = temp.next;
        }
        
        Console.WriteLine("Book not found");
    }
    
    // Helper method to display a single book
    private void DisplayBook(BookNode book)
    {
        Console.WriteLine("Title: " + book.Title + 
                        ", Author: " + book.Author + 
                        ", Genre: " + book.Genre + 
                        ", ID: " + book.BookID + 
                        ", Available: " + (book.IsAvailable ? "Yes" : "No"));
    }
    
    // Method to display all books in forward order
    public void DisplayForward()
    {
        if (head == null)
        {
            Console.WriteLine("Library is empty");
            return;
        }
        
        Console.WriteLine("\nBooks in forward order:");
        BookNode temp = head;
        while (temp != null)
        {
            DisplayBook(temp);
            temp = temp.next;
        }
    }
    
    // Method to display all books in reverse order
    public void DisplayReverse()
    {
        if (tail == null)
        {
            Console.WriteLine("Library is empty");
            return;
        }
        
        Console.WriteLine("\nBooks in reverse order:");
        BookNode temp = tail;
        while (temp != null)
        {
            DisplayBook(temp);
            temp = temp.prev;
        }
    }
    
    // Method to get total number of books
    public int GetTotalBooks()
    {
        return totalBooks;
    }
    
    // Main method to test the implementation
    public static void Main()
    {
        LibraryManager library = new LibraryManager();
        
        // Add sample books
        library.AddBookAtBeginning("The Great Gatsby", "F. Scott Fitzgerald", "Fiction", 1);
        library.AddBookAtEnd("1984", "George Orwell", "Science Fiction", 2);
        library.AddBookAtPosition("To Kill a Mockingbird", "Harper Lee", "Classic", 3, 2);
        
        // Display books in both orders
        library.DisplayForward();
        library.DisplayReverse();
        
        // Search functionality
        Console.WriteLine("\nSearching for books by George Orwell:");
        library.SearchByAuthor("George Orwell");
        
        // Update availability
        Console.WriteLine("\nUpdating availability for book ID 1:");
        library.UpdateAvailability(1, false);
        
        // Display total books
        Console.WriteLine("\nTotal books in library: " + library.GetTotalBooks());
        
        // Remove a book
        Console.WriteLine("\nRemoving book with ID 2:");
        library.RemoveBook(2);
        
        // Final display
        library.DisplayForward();
    }
}