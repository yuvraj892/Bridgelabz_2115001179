using System;
class CarRental
{
    private string customerName;
    private string carModel;
    private int rentalDays;
    private double dailyRate;
    private double totalCost;

    // Default constructor
    public CarRental()
    {
        customerName = "Unknown";
        carModel = "Not Assigned";
        rentalDays = 0;
        dailyRate = 50.0; // Default daily rental rate
        totalCost = 0.0;
    }
    // Parameterized constructor
    public CarRental(string customerName, string carModel, int rentalDays, double dailyRate)
    {
        this.customerName = customerName;
        this.carModel = carModel;
        this.rentalDays = rentalDays;
        this.dailyRate = dailyRate;
        CalculateTotalCost();
    }
    // Copy constructor
    public CarRental(CarRental other)
    {
        this.customerName = other.customerName;
        this.carModel = other.carModel;
        this.rentalDays = other.rentalDays;
        this.dailyRate = other.dailyRate;
        this.totalCost = other.totalCost;
    }
    // Private method to calculate total cost
    private void CalculateTotalCost()
    {
        totalCost = rentalDays * dailyRate;
    }
    // Method to display rental details
    public void DisplayRental()
    {
        Console.WriteLine("Customer Name: " + customerName);
        Console.WriteLine("Car Model: " + carModel);
        Console.WriteLine("Rental Days: " + rentalDays);
        Console.WriteLine("Daily Rate: " + dailyRate);
        Console.WriteLine("Total Cost: " + totalCost);
    }
}

class rentalDetail
{
    static void Main()
    {
        CarRental rental1 = new CarRental();  // Default constructor
        CarRental rental2 = new CarRental("Ayushh", "wagonar", 5, 2000, 10000);  // Parameterized constructor
        CarRental rental3 = new CarRental(rental2);  // Copy constructor

        Console.WriteLine("Default Rental:");
        rental1.DisplayRental();

        Console.WriteLine("\nCustom Rental:");
        rental2.DisplayRental();

        Console.WriteLine("\nCopied Rental:");
        rental3.DisplayRental();
    }
}
