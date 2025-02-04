using System;

class Vehicle
{
    private static double RegistrationFee = 500.0; // Default registration fee
    public readonly string RegistrationNumber;
    public string OwnerName;
    public string VehicleType;

    public Vehicle(string OwnerName, string VehicleType, string RegistrationNumber)
    {
        this.OwnerName = OwnerName;
        this.VehicleType = VehicleType;
        this.RegistrationNumber = RegistrationNumber;
    }

    public static void UpdateRegistrationFee(double newFee)
    {
        RegistrationFee = newFee;
    }

    public void DisplayVehicleDetails()
    {
        if (this is Vehicle)
        {
            Console.WriteLine("Owner Name: " + OwnerName);
            Console.WriteLine("Vehicle Type: " + VehicleType);
            Console.WriteLine("Registration Number: " + RegistrationNumber);
            Console.WriteLine("Registration Fee: $" + RegistrationFee);
        }
    }

    static void Main()
    {
        Console.Write("Enter number of vehicles: ");
        int count = int.Parse(Console.ReadLine());
        Vehicle[] vehicles = new Vehicle[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write("Enter Owner Name: ");
            string ownerName = Console.ReadLine();
            Console.Write("Enter Vehicle Type: ");
            string vehicleType = Console.ReadLine();
            Console.Write("Enter Registration Number: ");
            string registrationNumber = Console.ReadLine();
            vehicles[i] = new Vehicle(ownerName, vehicleType, registrationNumber);
        }

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display All Vehicles");
            Console.WriteLine("2. Update Registration Fee");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    foreach (var vehicle in vehicles)
                    {
                        vehicle.DisplayVehicleDetails();
                    }
                    break;
                case 2:
                    Console.Write("Enter new registration fee: ");
                    double newFee = double.Parse(Console.ReadLine());
                    UpdateRegistrationFee(newFee);
                    Console.WriteLine("Registration fee updated successfully.");
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
