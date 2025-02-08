
// Derived class representing an Author
class Author : Book
{
    // Additional attributes for an author
    public string Name { get; private set; }
    public string Bio { get; private set; }

    // Constructor to initialize an author along with book details
    public Author(string title, int publicationYear, string name, string bio) : base(title, publicationYear)
    {
        Name = name;
        Bio = bio;
    }

    // Overriding DisplayInfo to include author details
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Author: {Name}\nBio: {Bio}");
    }
}