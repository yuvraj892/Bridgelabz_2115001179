using System;
class tallestFriend
{
    static void Main()
    {
        // Take user input for ages
        Console.WriteLine("Enter the age of Amar: ");
        int ageAmar = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the age of Akbar: ");
        int ageAkbar = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the age of Anthony: ");
        int ageAnthony = int.Parse(Console.ReadLine());
        // Take user input for heights
        Console.WriteLine("Enter the height of Amar (in cm): ");
        int heightAmar = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the height of Akbar (in cm): ");
        int heightAkbar = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the height of Anthony (in cm): ");
        int heightAnthony = int.Parse(Console.ReadLine());
        // Find the youngest friend based on age
        int youngestAge = Math.Min(ageAmar, Math.Min(ageAkbar, ageAnthony));
        if (youngestAge == ageAmar)
        {
            Console.WriteLine("The youngest friend is Amar.");
        }
        else if (youngestAge == ageAkbar)
        {
            Console.WriteLine("The youngest friend is Akbar.");
        }
        else
        {
            Console.WriteLine("The youngest friend is Anthony.");
        }

        // Find the tallest friend based on height
        int tallestHeight = Math.Max(heightAmar, Math.Max(heightAkbar, heightAnthony));
        if (tallestHeight == heightAmar)
        {
            Console.WriteLine("The tallest friend is Amar.");
        }
        else if (tallestHeight == heightAkbar)
        {
            Console.WriteLine("The tallest friend is Akbar.");
        }
        else
        {
            Console.WriteLine("The tallest friend is Anthony.");
        }
    }
}
