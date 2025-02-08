// Derived class representing a Motorcycle
class Motorcycle : Vehicle
{
    // Additional attribute for Motorcycle
    public bool HasSidecar { get; private set; }

    // Constructor to initialize Motorcycle using the base class constructor
    public Motorcycle(int maxSpeed, string fuelType, bool hasSidecar) : base(maxSpeed, fuelType)
    {
        HasSidecar = hasSidecar;
    }

    // Overriding DisplayInfo method to provide specific details
    public override void DisplayInfo()
    {
        Console.WriteLine($"Motorcycle - Max Speed: {MaxSpeed} km/h, Fuel Type: {FuelType}, Has Sidecar: {HasSidecar}");
    }
}