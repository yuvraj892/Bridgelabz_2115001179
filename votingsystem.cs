using System;
using System.Collections.Generic;
using System.Linq;

class VotingSystem
{
    // Dictionary to store candidate votes
    private Dictionary<string, int> votes;
   
    // SortedDictionary to display results in sorted order
    private SortedDictionary<string, int> sortedVotes;
   
    // LinkedDictionary equivalent to maintain order of votes
    private LinkedList<KeyValuePair<string, int>> orderedVotes;

    public VotingSystem()
    {
        // Initialize collections
        votes = new Dictionary<string, int>();
        sortedVotes = new SortedDictionary<string, int>();
        orderedVotes = new LinkedList<KeyValuePair<string, int>>();
    }

    // Cast a vote for a candidate
    public void CastVote(string candidate)
    {
        // Check if the candidate already has votes
        if (votes.ContainsKey(candidate))
        {
            // Increment vote count
            votes[candidate]++;
        }
        else
        {
            // Add new candidate with initial vote
            votes[candidate] = 1;
           
            // Add to ordered votes for tracking order of first votes
            orderedVotes.AddLast(new KeyValuePair<string, int>(candidate, 1));
        }
       
        // Update sorted votes
        UpdateSortedVotes();
       
        Console.WriteLine(String.Format("Vote recorded for {0}. Current total: {1}",
            candidate, votes[candidate]));
    }

    // Update the sorted votes collection
    private void UpdateSortedVotes()
    {
        // Clear and rebuild sorted dictionary
        sortedVotes.Clear();
        foreach (var entry in votes)
        {
            sortedVotes.Add(entry.Key, entry.Value);
        }
    }

    // Get current vote counts
    public Dictionary<string, int> GetVoteCounts()
    {
        return new Dictionary<string, int>(votes);
    }

    // Get the winner(s) of the election
    public List<string> GetWinners()
    {
        // Check if any votes have been cast
        if (votes.Count == 0)
        {
            return new List<string>();
        }
       
        // Find the maximum number of votes
        int maxVotes = votes.Values.Max();
       
        // Return all candidates with the maximum number of votes
        return votes
            .Where(kvp => kvp.Value == maxVotes)
            .Select(kvp => kvp.Key)
            .ToList();
    }

    // Display results in alphabetical order
    public void DisplayResultsAlphabetically()
    {
        Console.WriteLine("\nElection Results (Alphabetical Order):");
        foreach (var entry in sortedVotes)
        {
            Console.WriteLine(String.Format("{0}: {1} vote(s)", entry.Key, entry.Value));
        }
    }

    // Display results in order of first vote
    public void DisplayResultsByFirstVote()
    {
        Console.WriteLine("\nElection Results (Order of First Vote):");
        foreach (var initialEntry in orderedVotes)
        {
            string candidate = initialEntry.Key;
            Console.WriteLine(String.Format("{0}: {1} vote(s)", candidate, votes[candidate]));
        }
    }

    // Display results in order of vote count (descending)
    public void DisplayResultsByVoteCount()
    {
        Console.WriteLine("\nElection Results (By Vote Count, Descending):");
        foreach (var entry in votes.OrderByDescending(v => v.Value))
        {
            Console.WriteLine(String.Format("{0}: {1} vote(s)", entry.Key, entry.Value));
        }
    }

    static void Main(string[] args)
    {
        // Create instance of voting system
        VotingSystem votingSystem = new VotingSystem();
       
        // Simulate voting process
        Console.WriteLine("Welcome to the Voting System!");
        Console.WriteLine("Simulating votes being cast...\n");
       
        // Cast sample votes
        votingSystem.CastVote("Alice Johnson");
        votingSystem.CastVote("Bob Smith");
        votingSystem.CastVote("Alice Johnson");
        votingSystem.CastVote("Charlie Davis");
        votingSystem.CastVote("Bob Smith");
        votingSystem.CastVote("Alice Johnson");
        votingSystem.CastVote("Diana Miller");
        votingSystem.CastVote("Bob Smith");
        votingSystem.CastVote("Charlie Davis");
        votingSystem.CastVote("Alice Johnson");
       
        // Display results in different orders
        votingSystem.DisplayResultsAlphabetically();
        votingSystem.DisplayResultsByFirstVote();
        votingSystem.DisplayResultsByVoteCount();
       
        // Display winners
        List<string> winners = votingSystem.GetWinners();
       
        Console.WriteLine("\nElection Results:");
        if (winners.Count == 1)
        {
            // Single winner
            Console.WriteLine(String.Format("The winner is {0} with {1} votes!",
                winners[0], votingSystem.GetVoteCounts()[winners[0]]));
        }
        else
        {
            // Tie situation
            Console.WriteLine(String.Format("We have a tie! The following candidates each received {0} votes:",
                votingSystem.GetVoteCounts()[winners[0]]));
           
            foreach (string winner in winners)
            {
                Console.WriteLine(String.Format("- {0}", winner));
            }
        }
       
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
