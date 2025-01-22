using System;
class AreaOfTriangle
{
    static void Main()
    {
        // Input: Base and height in inches
        Console.Write("base of the triangle (in inches): ");
        double baseInInches = Convert.ToDouble(Console.ReadLine());

        Console.Write("height of the triangle (in inches): ");
        double heightInInches = Convert.ToDouble(Console.ReadLine());
        // Area calculation
        double areaInSquareInches = 0.5 * baseInInches * heightInInches;
        double areaInSquareCm = areaInSquareInches * 6.4516;
        // Height conversion
        double heightInCm = heightInInches * 2.54;
        double heightInFeet = heightInInches / 12;
        double remainingInches = heightInInches % 12;
        Console.WriteLine("Area of the triangle:"+ areaInSquareInches +" square inches");
        Console.WriteLine("Area of the triangle:"+ areaInSquareCm+" square centimeters");

        Console.WriteLine("Your height in cm is" +heightInCm +"cm,");
        Console.WriteLine("while in feet and inches is "+Math.Floor(heightInFeet)+" feet"+remainingInches+"inches.");
    }
}
