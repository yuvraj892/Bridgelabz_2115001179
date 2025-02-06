using System;
using System.Collections.Generic;
class Program6
{
    static void Main()
    {
        Hospital myHospital = new Hospital("Shekhar Hospital");

        // Creating doctors
        Doctor drShekhar = new Doctor("Shekhar ", "Cardiology");
        Doctor drShubham = new Doctor("Shubham", "Neurology");

        // Creating patients
        Patient patientRam = new Patient("Ram kumar");
        Patient patientAman = new Patient("Aman singh");

        // Adding doctors and patients to hospital
        myHospital.AddDoctor(drShekhar);
        myHospital.AddDoctor(drShubham);
        myHospital.AddPatient(patientRam);
        myHospital.AddPatient(patientAman);



        patientRam.Consult(drShekhar);
        patientRam.Consult(drShubham);
        patientAman.Consult(drShekhar)
        myHospital.DisplayHospital();
    }
}

//Class Hospital
using System;
using System.Collections.Generic;

// Represents a hospital that associates doctors and patients
class Hospital
{
    public string Name { get; set; }
    public List<Doctor> Doctors { get; set; }


    public List<Patient> Patients { get; set; }
    public Hospital(string name)
    {
        Name = name;
        Doctors = new List<Doctor>(); 
        Patients = new List<Patient>(); 
    }

    // Adds a new doctor
    public void AddDoctor(Doctor doctor)
    {
        Doctors.Add(doctor); // Adds the doctor to the hospital's list
    }

    // Adds a new patient
    public void AddPatient(Patient patient)
    {
        Patients.Add(patient);
    }
    public void DisplayHospital()
    {
        Console.WriteLine($"Hospital: {Name}");
        Console.WriteLine("Doctors:");
        foreach (var doctor in Doctors)
        {
            doctor.DisplayPatients(); // Display each doctor's consultations
        }

        // Display all patients and their consultations
        Console.WriteLine("Patients:");
        foreach (var patient in Patients)
        {
            patient.DisplayConsultations(); // Display each patient's consultation details
        }
    }
}


//class Doctor
using System;
using System.Collections.Generic;

// Represents a doctor who can consult multiple patients
class Doctor
{
    public string Name { get; set; }
    public string Specialization { get; set; }
    public List<Patient> Patients { get; set; }

    // Constructor to initialize the doctor with a name and specialization
    public Doctor(string name, string specialization)
    {
        Name = name;
        Specialization = specialization;
        Patients = new List<Patient>();
    }
    public void DisplayPatients()
    {
        Console.WriteLine($"Dr. {Name}, Specialization: {Specialization}");
        foreach (var patient in Patients)
        {
            Console.WriteLine($"Consulted Patient: {patient.Name}");
        }
    }
}
//Patient
using System;
using System.Collections.Generic;

class Patient
{
    public string Name { get; set; }
    public List<Doctor> Doctors { get; set; }
    // Constructor to initialize the patient with a name
    public Patient(string name)
    {
        // Initialize the patient's name
        Name = name;

        // Initializes an empty list of doctors the patient will consult
        Doctors = new List<Doctor>();
    }

    public void Consult(Doctor doctor)
    {
        if (!Doctors.Contains(doctor))
        {
            Doctors.Add(doctor);
            doctor.Patients.Add(this);
        }
        Console.WriteLine($"{Name} is consulting Dr. {doctor.Name}.");
    }
    public void DisplayConsultations()
    {
        Console.WriteLine($"Patient: {Name}");
        foreach (var doctor in Doctors)
        {
            Console.WriteLine($"Consulted Doctor: {doctor.Name}, Specialization: {doctor.Specialization}");
        }
    }
}
