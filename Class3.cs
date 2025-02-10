using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


abstract class VehicleR
{
    protected string VehicleNumber;
    protected string Type;
    protected double RentalRate;

    public VehicleR(string number, string type, double rate)
    {
        VehicleNumber = number;
        Type = type;
        RentalRate = rate;
    }

    public abstract double CalculateRentalCostR(int days);
}

interface IInsurable
{
    double CalculateInsurance();
    string GetInsuranceDetails();
}

class CarR : VehicleR, IInsurable
{
    public CarR(string number, double rate) : base(number, "Car", rate) { }

    public override double CalculateRentalCostR(int days) => days * RentalRate;
    public double CalculateInsurance() => 500;
    public string GetInsuranceDetails() => "Standard car insurance applied.";
}

class Bike : VehicleR, IInsurable
{
    public Bike(string number, double rate) : base(number, "Bike", rate) { }

    public override double CalculateRentalCostR(int days) => days * RentalRate;
    public double CalculateInsurance() => 200;
    public string GetInsuranceDetails() => "Basic bike insurance applied.";
}

// Main Program
class Program
{
    static void Main()
    {
        List<VehicleR> vehicles = new List<VehicleR>
        {
            new CarR("123ABC", 50),
            new Bike("456XYZ", 20)
        };

        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"{vehicle.GetType().Name} Rental Cost for 5 days: {vehicle.CalculateRentalCostR(5)}");
        }
    }
}
