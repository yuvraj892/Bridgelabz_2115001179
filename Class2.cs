using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


abstract class ProductP
{
    protected int ProductId;
    protected string Name;
    protected double Price;

    public ProductP(int id, string name, double price)
    {
        ProductId = id;
        Name = name;
        Price = price;
    }

    public abstract double CalculateDiscount();
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Product: {Name}, Price: {Price}, Discount: {CalculateDiscount()}");
    }
}

interface ITaxable
{
    double CalculateTax();
    string GetTaxDetails();
}

class Electronics : ProductP, ITaxable
{
    public Electronics(int id, string name, double price) : base(id, name, price) { }
    public override double CalculateDiscount() => Price * 0.1;
    public double CalculateTax() => Price * 0.18;
    public string GetTaxDetails() => "18% tax applied";
}

class Clothing : ProductP, ITaxable
{
    public Clothing(int id, string name, double price) : base(id, name, price) { }
    public override double CalculateDiscount() => Price * 0.15;
    public double CalculateTax() => Price * 0.12;
    public string GetTaxDetails() => "12% tax applied";
}

class Groceries : ProductP
{
    public Groceries(int id, string name, double price) : base(id, name, price) { }
    public override double CalculateDiscount() => Price * 0.05;
}

// Main Program
class Program
{
    static void Main()
    {
        List<ProductP> products = new List<ProductP>
        {
            new Electronics(1, "Laptop", 1000),
            new Clothing(2, "T-Shirt", 50),
            new Groceries(3, "Apple", 2)
        };

        foreach (var product in products)
        {
            product.DisplayDetails();
        }
    }
}
