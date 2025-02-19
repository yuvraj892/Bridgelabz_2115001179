using System;
using System.Collections.Generic;

class HospitalTriageSystem
{
    // Class to represent a patient
    public class Patient
    {
        // Patient's name (read-only)
        public string Name { get; private set; }
        // Patient's severity level (higher means more severe) (read-only)
        public int Severity { get; private set; }
        // Time when patient was added to the queue (read-only)
        public DateTime ArrivalTime { get; private set; }

        // Constructor to initialize patient details
        public Patient(string name, int severity)
        {
            // Set patient name
            Name = name;
            // Set severity level
            Severity = severity;
            // Set arrival time to current time
            ArrivalTime = DateTime.Now;
        }

        // Override ToString method for better display
        public override string ToString()
        {
            // Return a string representation of the patient
            return "Patient: " + Name + ", Severity: " + Severity + ", Arrival Time: " + ArrivalTime.ToString("HH:mm:ss");
        }
    }

    // Custom comparer for patients based on severity
    public class PatientComparer : IComparer<Patient>
    {
        // Compare method to determine priority
        public int Compare(Patient x, Patient y)
        {
            // Compare based on severity (higher severity first)
            int severityComparison = y.Severity.CompareTo(x.Severity);

            // If severity is the same, compare by arrival time (earlier arrival first)
            if (severityComparison == 0)
            {
                // Return comparison based on arrival time
                return x.ArrivalTime.CompareTo(y.ArrivalTime);
            }

            // Return comparison based on severity
            return severityComparison;
        }
    }

    static void Main(string[] args)
    {
        // Create a priority queue for patients using SortedSet
        SortedSet<Patient> triageQueue = new SortedSet<Patient>(new PatientComparer());

        // Add patients to the queue
        AddPatient(triageQueue, "John", 3);
        // Pause to ensure different arrival times
        System.Threading.Thread.Sleep(100);
        AddPatient(triageQueue, "Alice", 5);
        System.Threading.Thread.Sleep(100);
        AddPatient(triageQueue, "Bob", 2);
        System.Threading.Thread.Sleep(100);
        AddPatient(triageQueue, "Carol", 4);
        System.Threading.Thread.Sleep(100);
        AddPatient(triageQueue, "David", 1);
        System.Threading.Thread.Sleep(100);
        AddPatient(triageQueue, "Eve", 5);
        System.Threading.Thread.Sleep(100);

        // Print the current queue
        Console.WriteLine("Current Triage Queue:");
        // Print each patient in the queue
        PrintQueue(triageQueue);

        // Process patients in order of priority
        Console.WriteLine("\nProcessing patients in order of priority:");
        // Process all patients
        ProcessAllPatients(triageQueue);

        // Add more patients to demonstrate dynamic priority
        Console.WriteLine("\nAdding emergency patient:");
        // Add an emergency patient
        AddPatient(triageQueue, "Frank", 10);
        // Add a standard patient
        AddPatient(triageQueue, "Grace", 3);

        // Print the updated queue
        Console.WriteLine("\nUpdated Triage Queue:");
        // Print each patient in the updated queue
        PrintQueue(triageQueue);

        // Process remaining patients
        Console.WriteLine("\nProcessing remaining patients:");
        // Process all remaining patients
        ProcessAllPatients(triageQueue);
    }

    // Method to add a patient to the triage queue
    private static void AddPatient(SortedSet<Patient> queue, string name, int severity)
    {
        // Create a new patient
        Patient patient = new Patient(name, severity);
        // Add patient to the queue
        queue.Add(patient);
        // Print notification of patient addition
        Console.WriteLine("Added: " + patient);
    }

    // Method to print the current state of the queue
    private static void PrintQueue(SortedSet<Patient> queue)
    {
        // Check if queue is empty
        if (queue.Count == 0)
        {
            // Print message for empty queue
            Console.WriteLine("Queue is empty.");
            return;
        }

        // Print each patient in the queue
        foreach (Patient patient in queue)
        {
            // Print patient information
            Console.WriteLine("  " + patient);
        }
    }

    // Method to process all patients in the queue
    private static void ProcessAllPatients(SortedSet<Patient> queue)
    {
        // Iterate until queue is empty
        while (queue.Count > 0)
        {
            // Get the highest priority patient
            Patient nextPatient = queue.Min;
            // Remove the patient from the queue
            queue.Remove(nextPatient);
            // Print notification of processing the patient
            Console.WriteLine("Processing: " + nextPatient);
        }
    }
}
