using System;
using System.Collections.Generic;
using System.Linq;

class InsurancePolicyManagementSystem
{
    // Define Policy class to represent insurance policies
    class Policy : IComparable<Policy>
    {
        public string PolicyNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CoverageType { get; set; }
        public decimal Premium { get; set; }

        // Override Equals method for HashSet comparison
        public override bool Equals(object obj)
        {
            if (obj is Policy other)
            {
                return this.PolicyNumber == other.PolicyNumber;
            }
            return false;
        }

        // Override GetHashCode for HashSet operations
        public override int GetHashCode()
        {
            return PolicyNumber.GetHashCode();
        }

        // Implement CompareTo for SortedSet functionality
        public int CompareTo(Policy other)
        {
            return this.ExpiryDate.CompareTo(other.ExpiryDate);
        }

        // Override ToString for display purposes
        public override string ToString()
        {
            return String.Format("Policy #{0}: {1}, Expires: {2}, Type: {3}, Premium: ${4}",
                PolicyNumber, CustomerName, ExpiryDate.ToShortDateString(),
                CoverageType, Premium);
        }
    }

    // HashSet for quick lookups of unique policies
    private HashSet<Policy> uniquePolicies;
   
    // LinkedHashSet equivalent (using LinkedList in C#) to maintain insertion order
    private LinkedList<Policy> orderedPolicies;
   
    // SortedSet for policies sorted by expiry date
    private SortedSet<Policy> sortedPolicies;
   
    // Dictionary to track duplicate policy numbers
    private Dictionary<string, List<Policy>> policyNumberLookup;

    public InsurancePolicyManagementSystem()
    {
        // Initialize collections
        uniquePolicies = new HashSet<Policy>();
        orderedPolicies = new LinkedList<Policy>();
        sortedPolicies = new SortedSet<Policy>();
        policyNumberLookup = new Dictionary<string, List<Policy>>();
    }

    // Add a policy to the system
    public void AddPolicy(Policy policy)
    {
        // Add to HashSet for unique storage
        bool isNew = uniquePolicies.Add(policy);
       
        // Add to LinkedList to maintain order
        orderedPolicies.AddLast(policy);
       
        // Add to SortedSet for sorting by expiry date
        sortedPolicies.Add(policy);
       
        // Track by policy number for duplicate detection
        if (!policyNumberLookup.ContainsKey(policy.PolicyNumber))
        {
            policyNumberLookup[policy.PolicyNumber] = new List<Policy>();
        }
        policyNumberLookup[policy.PolicyNumber].Add(policy);
       
        // Display appropriate message
        Console.WriteLine(isNew
            ? String.Format("Added new policy #{0}", policy.PolicyNumber)
            : String.Format("Policy #{0} already exists but tracked for duplicate analysis", policy.PolicyNumber));
    }

    // Get all unique policies
    public HashSet<Policy> GetAllUniquePolicies()
    {
        return uniquePolicies;
    }
   
    // Get policies expiring within the next 30 days
    public List<Policy> GetPoliciesExpiringSoon()
    {
        // Get current date for comparison
        DateTime today = DateTime.Today;
        DateTime thirtyDaysLater = today.AddDays(30);
       
        // Use LINQ to filter the sorted policies
        return sortedPolicies
            .Where(p => p.ExpiryDate >= today && p.ExpiryDate <= thirtyDaysLater)
            .ToList();
    }
   
    // Get policies by coverage type
    public List<Policy> GetPoliciesByCoverageType(string coverageType)
    {
        // Use LINQ to filter policies by coverage type
        return uniquePolicies
            .Where(p => p.CoverageType.Equals(coverageType, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
   
    // Get duplicate policies based on policy numbers
    public Dictionary<string, List<Policy>> GetDuplicatePolicies()
    {
        // Filter policy number lookup to only include entries with multiple policies
        return policyNumberLookup
            .Where(kvp => kvp.Value.Count > 1)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
   
    // Display all policies in insertion order
    public void DisplayPoliciesInInsertionOrder()
    {
        Console.WriteLine("\nPolicies in Insertion Order:");
        foreach (var policy in orderedPolicies)
        {
            Console.WriteLine(policy);
        }
    }
   
    // Display all policies sorted by expiry date
    public void DisplayPoliciesByExpiryDate()
    {
        Console.WriteLine("\nPolicies Sorted by Expiry Date:");
        foreach (var policy in sortedPolicies)
        {
            Console.WriteLine(policy);
        }
    }

    static void Main(string[] args)
    {
        // Create instance of insurance policy management system
        InsurancePolicyManagementSystem system = new InsurancePolicyManagementSystem();
       
        // Add sample policies for demonstration
        system.AddPolicy(new Policy {
            PolicyNumber = "P001",
            CustomerName = "John Smith",
            ExpiryDate = DateTime.Today.AddDays(15),
            CoverageType = "Auto",
            Premium = 1200.00m
        });
       
        system.AddPolicy(new Policy {
            PolicyNumber = "P002",
            CustomerName = "Jane Doe",
            ExpiryDate = DateTime.Today.AddDays(45),
            CoverageType = "Home",
            Premium = 950.50m
        });
       
        system.AddPolicy(new Policy {
            PolicyNumber = "P003",
            CustomerName = "Robert Johnson",
            ExpiryDate = DateTime.Today.AddDays(5),
            CoverageType = "Auto",
            Premium = 1450.75m
        });
       
        // Add a duplicate policy for demonstration
        system.AddPolicy(new Policy {
            PolicyNumber = "P001",
            CustomerName = "John Smith",
            ExpiryDate = DateTime.Today.AddDays(15),
            CoverageType = "Auto",
            Premium = 1200.00m
        });
       
        // Display policies in different orders
        system.DisplayPoliciesInInsertionOrder();
        system.DisplayPoliciesByExpiryDate();
       
        // Display policies expiring soon
        Console.WriteLine("\nPolicies Expiring Within 30 Days:");
        foreach (var policy in system.GetPoliciesExpiringSoon())
        {
            Console.WriteLine(policy);
        }
       
        // Display policies by coverage type
        Console.WriteLine("\nAuto Insurance Policies:");
        foreach (var policy in system.GetPoliciesByCoverageType("Auto"))
        {
            Console.WriteLine(policy);
        }
       
        // Display duplicate policies
        Console.WriteLine("\nDuplicate Policies:");
        var duplicates = system.GetDuplicatePolicies();
        foreach (var entry in duplicates)
        {
            Console.WriteLine(String.Format("Policy #{0} has {1} instances:", entry.Key, entry.Value.Count));
            foreach (var policy in entry.Value)
            {
                Console.WriteLine(String.Format("  - {0}, {1}", policy.CustomerName, policy.ExpiryDate.ToShortDateString()));
            }
        }
       
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
