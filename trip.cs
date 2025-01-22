using System;
class trip
{
    static void Main()
    {
        Console.Write("name: ");
        string name = Console.ReadLine();
        Console.Write("starting city: ");
        string fromCity = Console.ReadLine();
        Console.Write("Enter the via city: ");
        string viaCity = Console.ReadLine();
        Console.Write("destination city: ");
        string toCity = Console.ReadLine();
        Console.Write("Enter the distance from {0} to {1} (in miles): ", fromCity, viaCity);
        double fromToVia = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the distance from {0} to {1} (in miles): ", viaCity, toCity);
        double viaToFinalCity = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the time taken for the journey (in hours): ");
        double timeTaken = Convert.ToDouble(Console.ReadLine());
        double totalDistance = fromToVia + viaToFinalCity;
        double averageSpeed = totalDistance / timeTaken;
        Console.WriteLine("The results of the trip are:");
        Console.WriteLine("Traveler:" +name);
        Console.WriteLine("Total distance:"+totalDistance+" miles");
        Console.WriteLine("Average speed: "+averageSpeed+" miles per hour");
    }
}
