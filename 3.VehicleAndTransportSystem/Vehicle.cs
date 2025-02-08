// Base class representing a general Vehicle
class Vehicle
{
    // Properties to store max speed and fuel type of the vehicle
    public int MaxSpeed { get; private set; }
    public string FuelType { get; private set; }

    // Constructor to initialize the vehicle with max speed and fuel type
    public Vehicle(int maxSpeed, string fuelType)
    {
        MaxSpeed = maxSpeed;
        FuelType = fuelType;
    }

    // Virtual method to be overridden by subclasses (provides default vehicle details)
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Vehicle - Max Speed: {MaxSpeed} km/h, Fuel Type: {FuelType}");
    }
}
