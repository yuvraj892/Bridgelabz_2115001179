using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class VehicleA
{
    protected int VehicleId;
    protected string DriverName;
    protected double RatePerKm;

    public VehicleA(int id, string driver, double rate)
    {
        VehicleId = id;
        DriverName = driver;
        RatePerKm = rate;
    }

    public abstract double CalculateFare(double distance);

    public void GetVehicleDetails()
    {
        Console.WriteLine($"Vehicle ID: {VehicleId}, Driver: {DriverName}, Rate per Km: {RatePerKm}");
    }
}

interface IGPS
{
    string GetCurrentLocation();
    void UpdateLocation(string newLocation);
}

class CarA : VehicleA, IGPS
{
    public CarA(int id, string driver, double rate) : base(id, driver, rate) { }

    public override double CalculateFare(double distance) => distance * RatePerKm;
    public string GetCurrentLocation() => "Current location: Downtown";
    public void UpdateLocation(string newLocation) => Console.WriteLine($"Location updated to {newLocation}");
}

class BikeA : VehicleA, IGPS
{
    public BikeA(int id, string driver, double rate) : base(id, driver, rate) { }

    public override double CalculateFare(double distance) => distance * RatePerKm * 0.9;
    public string GetCurrentLocation() => "Current location: City Center";
    public void UpdateLocation(string newLocation) => Console.WriteLine($"Location updated to {newLocation}");
}

// Main Program
class Program
{
    static void Main()
    {
        List<VehicleA> rides = new List<VehicleA>
        {
            new CarA(101, "John Doe", 5),
            new BikeA(202, "Jane Smith", 2)
        };

        foreach (var ride in rides)
        {
            ride.GetVehicleDetails();
            Console.WriteLine($"Fare for 10 km: {ride.CalculateFare(10)}");
        }
    }
}
