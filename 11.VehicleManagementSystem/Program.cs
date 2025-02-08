// Main Program
using System;

class Program
{
    public static void Main()
    {
        // Creating an Electric Vehicle object
        ElectricVehicle ev = new ElectricVehicle("Mahindra BE6", 200);
        ev.DisplayInfo();
        ev.Charge();

        // Creating a Petrol Vehicle object
        PetrolVehicle pv = new PetrolVehicle("TATA Punch", 160);
        pv.DisplayInfo();
        pv.Refuel();
    }
}
