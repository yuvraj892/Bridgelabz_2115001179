using System;
using System.Collections.Generic;
class Ecommerce
{
    static void Main()
    {
        ECommercePlatform myPlatform = new ECommercePlatform("flipkart");

        // Creating customers
        Customer customerAnkit = new Customer("Prasoon");
        Customer customerAmit = new Customer("Yuvraj");

        // Creating products
        Product laptop = new Product("Laptop", 1200.00);
        Product phone = new Product("Ear buds", 800.00);

        // Creating and placing orders
        Order order1 = new Order(1, customerPrasoon);
        order1.AddProduct(laptop);
        order1.AddProduct(ear buds);
        customerPrasoon.PlaceOrder(order1);

        Order order2 = new Order(2, customerYuvraj);
        order2.AddProduct(ear buds);
        customerYuvraj.PlaceOrder(order2);

        // Adding customers to the platform
        myPlatform.AddCustomer(customerPrasoon);
        myPlatform.AddCustomer(customerYuvraj);
        myPlatform.DisplayPlatform();
    }
}


//Class ECommercePlatform
using System;

using System.Collections.Generic;

// Represents an e-commerce platform that manages customers and their orders
class ECommercePlatform
{
	
    public string Name { get; set; }

    // List of customers registered on the platform
    public List<Customer> Customers { get; set; }


    // Constructor to initialize the platform with a name
    public ECommercePlatform(string name)
    {
        // Set the name of the platform
        Name = name;

        // Initializes an empty list of customers on the platform
        Customers = new List<Customer>();
    }



    public void AddCustomer(Customer customer)
    {
        // Add the customer to the platform's customer list
        Customers.Add(customer);
    }

    // Displays all customers and their orders on the platform
    public void DisplayPlatform()
    {
        // Print the platform's name
        Console.WriteLine($"E-Commerce Platform: {Name}");

        // Loop through each customer and display their orders
        foreach (var customer in Customers)
        {
            // Display each customer's orders
            customer.DisplayOrders();
        }
    }
}
//class Customer
using System;
using System.Collections.Generic;

// Represents a customer who can place orders
class Customer
{
    public string Name { get; set;     }

    // List of orders placed by the customer
    public List<Order> Orders { get; set; }
    public Customer(string name)
    {
        // Initialize the customer's name
        Name = name;

        Orders = new List<Order>();
    }
    public void PlaceOrder(Order order)
    {
		
        Orders.Add(order);
    }
    public void DisplayOrders()
    {
		
        Console.WriteLine($"Customer: {Name}");


        foreach (var order in Orders)
        {
			
            order.DisplayOrder();
        }
    }
}
//class Product
using System;
// Represents a product that is aggregated in an order
class Product
{
    // The name of the product
    public string Name { get; set; }

    // The price of the product
    public double Price { get; set; }

    // Constructor to initialize the product with a name and price
    public Product(string name, double price)
    {
        // Set the product's name
        Name = name;

        // Set the product's price
        Price = price;
    }

    // Displays the product's details including its name and price
    public void Display()
    {
        // Print the product's name and price
        Console.WriteLine($"Product: {Name}, Price: Rs.{Price}");
    }
}
//class Order
using System;
using System.Collections.Generic;
// Represents an order that contains multiple products, associated with a customer
class Order
{
    // The unique identifier for the order
    public int OrderId { get; set; }

    // The customer who placed the order
    public Customer Customer { get; set; }

    // List of products in the order
    public List<Product> Products { get; set; }

    // Constructor to initialize the order with an ID and a customer
    public Order(int orderId, Customer customer)
    {
        OrderId = orderId;
        Customer = customer;
        Products = new List<Product>();
    }

    // Adds a product to the order
    public void AddProduct(Product product)
    {
        Products.Add(product);
    }



    public void DisplayOrder()
    {
        Console.WriteLine($"Order ID: {OrderId}, Customer: {Customer.Name}");

        foreach (var product in Products)
        {
            product.Display();
        }
    }
}
