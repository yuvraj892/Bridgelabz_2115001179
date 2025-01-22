using System;
    class heightConversion{
        static void Main(){
            Console.Write("Enter your height in cm: ");
            double height= Convert.ToInt32(Console.ReadLine());
            double heightInInches= height/2.54;
			double heigtInFoots= heightInInches/12;
			Console.WriteLine("Your Height in cm is "+ height+" while in feet is "+heigtInFoots+" and inches is " + heightInInches;
        }
    }