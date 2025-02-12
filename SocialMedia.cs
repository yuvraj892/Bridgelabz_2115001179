using System;
using System.Collections.Generic;

// Define a node class to store friend information
class FriendNode
{
    public int UserID;
    public FriendNode next;
    
    public FriendNode(int UserID)
    {
        this.UserID = UserID;
        this.next = null;
    }
}

// Define a node class to store user information
class UserNode
{
    // User attributes
    public int UserID;
    public string Name;
    public int Age;
    public FriendNode friendList;  // Head of the friend list
    public UserNode next;
    
    // Constructor to initialize a user node
    public UserNode(int UserID, string Name, int Age)
    {
        this.UserID = UserID;
        this.Name = Name;
        this.Age = Age;
        this.friendList = null;
        this.next = null;
    }
}

// Define the social media connections manager class
class SocialMediaManager
{
    private UserNode head;
    
    // Constructor to initialize empty user list
    public SocialMediaManager()
    {
        head = null;
    }
    
    // Method to add new user
    public void AddUser(int UserID, string Name, int Age)
    {
        UserNode newUser = new UserNode(UserID, Name, Age);
        
        if (head == null)
        {
            head = newUser;
        }
        else
        {
            UserNode temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = newUser;
        }
        Console.WriteLine("User " + Name + " added successfully");
    }
    
    // Method to add friend connection between two users
    public void AddFriendConnection(int UserID1, int UserID2)
    {
        // Find both users
        UserNode user1 = FindUser(UserID1);
        UserNode user2 = FindUser(UserID2);
        
        if (user1 == null || user2 == null)
        {
            Console.WriteLine("One or both users not found");
            return;
        }
        
        // Check if already friends
        if (AreFriends(UserID1, UserID2))
        {
            Console.WriteLine("Users are already friends");
            return;
        }
        
        // Add friend connection for user1
        FriendNode friend1 = new FriendNode(UserID2);
        friend1.next = user1.friendList;
        user1.friendList = friend1;
        
        // Add friend connection for user2
        FriendNode friend2 = new FriendNode(UserID1);
        friend2.next = user2.friendList;
        user2.friendList = friend2;
        
        Console.WriteLine("Friend connection added between " + user1.Name + " and " + user2.Name);
    }
    
    // Method to remove friend connection between two users
    public void RemoveFriendConnection(int UserID1, int UserID2)
    {
        UserNode user1 = FindUser(UserID1);
        UserNode user2 = FindUser(UserID2);
        
        if (user1 == null || user2 == null)
        {
            Console.WriteLine("One or both users not found");
            return;
        }
        
        // Remove from user1's friend list
        RemoveFriend(user1, UserID2);
        
        // Remove from user2's friend list
        RemoveFriend(user2, UserID1);
        
        Console.WriteLine("Friend connection removed between " + user1.Name + " and " + user2.Name);
    }
    
    // Helper method to remove friend from a user's friend list
    private void RemoveFriend(UserNode user, int friendID)
    {
        FriendNode current = user.friendList;
        FriendNode prev = null;
        
        while (current != null && current.UserID != friendID)
        {
            prev = current;
            current = current.next;
        }
        
        if (current != null)
        {
            if (prev == null)
            {
                user.friendList = current.next;
            }
            else
            {
                prev.next = current.next;
            }
        }
    }
    
    // Method to find mutual friends between two users
    public void FindMutualFriends(int UserID1, int UserID2)
    {
        UserNode user1 = FindUser(UserID1);
        UserNode user2 = FindUser(UserID2);
        
        if (user1 == null || user2 == null)
        {
            Console.WriteLine("One or both users not found");
            return;
        }
        
        Console.WriteLine("\nMutual friends between " + user1.Name + " and " + user2.Name + ":");
        
        FriendNode friend1 = user1.friendList;
        List<int> mutualFriends = new List<int>();
        
        // Find mutual friends
        while (friend1 != null)
        {
            if (AreFriends(friend1.UserID, UserID2))
            {
                mutualFriends.Add(friend1.UserID);
            }
            friend1 = friend1.next;
        }
        
        // Display mutual friends
        if (mutualFriends.Count == 0)
        {
            Console.WriteLine("No mutual friends found");
        }
        else
        {
            foreach (int friendID in mutualFriends)
            {
                UserNode friend = FindUser(friendID);
                Console.WriteLine(friend.Name + " (ID: " + friend.UserID + ")");
            }
        }
    }
    
