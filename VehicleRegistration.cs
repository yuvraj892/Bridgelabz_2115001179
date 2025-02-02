using System;

class Vehicle
{
    // Instance variables (unique for each vehicle)
    private string ownerName;
    private string vehicleType;

    // Class variable (shared among all vehicles)
    private static double registrationFee = 100.0; // Fixed registration fee

    // Constructor to initialize vehicle details
    public Vehicle(string ownerName, string vehicleType)
    {
        this.ownerName = ownerName;
        this.vehicleType = vehicleType;
    }

    // Instance method to display vehicle details
    public void DisplayVehicleDetails()
    {
        Console.WriteLine("Owner Name: " + ownerName);
        Console.WriteLine("Vehicle Type: " + vehicleType);
        Console.WriteLine("Registration Fee: $" + registrationFee);
    }

    // Class method to update the registration fee
    public static void UpdateRegistrationFee(double newFee)
    {
        registrationFee = newFee;
    }
}
class Registration
{
    static void Main()
    {
        // Creating vehicle objects
        Vehicle v1 = new Vehicle("Ayush", "Car");
        Vehicle v2 = new Vehicle("Suresh", "Bike");

        Console.WriteLine("Before Updating Registration Fee:\n");
        v1.DisplayVehicleDetails();
        Console.WriteLine();
        v2.DisplayVehicleDetails();

        // Updating the registration fee (affects all vehicles)
        Vehicle.UpdateRegistrationFee(5000);

        Console.WriteLine("\nAfter Updating Registration Fee:\n");
        v1.DisplayVehicleDetails();
        Console.WriteLine();
        v2.DisplayVehicleDetails();
    }
}
