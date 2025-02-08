// Derived class representing a Thermostat
class Thermostat : Device
{
    // Additional attribute for Thermostat
    public double TemperatureSetting { get; private set; }

    // Constructor to initialize a thermostat along with device details
    public Thermostat(int deviceId, string status, double temperatureSetting) : base(deviceId, status)
    {
        TemperatureSetting = temperatureSetting;
    }

    // Overriding DisplayStatus to include thermostat details
    public override void DisplayStatus()
    {
        base.DisplayStatus();
        Console.WriteLine($"Temperature Setting: {TemperatureSetting}°C");
    }
}
