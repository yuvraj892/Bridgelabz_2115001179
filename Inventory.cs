using System;

// Define a node class to store item information
class ItemNode
{
    // Item attributes
    public string ItemName;
    public int ItemID;
    public int Quantity;
    public double Price;
    public ItemNode next;
    
    // Constructor to initialize an item node
    public ItemNode(string ItemName, int ItemID, int Quantity, double Price)
    {
        this.ItemName = ItemName;
        this.ItemID = ItemID;
        this.Quantity = Quantity;
        this.Price = Price;
        this.next = null;
    }
}

// Define the inventory management class
class InventoryManager
{
    private ItemNode head;
    
    // Constructor to initialize empty inventory
    public InventoryManager()
    {
        head = null;
    }
    
    // Method to add item at the beginning of the list
    public void AddItemAtBeginning(string ItemName, int ItemID, int Quantity, double Price)
    {
        ItemNode newItem = new ItemNode(ItemName, ItemID, Quantity, Price);
        newItem.next = head;
        head = newItem;
        Console.WriteLine("Item " + ItemName + " added successfully at beginning.");
    }
    
    // Method to add item at the end of the list
    public void AddItemAtEnd(string ItemName, int ItemID, int Quantity, double Price)
    {
        ItemNode newItem = new ItemNode(ItemName, ItemID, Quantity, Price);
        
        if (head == null)
        {
            head = newItem;
            return;
        }
        
        ItemNode temp = head;
        while (temp.next != null)
        {
            temp = temp.next;
        }
        temp.next = newItem;
        Console.WriteLine("Item " + ItemName + " added successfully at end.");
    }
    
    // Method to add item at specific position
    public void AddItemAtPosition(string ItemName, int ItemID, int Quantity, double Price, int position)
    {
        if (position < 1)
        {
            Console.WriteLine("Invalid position");
            return;
        }
        
        if (position == 1)
        {
            AddItemAtBeginning(ItemName, ItemID, Quantity, Price);
            return;
        }
        
        ItemNode newItem = new ItemNode(ItemName, ItemID, Quantity, Price);
        ItemNode temp = head;
        for (int i = 1; i < position - 1 && temp != null; i++)
        {
            temp = temp.next;
        }
        
        if (temp == null)
        {
            Console.WriteLine("Position out of range");
            return;
        }
        
        newItem.next = temp.next;
        temp.next = newItem;
        Console.WriteLine("Item " + ItemName + " added successfully at position " + position);
    }
    
    // Method to remove item by ID
    public void RemoveItem(int ItemID)
    {
        if (head == null)
        {
            Console.WriteLine("Inventory is empty");
            return;
        }
        
        if (head.ItemID == ItemID)
        {
            head = head.next;
            Console.WriteLine("Item with ID " + ItemID + " removed successfully");
            return;
        }
        
        ItemNode temp = head;
        ItemNode prev = null;
        
        while (temp != null && temp.ItemID != ItemID)
        {
            prev = temp;
            temp = temp.next;
        }
        
        if (temp == null)
        {
            Console.WriteLine("Item not found");
            return;
        }
        
        prev.next = temp.next;
        Console.WriteLine("Item with ID " + ItemID + " removed successfully");
    }
    
    // Method to update quantity by ID
    public void UpdateQuantity(int ItemID, int newQuantity)
    {
        ItemNode temp = head;
        while (temp != null)
        {
            if (temp.ItemID == ItemID)
            {
                temp.Quantity = newQuantity;
                Console.WriteLine("Quantity updated successfully for item with ID " + ItemID);
                return;
            }
            temp = temp.next;
        }
        Console.WriteLine("Item not found");
    }
    
    // Method to search item by ID
    public void SearchByID(int ItemID)
    {
        ItemNode temp = head;
        while (temp != null)
        {
            if (temp.ItemID == ItemID)
            {
                Console.WriteLine("Item found - Name: " + temp.ItemName + 
                                ", ID: " + temp.ItemID + 
                                ", Quantity: " + temp.Quantity + 
                                ", Price: $" + temp.Price);
                return;
            }
            temp = temp.next;
        }
        Console.WriteLine("Item not found");
    }
    
    // Method to search item by name
    public void SearchByName(string ItemName)
    {
        ItemNode temp = head;
        while (temp != null)
        {
            if (temp.ItemName.ToLower() == ItemName.ToLower())
            {
                Console.WriteLine("Item found - Name: " + temp.ItemName + 
                                ", ID: " + temp.ItemID + 
                                ", Quantity: " + temp.Quantity + 
                                ", Price: $" + temp.Price);
                return;
            }
            temp = temp.next;
        }
        Console.WriteLine("Item not found");
    }
    
