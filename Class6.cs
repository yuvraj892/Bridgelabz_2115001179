using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class FoodItem
{
    protected string ItemName;
    protected double Price;
    protected int Quantity;

    public FoodItem(string name, double price, int quantity)
    {
        ItemName = name;
        Price = price;
        Quantity = quantity;
    }

    public abstract double CalculateTotalPrice();

    public void GetItemDetails()
    {
        Console.WriteLine($"Item: {ItemName}, Price: {Price}, Quantity: {Quantity}, Total: {CalculateTotalPrice()}");
    }
}

interface IDiscountable
{
    double ApplyDiscount();
    string GetDiscountDetails();
}

class VegItem : FoodItem, IDiscountable
{
    public VegItem(string name, double price, int quantity) : base(name, price, quantity) { }

    public override double CalculateTotalPrice() => Price * Quantity - ApplyDiscount();
    public double ApplyDiscount() => Price * Quantity * 0.1;
    public string GetDiscountDetails() => "10% discount on Veg Items";
}

class NonVegItem : FoodItem
{
    public NonVegItem(string name, double price, int quantity) : base(name, price, quantity) { }

    public override double CalculateTotalPrice() => Price * Quantity + 2.5;
}

// Main Program
class Program
{
    static void Main()
    {
        List<FoodItem> menu = new List<FoodItem>
        {
            new VegItem("Paneer Tikka", 8.99, 2),
            new NonVegItem("Chicken Curry", 12.50, 1)
        };

        foreach (var item in menu)
        {
            item.GetItemDetails();
        }
    }
}

