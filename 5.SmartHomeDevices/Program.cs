// Main Program
using System;
class Program
{
    public static void Main()
    {
        // Creating a Thermostat object
        Thermostat thermostat = new Thermostat(101, "Online", 22.5);

        // Displaying device and thermostat details
        thermostat.DisplayStatus();
    }
}