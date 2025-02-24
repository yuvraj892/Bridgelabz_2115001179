using System;
using System.Reflection;

namespace ReflectionPractice
{
    [AttributeUsage(AttributeTargets.Property)]
    public class InjectAttribute : Attribute { }

    public class Service
    {
        public void Execute()
        {
            Console.WriteLine("Service executed.");
        }
    }

    public class Client
    {
        // Property with Inject attribute
        [Inject]
        public Service Service { get; set; }
    }

    public class DIContainer
    {
        // Method to inject dependencies
        public static void InjectDependencies(object obj)
        {
            // Get type of the object
            Type type = obj.GetType();

            // Get properties with Inject attribute
            foreach (var prop in type.GetProperties())
            {
                if (prop.GetCustomAttribute(typeof(InjectAttribute)) != null)
                {
                    // Create instance of dependency
                    object instance = Activator.CreateInstance(prop.PropertyType);

                    // Set the property value
                    prop.SetValue(obj, instance);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create instance of Client
            Client client = new Client();

            // Inject dependencies
            DIContainer.InjectDependencies(client);

            // Call method of injected service
            client.Service.Execute();

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
