using System;

class Patient
{
    private static int totalPatients = 0;
    public static string HospitalName = "City Hospital";
    public readonly int PatientID;
    public string Name;
    public int Age;
    public string Ailment;

    public Patient(int PatientID, string Name, int Age, string Ailment)
    {
        this.PatientID = PatientID;
        this.Name = Name;
        this.Age = Age;
        this.Ailment = Ailment;
        totalPatients++;
    }

    public static void GetTotalPatients()
    {
        Console.WriteLine("Total Patients Admitted: " + totalPatients);
    }

    public void DisplayPatientDetails()
    {
        if (this is Patient)
        {
            Console.WriteLine("Hospital Name: " + HospitalName);
            Console.WriteLine("Patient ID: " + PatientID);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Ailment: " + Ailment);
        }
    }

    static void Main()
    {
        Console.Write("Enter number of patients: ");
        int count = int.Parse(Console.ReadLine());
        Patient[] patients = new Patient[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write("Enter Patient ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Patient Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Ailment: ");
            string ailment = Console.ReadLine();
            patients[i] = new Patient(id, name, age, ailment);
        }

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Total Patients");
            Console.WriteLine("2. Display All Patients");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    GetTotalPatients();
                    break;
                case 2:
                    foreach (var patient in patients)
                    {
                        patient.DisplayPatientDetails();
                    }
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
