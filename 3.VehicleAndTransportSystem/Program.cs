// Main Program
using System;

class Program
{
    public static void Main()
    {
        // Creating object for a Car
        Car car = new Car(200, "Petrol", 5);
        // Displaying details of car
        car.DisplayInfo();
        //Creating object for a Truck
        Truck truck = new Truck(120, "Diesel", 10000);
        // Displaying details of truck
        truck.DisplayInfo();
        //Creating object for a Motorcycle
        Motorcycle motorcycle = new Motorcycle(180, "Petrol", true);
        // Displaying details of motorcycle
        motorcycle.DisplayInfo();
    }
}

