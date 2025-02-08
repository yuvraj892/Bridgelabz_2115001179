// Derived class representing a Truck
class Truck : Vehicle
{
    // Additional attribute for Truck
    public int PayloadCapacity { get; private set; }

    // Constructor to initialize Truck using the base class constructor
    public Truck(int maxSpeed, string fuelType, int payloadCapacity) : base(maxSpeed, fuelType)
    {
        PayloadCapacity = payloadCapacity;
    }

    // Overriding DisplayInfo method to provide specific details
    public override void DisplayInfo()
    {
        Console.WriteLine($"Truck - Max Speed: {MaxSpeed} km/h, Fuel Type: {FuelType}, Payload Capacity: {PayloadCapacity} kg");
    }
}