using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


abstract class LibraryItem
{
    protected int ItemId;
    protected string Title;
    protected string Author;

    public LibraryItem(int id, string title, string author)
    {
        ItemId = id;
        Title = title;
        Author = author;
    }

    public abstract int GetLoanDuration();

    public void GetItemDetails()
    {
        Console.WriteLine($"ID: {ItemId}, Title: {Title}, Author: {Author}, Loan Duration: {GetLoanDuration()} days");
    }
}

interface IReservable
{
    void ReserveItem();
    bool CheckAvailability();
}

class BookS : LibraryItem, IReservable
{
    public BookS(int id, string title, string author) : base(id, title, author) { }

    public override int GetLoanDuration() => 14;
    public void ReserveItem() => Console.WriteLine($"{Title} has been reserved.");
    public bool CheckAvailability() => true;
}

class Magazine : LibraryItem
{
    public Magazine(int id, string title, string author) : base(id, title, author) { }

    public override int GetLoanDuration() => 7;
}

// Main Program
class Program
{
    static void Main()
    {
        List<LibraryItem> items = new List<LibraryItem>
        {
            new BookS(1, "C# Programming", "John Doe"),
            new Magazine(2, "Tech Today", "Jane Smith")
        };

        foreach (var item in items)
        {
            item.GetItemDetails();
        }
    }
}
