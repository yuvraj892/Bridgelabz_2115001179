using System;
class OTPGenerator
{
    static void Main(string[] args)
    {
        int[] otpArray = new int[10];
        for (int i = 0; i < 10; i++)
        {
            otpArray[i] = GenerateOTP();
            Console.WriteLine($"Generated OTP {i + 1}: {otpArray[i]}");
        }
        bool isUnique = AreOTPsUnique(otpArray);
        if (isUnique)
        {
            Console.WriteLine("All OTPs are unique.");
        }
        else
        {
            Console.WriteLine("There are duplicate OTPs.");
        }
    }
    // Method to generate a 6-digit OTP
    public static int GenerateOTP()
    {
        Random random = new Random();
        return random.Next(100000, 1000000); // Generates a random 6-digit number
    }
    // Method to check if OTPs are unique
    public static bool AreOTPsUnique(int[] otpArray)
    {
        for (int i = 0; i < otpArray.Length; i++)
        {
            for (int j = i + 1; j < otpArray.Length; j++)
            {
                if (otpArray[i] == otpArray[j])
                {
                    return false; // If duplicate found, return false
                }
            }
        }
        return true; // All OTPs are unique
    }
}