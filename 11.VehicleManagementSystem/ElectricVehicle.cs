// Subclass representing an Electric Vehicle
class ElectricVehicle : Vehicle
{
    // Constructor to initialize an electric vehicle
    public ElectricVehicle(string model, int maxSpeed) : base(model, maxSpeed)
    {
    }

    // Overriding method to display details
    public override void DisplayInfo()
    {
        Console.WriteLine($"Electric Vehicle - Model: {Model}, Max Speed: {MaxSpeed} km/h");
    }

    // Method specific to electric vehicles
    public void Charge()
    {
        Console.WriteLine("Electric vehicle is charging.");
    }
}