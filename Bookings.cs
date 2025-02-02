using System;
class HotelBooking
{
    private string guestName;
    private string roomType;
    private int nights;

    // Default constructor
    public HotelBooking()
    {
        guestName = "Unknown";
        roomType = "Standard";
        nights = 1;
    }

    // Parameterized constructor
    public HotelBooking(string guestName, string roomType, int nights)
    {
        this.guestName = guestName;
        this.roomType = roomType;
        this.nights = nights;
    }

    // Copy constructor
    public HotelBooking(HotelBooking other)
    {
        this.guestName = other.guestName;
        this.roomType = other.roomType;
        this.nights = other.nights;
    }

    // Method to display booking details
    public void showBookings()
    {
        Console.WriteLine("Guest Name: " + guestName);
        Console.WriteLine("Room Type: " + roomType);
        Console.WriteLine("Nights: " + nights);
    }
}

class Bookings
{
    static void Main()
    {
        HotelBooking booking1 = new HotelBooking();  // Default constructor
        HotelBooking booking2 = new HotelBooking("Ayush", "double bed", 2);  // Parameterized constructor
        HotelBooking booking3 = new HotelBooking(booking2);  // Copy constructor

        Console.WriteLine("Default Booking:");
        booking1.showBookings();

        Console.WriteLine("\nCustom Booking:");
        booking2.showBookings();

        Console.WriteLine("\nCopied Booking:");
        booking3.showBookings();
    }
}
