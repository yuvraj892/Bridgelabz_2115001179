using System;
class Product
{
    // Instance variables (unique for each product)
    private string productName;
    private double price;

    // Class variable (shared among all products)
    private static int totalProducts = 0;

    // Constructor to initialize a product
    public Product(string productName, double price)
    {
        this.productName = productName;
        this.price = price;
        totalProducts++; // Increment total products when a new product is created
    }

    // Instance method to display product details
    public void DisplayProductDetails()
    {
        Console.WriteLine("Product Name: " + productName);
        Console.WriteLine("Price: " + price);
    }

    // Class method to display total number of products
    public static void DisplayTotalProducts()
    {
        Console.WriteLine("Total Products: " + totalProducts);
    }
}

class ProductInventory
{
    static void Main()
    {
        Product p1 = new Product("Laptop", 77000);
        Product p2 = new Product("mobile", 35000);

        Console.WriteLine("Product 1 Details:");
        p1.DisplayProductDetails();

        Console.WriteLine("\nProduct 2 Details:");
        p2.DisplayProductDetails();

        Console.WriteLine("\nTotal Products in Inventory:");
        Product.DisplayTotalProducts(); // Calling the class method
    }
}
