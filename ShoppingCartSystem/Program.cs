using System;

class Product
{
    private static double Discount = 10.0; // Default discount percentage
    public readonly int ProductID;
    public string ProductName;
    public double Price;
    public int Quantity;

    public Product(int ProductID, string ProductName, double Price, int Quantity)
    {
        this.ProductID = ProductID;
        this.ProductName = ProductName;
        this.Price = Price;
        this.Quantity = Quantity;
    }

    public static void UpdateDiscount(double newDiscount)
    {
        Discount = newDiscount;
    }

    public void DisplayProductDetails()
    {
        if (this is Product)
        {
            Console.WriteLine("Product ID: " + ProductID);
            Console.WriteLine("Product Name: " + ProductName);
            Console.WriteLine("Price: $" + Price);
            Console.WriteLine("Quantity: " + Quantity);
            Console.WriteLine("Discount: " + Discount + "%");
        }
    }
}
class Program 
{ 

    public static void Main()
    {
        Console.Write("Enter number of products: ");
        int count = int.Parse(Console.ReadLine());
        Product[] products = new Product[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write("Enter Product ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            products[i] = new Product(id, name, price, quantity);
        }

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display All Products");
            Console.WriteLine("2. Update Discount");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    foreach (var product in products)
                    {
                        product.DisplayProductDetails();
                    }
                    break;
                case 2:
                    Console.Write("Enter new discount percentage: ");
                    double newDiscount = double.Parse(Console.ReadLine());
                    Product.UpdateDiscount(newDiscount);
                    Console.WriteLine("Discount updated successfully.");
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
