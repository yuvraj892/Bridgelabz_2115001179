// Subclass representing a Petrol Vehicle
class PetrolVehicle : Vehicle, IRefuelable
{
    // Constructor to initialize a petrol vehicle
    public PetrolVehicle(string model, int maxSpeed) : base(model, maxSpeed)
    {
    }

    // Overriding method to display details
    public override void DisplayInfo()
    {
        Console.WriteLine($"Petrol Vehicle - Model: {Model}, Max Speed: {MaxSpeed} km/h");
    }

    // Implementing Refuel method from IRefuelable interface
    public void Refuel()
    {
        Console.WriteLine("Petrol vehicle is refueling.");
    }
}
