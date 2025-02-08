// Derived class representing a Car
class Car : Vehicle
{
    // Additional attribute for Car
    public int SeatCapacity { get; private set; }

    // Constructor to initialize Car using the base class constructor
    public Car(int maxSpeed, string fuelType, int seatCapacity) : base(maxSpeed, fuelType)
    {
        SeatCapacity = seatCapacity;
    }

    // Overriding DisplayInfo method to provide specific details
    public override void DisplayInfo()
    {
        Console.WriteLine($"Car - Max Speed: {MaxSpeed} km/h, Fuel Type: {FuelType}, Seat Capacity: {SeatCapacity}");
    }
}