    // Method to calculate total inventory value
    public double CalculateTotalValue()
    {
        double totalValue = 0;
        ItemNode temp = head;
        while (temp != null)
        {
            totalValue += temp.Price * temp.Quantity;
            temp = temp.next;
        }
        return totalValue;
    }
    
    // Method to sort inventory by name (bubble sort)
    public void SortByName(bool ascending)
    {
        if (head == null || head.next == null)
            return;
            
        bool swapped;
        ItemNode temp;
        ItemNode lptr = null;
        
        do
        {
            swapped = false;
            temp = head;
            
            while (temp.next != lptr)
            {
                if (ascending ? 
                    string.Compare(temp.ItemName, temp.next.ItemName) > 0 :
                    string.Compare(temp.ItemName, temp.next.ItemName) < 0)
                {
                    // Swap the nodes
                    string tempName = temp.ItemName;
                    int tempID = temp.ItemID;
                    int tempQty = temp.Quantity;
                    double tempPrice = temp.Price;
                    
                    temp.ItemName = temp.next.ItemName;
                    temp.ItemID = temp.next.ItemID;
                    temp.Quantity = temp.next.Quantity;
                    temp.Price = temp.next.Price;
                    
                    temp.next.ItemName = tempName;
                    temp.next.ItemID = tempID;
                    temp.next.Quantity = tempQty;
                    temp.next.Price = tempPrice;
                    
                    swapped = true;
                }
                temp = temp.next;
            }
            lptr = temp;
        }
        while (swapped);
    }
    
    // Method to sort inventory by price (bubble sort)
    public void SortByPrice(bool ascending)
    {
        if (head == null || head.next == null)
            return;
            
        bool swapped;
        ItemNode temp;
        ItemNode lptr = null;
        
        do
        {
            swapped = false;
            temp = head;
            
            while (temp.next != lptr)
            {
                if (ascending ? 
                    temp.Price > temp.next.Price :
                    temp.Price < temp.next.Price)
                {
                    // Swap the nodes
                    string tempName = temp.ItemName;
                    int tempID = temp.ItemID;
                    int tempQty = temp.Quantity;
                    double tempPrice = temp.Price;
                    
                    temp.ItemName = temp.next.ItemName;
                    temp.ItemID = temp.next.ItemID;
                    temp.Quantity = temp.next.Quantity;
                    temp.Price = temp.next.Price;
                    
                    temp.next.ItemName = tempName;
                    temp.next.ItemID = tempID;
                    temp.next.Quantity = tempQty;
                    temp.next.Price = tempPrice;
                    
                    swapped = true;
                }
                temp = temp.next;
            }
            lptr = temp;
        }
        while (swapped);
    }
    
    // Method to display all items
    public void DisplayInventory()
    {
        if (head == null)
        {
            Console.WriteLine("Inventory is empty");
            return;
        }
        
        ItemNode temp = head;
        while (temp != null)
        {
            Console.WriteLine("Name: " + temp.ItemName + 
                            ", ID: " + temp.ItemID + 
                            ", Quantity: " + temp.Quantity + 
                            ", Price: $" + temp.Price);
            temp = temp.next;
        }
        Console.WriteLine("Total Inventory Value: $" + CalculateTotalValue());
    }
    
    // Main method to test the implementation
    public static void Main()
    {
        InventoryManager inventory = new InventoryManager();
        
        // Add sample items
        inventory.AddItemAtBeginning("Laptop", 1, 10, 999.99);
        inventory.AddItemAtEnd("Mouse", 2, 20, 29.99);
        inventory.AddItemAtPosition("Keyboard", 3, 15, 59.99, 2);
        
        // Display initial inventory
        Console.WriteLine("\nInitial Inventory:");
        inventory.DisplayInventory();
        
        // Test search functionality
        Console.WriteLine("\nSearching for item with ID 2:");
        inventory.SearchByID(2);
        
        // Update quantity
        Console.WriteLine("\nUpdating quantity for item with ID 1 to 5:");
        inventory.UpdateQuantity(1, 5);
        
        // Sort by name ascending
        Console.WriteLine("\nInventory sorted by name (ascending):");
        inventory.SortByName(true);
        inventory.DisplayInventory();
        
        // Sort by price descending
        Console.WriteLine("\nInventory sorted by price (descending):");
        inventory.SortByPrice(false);
        inventory.DisplayInventory();
        
        // Remove an item
        Console.WriteLine("\nRemoving item with ID 2:");
        inventory.RemoveItem(2);
        
        // Display final inventory
        Console.WriteLine("\nFinal Inventory:");
        inventory.DisplayInventory();
    }
}