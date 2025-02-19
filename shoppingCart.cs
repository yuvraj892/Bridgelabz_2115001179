using System;
using System.Collections.Generic;
using System.Linq;

class ShoppingCart
{
    // Dictionary to store product prices
    private Dictionary<string, double> productPrices;
   
    // Cart items with quantities
    private Dictionary<string, int> cartItems;
   
    // LinkedList to maintain order of items added
    private LinkedList<string> orderedItems;

    public ShoppingCart()
    {
        // Initialize collections
        productPrices = new Dictionary<string, double>();
        cartItems = new Dictionary<string, int>();
        orderedItems = new LinkedList<string>();
       
        // Initialize sample product catalog
        InitializeProductCatalog();
    }

    // Initialize product catalog with sample products and prices
    private void InitializeProductCatalog()
    {
        // Add sample products with their prices
        productPrices.Add("Laptop", 999.99);
        productPrices.Add("Smartphone", 699.99);
        productPrices.Add("Headphones", 149.99);
        productPrices.Add("Mouse", 29.99);
        productPrices.Add("Keyboard", 89.99);
        productPrices.Add("Monitor", 249.99);
        productPrices.Add("USB Cable", 9.99);
    }

    // Add an item to the cart
    public void AddItem(string productName, int quantity = 1)
    {
        // Check if product exists in catalog
        if (!productPrices.ContainsKey(productName))
        {
            Console.WriteLine(String.Format("Product '{0}' not found in catalog", productName));
            return;
        }
       
        // Add or update item quantity in cart
        if (cartItems.ContainsKey(productName))
        {
            // Update existing item quantity
            cartItems[productName] += quantity;
        }
        else
        {
            // Add new item to cart
            cartItems.Add(productName, quantity);
           
            // Track order of addition
            orderedItems.AddLast(productName);
        }
       
        Console.WriteLine(String.Format("Added {0} x {1} to cart. Unit price: ${2:F2}",
            quantity, productName, productPrices[productName]));
    }

    // Remove an item from the cart
    public void RemoveItem(string productName, int quantity = 1)
    {
        // Check if item exists in cart
        if (!cartItems.ContainsKey(productName))
        {
            Console.WriteLine(String.Format("'{0}' not found in cart", productName));
            return;
        }
       
        // Check if removing more than available
        if (quantity >= cartItems[productName])
        {
            // Remove item completely
            cartItems.Remove(productName);
            orderedItems.Remove(productName);
            Console.WriteLine(String.Format("Removed '{0}' from cart", productName));
        }
        else
        {
            // Reduce quantity
            cartItems[productName] -= quantity;
            Console.WriteLine(String.Format("Removed {0} x {1} from cart. Remaining: {2}",
                quantity, productName, cartItems[productName]));
        }
    }

    // Get cart total price
    public double GetCartTotal()
    {
        double total = 0;
       
        // Calculate total by multiplying each item's price by quantity
        foreach (var item in cartItems)
        {
            string productName = item.Key;
            int quantity = item.Value;
            total += productPrices[productName] * quantity;
        }
       
        return total;
    }

    // Display the cart with items in order of addition
    public void DisplayCartInAdditionOrder()
    {
        Console.WriteLine("\nShopping Cart (Order of Addition):");
        Console.WriteLine("------------------------------------");
       
        // Check if cart is empty
        if (cartItems.Count == 0)
        {
            Console.WriteLine("Your cart is empty");
            return;
        }
       
        double total = 0;
       
        // Display items in order of addition
        foreach (string productName in orderedItems)
        {
            if (cartItems.ContainsKey(productName))
            {
                int quantity = cartItems[productName];
                double unitPrice = productPrices[productName];
                double itemTotal = unitPrice * quantity;
                total += itemTotal;
               
                Console.WriteLine(String.Format("{0} x {1} @ ${2:F2} = ${3:F2}",
                    quantity, productName, unitPrice, itemTotal));
            }
        }
       
        Console.WriteLine(String.Format("Cart Total: ${0:F2}", total));
    }

    // Display the cart with items sorted by price
    public void DisplayCartSortedByPrice()
    {
        Console.WriteLine("\nShopping Cart (Sorted by Price):");
        Console.WriteLine("------------------------------------");
       
        // Check if cart is empty
        if (cartItems.Count == 0)
        {
            Console.WriteLine("Your cart is empty");
            return;
        }
       
        double total = 0;
       
        // Get cart items sorted by unit price
        var sortedItems = cartItems
            .Select(item => new {
                ProductName = item.Key,
                Quantity = item.Value,
                UnitPrice = productPrices[item.Key]
            })
            .OrderBy(item => item.UnitPrice)
            .ToList();
       
        // Display items in sorted order
        foreach (var item in sortedItems)
        {
            double itemTotal = item.UnitPrice * item.Quantity;
            total += itemTotal;
           
            Console.WriteLine(String.Format("{0} x {1} @ ${2:F2} = ${3:F2}",
                item.Quantity, item.ProductName, item.UnitPrice, itemTotal));
        }
       
        Console.WriteLine(String.Format("Cart Total: ${0:F2}", total));
    }

    // Display the cart with items sorted by subtotal (price * quantity)
    public void DisplayCartSortedBySubtotal()
    {
        Console.WriteLine("\nShopping Cart (Sorted by Subtotal):");
        Console.WriteLine("------------------------------------");
       
        // Check if cart is empty
        if (cartItems.Count == 0)
        {
            Console.WriteLine("Your cart is empty");
            return;
        }
       
        double total = 0;
       
        // Get cart items sorted by subtotal
        var sortedItems = cartItems
            .Select(item => new {
                ProductName = item.Key,
                Quantity = item.Value,
                UnitPrice = productPrices[item.Key],
                Subtotal = productPrices[item.Key] * item.Value
            })
            .OrderByDescending(item => item.Subtotal)
            .ToList();
       
        // Display items sorted by subtotal (highest first)
        foreach (var item in sortedItems)
        {
            total += item.Subtotal;
           
            Console.WriteLine(String.Format("{0} x {1} @ ${2:F2} = ${3:F2}",
                item.Quantity, item.ProductName, item.UnitPrice, item.Subtotal));
        }
       
        Console.WriteLine(String.Format("Cart Total: ${0:F2}", total));
    }

    static void Main(string[] args)
    {
        // Create instance of shopping cart
        ShoppingCart cart = new ShoppingCart();
       
        // Add items to cart
        Console.WriteLine("Welcome to the Online Store!");
        Console.WriteLine("Adding items to your cart...\n");
       
        // Add sample items
        cart.AddItem("Laptop");
        cart.AddItem("Mouse", 2);
        cart.AddItem("USB Cable", 3);
        cart.AddItem("Headphones");
       
        // Display cart in different orders
        cart.DisplayCartInAdditionOrder();
        cart.DisplayCartSortedByPrice();
        cart.DisplayCartSortedBySubtotal();
       
        // Modify cart
        Console.WriteLine("\nModifying cart...");
        cart.RemoveItem("USB Cable", 1);
        cart.AddItem("Monitor");
       
        // Display updated cart
        cart.DisplayCartInAdditionOrder();
       
        // Check for non-existent product
        cart.AddItem("Graphics Card");
       
        Console.WriteLine(String.Format("\nFinal Cart Total: ${0:F2}", cart.GetCartTotal()));
       
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
