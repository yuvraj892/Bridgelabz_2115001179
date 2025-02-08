// Base class representing a general Vehicle
class Vehicle
{
    // Properties for vehicle details
    public int MaxSpeed { get; private set; }
    public string Model { get; private set; }

    // Constructor to initialize a vehicle
    public Vehicle(string model, int maxSpeed)
    {
        Model = model;
        MaxSpeed = maxSpeed;
    }

    // Virtual method to display vehicle information
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Vehicle - Model: {Model}, Max Speed: {MaxSpeed} km/h");
    }
}