    // Method to display friends of a specific user
    public void DisplayFriends(int UserID)
    {
        UserNode user = FindUser(UserID);
        
        if (user == null)
        {
            Console.WriteLine("User not found");
            return;
        }
        
        Console.WriteLine("\nFriends of " + user.Name + ":");
        FriendNode friend = user.friendList;
        
        if (friend == null)
        {
            Console.WriteLine("No friends found");
            return;
        }
        
        while (friend != null)
        {
            UserNode friendUser = FindUser(friend.UserID);
            Console.WriteLine(friendUser.Name + " (ID: " + friendUser.UserID + ")");
            friend = friend.next;
        }
    }
    
    // Method to search user by ID
    public UserNode FindUser(int UserID)
    {
        UserNode temp = head;
        while (temp != null)
        {
            if (temp.UserID == UserID)
            {
                return temp;
            }
            temp = temp.next;
        }
        return null;
    }
    
    // Method to search user by name
    public void SearchByName(string Name)
    {
        UserNode temp = head;
        bool found = false;
        
        while (temp != null)
        {
            if (temp.Name.ToLower() == Name.ToLower())
            {
                DisplayUserInfo(temp);
                found = true;
            }
            temp = temp.next;
        }
        
        if (!found)
        {
            Console.WriteLine("No users found with name: " + Name);
        }
    }
    
    // Helper method to check if two users are friends
    private bool AreFriends(int UserID1, int UserID2)
    {
        UserNode user = FindUser(UserID1);
        if (user == null)
            return false;
            
        FriendNode friend = user.friendList;
        while (friend != null)
        {
            if (friend.UserID == UserID2)
                return true;
            friend = friend.next;
        }
        return false;
    }
    
    // Method to count friends for a user
    public int CountFriends(int UserID)
    {
        UserNode user = FindUser(UserID);
        if (user == null)
        {
            Console.WriteLine("User not found");
            return 0;
        }
        
        int count = 0;
        FriendNode friend = user.friendList;
        while (friend != null)
        {
            count++;
            friend = friend.next;
        }
        return count;
    }
    
    // Helper method to display user information
    private void DisplayUserInfo(UserNode user)
    {
        Console.WriteLine("User ID: " + user.UserID + 
                        ", Name: " + user.Name + 
                        ", Age: " + user.Age + 
                        ", Friends: " + CountFriends(user.UserID));
    }
    
    // Main method to test the implementation
    public static void Main()
    {
        SocialMediaManager socialMedia = new SocialMediaManager();
        
        // Add sample users
        socialMedia.AddUser(1, "John", 25);
        socialMedia.AddUser(2, "Alice", 28);
        socialMedia.AddUser(3, "Bob", 22);
        socialMedia.AddUser(4, "Emma", 30);
        
        // Add friend connections
        socialMedia.AddFriendConnection(1, 2);
        socialMedia.AddFriendConnection(1, 3);
        socialMedia.AddFriendConnection(2, 3);
        socialMedia.AddFriendConnection(4, 1);
        
        // Display friends for a user
        socialMedia.DisplayFriends(1);
        
        // Find mutual friends
        socialMedia.FindMutualFriends(1, 2);
        
        // Search for user
        Console.WriteLine("\nSearching for user 'Alice':");
        socialMedia.SearchByName("Alice");
        
        // Remove friend connection
        socialMedia.RemoveFriendConnection(1, 2);
        
        // Display updated friends list
        socialMedia.DisplayFriends(1);
    }
}