using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


abstract class PatientP
{
    protected int PatientId;
    protected string Name;
    protected int Age;

    public PatientP(int id, string name, int age)
    {
        PatientId = id;
        Name = name;
        Age = age;
    }

    public abstract double CalculateBill();

    public void GetPatientDetails()
    {
        Console.WriteLine($"Patient ID: {PatientId}, Name: {Name}, Age: {Age}, Bill: {CalculateBill()}");
    }
}

interface IMedicalRecord
{
    void AddRecord(string record);
    void ViewRecords();
}

class InPatient : PatientP, IMedicalRecord
{
    private double DailyCharge;
    private int DaysAdmitted;
    private List<string> Records = new List<string>();

    public InPatient(int id, string name, int age, int days, double charge) : base(id, name, age)
    {
        DaysAdmitted = days;
        DailyCharge = charge;
    }

    public override double CalculateBill() => DaysAdmitted * DailyCharge;

    public void AddRecord(string record) => Records.Add(record);
    public void ViewRecords() => Console.WriteLine(string.Join(", ", Records));
}

class OutPatient : PatientP
{
    private double ConsultationFee;

    public OutPatient(int id, string name, int age, double fee) : base(id, name, age)
    {
        ConsultationFee = fee;
    }

    public override double CalculateBill() => ConsultationFee;
}

// Main Program
class Program
{
    static void Main()
    {
        PatientP p1 = new InPatient(1, "John Doe", 45, 5, 200);
        PatientP p2 = new OutPatient(2, "Jane Smith", 30, 50);

        p1.GetPatientDetails();
        p2.GetPatientDetails();
    }
}
