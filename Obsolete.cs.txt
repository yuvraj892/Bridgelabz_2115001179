using System;

namespace Obsolete
{
    public class LegacyAPI
    {
        // Mark method as obsolete with a message
        [Obsolete("This method is deprecated. Use NewFeature() instead.")]
        public void OldFeature()
        {
            Console.WriteLine("Old feature");
        }

        // New method to use instead
        public void NewFeature()
        {
            Console.WriteLine("New feature");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create instance of LegacyAPI
            LegacyAPI api = new LegacyAPI();
            // Call both methods
            api.OldFeature();
            api.NewFeature();
        }
    }
}