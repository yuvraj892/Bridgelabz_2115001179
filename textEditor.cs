using System;

// Define a node class to store text state information
class TextStateNode
{
    // Text state attributes
    public string Content;
    public int StateID;
    public TextStateNode next;
    public TextStateNode prev;
    
    // Constructor to initialize a text state node
    public TextStateNode(string Content, int StateID)
    {
        this.Content = Content;
        this.StateID = StateID;
        this.next = null;
        this.prev = null;
    }
}

// Define the text editor class
class TextEditor
{
    private TextStateNode head;       // First state
    private TextStateNode current;    // Current state
    private TextStateNode tail;       // Last state
    private int stateCount;          // Total number of states
    private int maxStates;           // Maximum number of states to maintain
    private int currentStateID;      // Current state ID
    
    // Constructor to initialize text editor
    public TextEditor(int maxStates)
    {
        this.head = null;
        this.current = null;
        this.tail = null;
        this.stateCount = 0;
        this.maxStates = maxStates;
        this.currentStateID = 0;
        
        // Initialize with empty state
        AddState("");
    }
    
    // Method to add new text state
    public void AddState(string content)
    {
        currentStateID++;
        TextStateNode newState = new TextStateNode(content, currentStateID);
        
        // If this is the first state
        if (head == null)
        {
            head = newState;
            tail = newState;
            current = newState;
            stateCount = 1;
            return;
        }
        
        // Remove all states after current if we're adding after an undo
        if (current != tail)
        {
            RemoveStatesAfterCurrent();
        }
        
        // Add new state
        current.next = newState;
        newState.prev = current;
        current = newState;
        tail = newState;
        stateCount++;
        
        // Remove oldest state if exceeding maximum
        if (stateCount > maxStates)
        {
            head = head.next;
            head.prev = null;
            stateCount--;
        }
        
        Console.WriteLine("New state added with ID: " + currentStateID);
    }
    
    // Helper method to remove states after current state
    private void RemoveStatesAfterCurrent()
    {
        TextStateNode temp = current.next;
        while (temp != null)
        {
            TextStateNode next = temp.next;
            temp.prev = null;
            temp.next = null;
            temp = next;
            stateCount--;
        }
        current.next = null;
        tail = current;
    }
    
    // Method to perform undo operation
    public bool Undo()
    {
        if (current == head)
        {
            Console.WriteLine("Cannot undo: At oldest state");
            return false;
        }
        
        current = current.prev;
        Console.WriteLine("Undo successful. Current state ID: " + current.StateID);
        return true;
    }
    
    // Method to perform redo operation
    public bool Redo()
    {
        if (current == tail)
        {
            Console.WriteLine("Cannot redo: At newest state");
            return false;
        }
        
        current = current.next;
        Console.WriteLine("Redo successful. Current state ID: " + current.StateID);
        return true;
    }
    
    // Method to display current state
    public void DisplayCurrentState()
    {
        if (current == null)
        {
            Console.WriteLine("No current state");
            return;
        }
        
        Console.WriteLine("\nCurrent State (ID: " + current.StateID + "):");
        Console.WriteLine("Content: " + (current.Content.Length == 0 ? "[Empty]" : current.Content));
    }
    
    // Method to display all states
    public void DisplayAllStates()
    {
        if (head == null)
        {
            Console.WriteLine("No states available");
            return;
        }
        
        Console.WriteLine("\nAll States (Current State ID: " + current.StateID + "):");
        TextStateNode temp = head;
        while (temp != null)
        {
            Console.WriteLine("State " + temp.StateID + ": " + 
                            (temp == current ? "[CURRENT] " : "") +
                            (temp.Content.Length == 0 ? "[Empty]" : temp.Content));
            temp = temp.next;
        }
    }
    
    // Method to simulate typing text
    public void TypeText(string text)
    {
        string newContent = current.Content + text;
        AddState(newContent);
    }
    
    // Method to simulate deleting last character
    public void DeleteLastChar()
    {
        if (current.Content.Length > 0)
        {
            string newContent = current.Content.Substring(0, current.Content.Length - 1);
            AddState(newContent);
        }
    }
    
    // Main method to test the implementation
    public static void Main()
    {
        // Create text editor with maximum 10 states
        TextEditor editor = new TextEditor(10);
        
        // Simulate typing text
        Console.WriteLine("Typing 'Hello':");
        editor.TypeText("Hello");
        
        Console.WriteLine("\nTyping ' World':");
        editor.TypeText(" World");
        
        Console.WriteLine("\nTyping '!':");
        editor.TypeText("!");
        
        // Display all states
        editor.DisplayAllStates();
        
        // Perform undo operations
        Console.WriteLine("\nPerforming undo:");
        editor.Undo();
        editor.DisplayCurrentState();
        
        Console.WriteLine("\nPerforming another undo:");
        editor.Undo();
        editor.DisplayCurrentState();
        
        // Perform redo operation
        Console.WriteLine("\nPerforming redo:");
        editor.Redo();
        editor.DisplayCurrentState();
        
        // Type new text after undo
        Console.WriteLine("\nTyping '?':");
        editor.TypeText("?");
        editor.DisplayCurrentState();
        
        // Try to redo (should fail as we typed new text)
        Console.WriteLine("\nTrying to redo:");
        editor.Redo();
        
        // Delete last character
        Console.WriteLine("\nDeleting last character:");
        editor.DeleteLastChar();
        editor.DisplayCurrentState();
        
        // Display final state history
        editor.DisplayAllStates();
    }
}