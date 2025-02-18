using System;
using System.Collections.Generic;

// Abstract class representing a Job Role
public abstract class JobRole
{
    // Property to store the job title
    public string Title { get; set; }

    // Property to store the required skills for the role
    public List<string> RequiredSkills { get; set; }

    // Constructor to initialize the job role
    public JobRole(string title, List<string> requiredSkills)
    {
        Title = title;
        RequiredSkills = requiredSkills;
    }

    // Abstract method to evaluate a resume based on job-specific criteria
    public abstract bool EvaluateResume(List<string> candidateSkills);
}

// Class representing the Software Engineer job role
public class SoftwareEngineer : JobRole
{
    // Constructor initializing the Software Engineer role with required skills
    public SoftwareEngineer() : base("Software Engineer", new List<string> { "C#", "ASP.NET", "SQL", "JavaScript" }) { }

    // Overridden method to evaluate a candidate's resume for a Software Engineer role
    public override bool EvaluateResume(List<string> candidateSkills)
    {
        // Check if candidate has at least 50% of the required skills
        int matchCount = 0;
        foreach (var skill in RequiredSkills)
        {
            if (candidateSkills.Contains(skill))
            {
                matchCount++;
            }
        }
        return matchCount >= RequiredSkills.Count / 2;
    }
}

// Class representing the Data Scientist job role
public class DataScientist : JobRole
{
    // Constructor initializing the Data Scientist role with required skills
    public DataScientist() : base("Data Scientist", new List<string> { "Python", "Machine Learning", "Statistics", "SQL" }) { }

    // Overridden method to evaluate a candidate's resume for a Data Scientist role
    public override bool EvaluateResume(List<string> candidateSkills)
    {
        // Check if candidate has at least 50% of the required skills
        int matchCount = 0;
        foreach (var skill in RequiredSkills)
        {
            if (candidateSkills.Contains(skill))
            {
                matchCount++;
            }
        }
        return matchCount >= RequiredSkills.Count / 2;
    }
}

// Generic class to manage resumes for different job roles
public class Resume<T> where T : JobRole
{
    // List to store all resumes being processed
    private List<T> jobRoles = new List<T>();

    // Method to add a new job role to the system
    public void AddJobRole(T jobRole)
    {
        jobRoles.Add(jobRole);
        Console.WriteLine($"Added job role: {jobRole.Title}");
    }

    // Generic method to process a candidate's resume
    public void ProcessResume<TCandidate>(TCandidate candidate, T jobRole) where TCandidate : Candidate
    {
        Console.WriteLine($"\nProcessing resume for {candidate.Name} applying for {jobRole.Title}");

        // Check if the candidate meets the job role criteria
        if (jobRole.EvaluateResume(candidate.Skills))
        {
            Console.WriteLine($"✅ {candidate.Name} is shortlisted for {jobRole.Title}!");
        }
        else
        {
            Console.WriteLine($"❌ {candidate.Name} does not meet the requirements for {jobRole.Title}.");
        }
    }
}

// Class representing a Candidate applying for a job
public class Candidate
{
    // Property to store the candidate's name
    public string Name { get; set; }

    // List to store the candidate's skills
    public List<string> Skills { get; set; }

    // Constructor to initialize a candidate
    public Candidate(string name, List<string> skills)
    {
        Name = name;
        Skills = skills;
    }
}

// Main program to test the AI-Driven Resume Screening System
public class Program
{
    public static void Main(string[] args)
    {
        // Creating job roles
        SoftwareEngineer softwareEngineerRole = new SoftwareEngineer();
        DataScientist dataScientistRole = new DataScientist();

        // Creating candidates
        Candidate candidate1 = new Candidate("Alice", new List<string> { "C#", "SQL", "JavaScript" });
        Candidate candidate2 = new Candidate("Bob", new List<string> { "Python", "Machine Learning" });
        Candidate candidate3 = new Candidate("Charlie", new List<string> { "Java", "Spring Boot", "SQL" });

        // Creating a Resume Manager for different job roles
        Resume<JobRole> resumeManager = new Resume<JobRole>();

        // Adding job roles to the system
        resumeManager.AddJobRole(softwareEngineerRole);
        resumeManager.AddJobRole(dataScientistRole);

        // Processing candidate resumes
        resumeManager.ProcessResume(candidate1, softwareEngineerRole); // Alice should be shortlisted
        resumeManager.ProcessResume(candidate2, dataScientistRole); // Bob should be shortlisted
        resumeManager.ProcessResume(candidate3, softwareEngineerRole); // Charlie should not be shortlisted
    }
}
