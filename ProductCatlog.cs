using System;
using System.Collections.Generic;

// Abstract base class representing a product
public abstract class ProductBase
{
    // Protected properties for product details
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public double ProductPrice { get; set; }

    // Method to display product details
    public virtual void DisplayDetails()
    {
        // Displaying the product information
        Console.Write("ID: " + ProductID);
        Console.Write(", Name: " + ProductName);
        Console.Write(", Price: " + ProductPrice);
    } 
}

// BookCategory class inheriting from ProductBase
public class BookCategory : ProductBase
{
    // Additional properties for BookCategory
    public string Author { get; set; }
    public string Genre { get; set; }

    // Constructor to initialize the book's properties
    public BookCategory(int id, string name, double price, string author, string genre)
    {
        ProductID = id;
        ProductName = name;
        ProductPrice = price;
        Author = author;
        Genre = genre;
    }

    // Overriding ToString to return book details as a string
    public override string ToString()
    {
        DisplayDetails();
        return ", Author: " + Author + ", Genre: " + Genre;
    }
}

// ClothingCategory class inheriting from ProductBase
public class ClothingCategory : ProductBase
{
    // Additional properties for ClothingCategory
    string Size { get; set; }
    string Material { get; set; }

    // Constructor to initialize the clothing's properties
    public ClothingCategory(int id, string name, double price, string size, string material)
    {
        ProductID = id;
        ProductName = name;
        ProductPrice = price;
        Size = size;
        Material = material;
    }

    // Overriding ToString to return clothing details as a string
    public override string ToString()
    {
        DisplayDetails();
        return ", Size: " + Size + ", Material: " + Material;
    }
}

// Generic ProductCatalog class to manage various products
public class ProductCatalog<T> where T : ProductBase
{
    // Private list to hold products of type T
    private List<T> products = new List<T>();

    // Method to add products to the catalog
    public void AddProduct(T product)
    {
        products.Add(product);
    }

    // Method to display all products in the catalog
    public void DisplayAllProducts()
    {
        // Iterate over the list and display each product's details
        foreach (var product in products)
        {
            Console.WriteLine(product.ToString());
        }
    }

    // Method to apply a discount to a product
    public void ApplyDiscount(T product, double percentage)
    {
        // Calculating the new price after discount
        product.ProductPrice -= product.ProductPrice * (percentage / 100);
        Console.WriteLine("Discount applied. New price for " + product.ProductName + ": " + product.ProductPrice);
    }
}

// Main class to execute the program
class Program
{
    static void Main(string[] args)
    {
        // Create the product catalog for books and clothing
        ProductCatalog<BookCategory> bookCatalog = new ProductCatalog<BookCategory>();
        ProductCatalog<ClothingCategory> clothingCatalog = new ProductCatalog<ClothingCategory>();

        // Create book products
        BookCategory book1 = new BookCategory(1, "C# Programming", 29.99, "John Doe", "Technology");
        BookCategory book2 = new BookCategory(2, "Learn Java", 19.99, "Jane Smith", "Programming");

        // Create clothing products
        ClothingCategory shirt = new ClothingCategory(1, "Blue Shirt", 15.99, "M", "Cotton");
        ClothingCategory jeans = new ClothingCategory(2, "Denim Jeans", 49.99, "L", "Denim");

        // Add products to respective catalogs
        bookCatalog.AddProduct(book1);
        bookCatalog.AddProduct(book2);
        clothingCatalog.AddProduct(shirt);
        clothingCatalog.AddProduct(jeans);

        // Display all books before applying discount
        Console.WriteLine("Books before discount:");
        bookCatalog.DisplayAllProducts();

        // Display all clothing before applying discount
        Console.WriteLine("\nClothing before discount:");
        clothingCatalog.DisplayAllProducts();

        // Apply a discount on the first book (10% discount)
        bookCatalog.ApplyDiscount(book1, 10);

        // Display all books after discount
        Console.WriteLine("\nBooks after discount:");
        bookCatalog.DisplayAllProducts();
    }
}
