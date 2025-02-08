// Base class representing a Book
class Book
{
    // Properties to store title and publication year
    public string Title { get; private set; }
    public int PublicationYear { get; private set; }

    // Constructor to initialize a book with title and publication year
    public Book(string title, int publicationYear)
    {
        Title = title;
        PublicationYear = publicationYear;
    }

    // Virtual method to be overridden in subclasses
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Book: {Title}, Published Year: {PublicationYear}");
    }
}
