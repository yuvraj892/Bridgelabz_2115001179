// Base class representing a general Smart Home Device
class Device
{
    // Properties to store device ID and status
    public int DeviceId { get; private set; }
    public string Status { get; private set; }

    // Constructor to initialize a device with ID and status
    public Device(int deviceId, string status)
    {
        DeviceId = deviceId;
        Status = status;
    }

    // Virtual method to be overridden in subclasses
    public virtual void DisplayStatus()
    {
        Console.WriteLine($"Device ID: {DeviceId}, Status: {Status}");
    }
}