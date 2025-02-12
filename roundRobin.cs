using System;
using System.Collections.Generic;

// Define a node class to store process information
class ProcessNode
{
    // Process attributes
    public int ProcessID;
    public int BurstTime;
    public int RemainingTime;
    public int Priority;
    public int WaitingTime;
    public int TurnaroundTime;
    public ProcessNode next;
    
    // Constructor to initialize a process node
    public ProcessNode(int ProcessID, int BurstTime, int Priority)
    {
        this.ProcessID = ProcessID;
        this.BurstTime = BurstTime;
        this.RemainingTime = BurstTime;
        this.Priority = Priority;
        this.WaitingTime = 0;
        this.TurnaroundTime = 0;
        this.next = null;
    }
}

// Define the round robin scheduler class
class RoundRobinScheduler
{
    private ProcessNode head;
    private int timeQuantum;
    private int totalProcesses;
    private List<ProcessNode> completedProcesses;
    
    // Constructor to initialize scheduler
    public RoundRobinScheduler(int timeQuantum)
    {
        this.head = null;
        this.timeQuantum = timeQuantum;
        this.totalProcesses = 0;
        this.completedProcesses = new List<ProcessNode>();
    }
    
    // Method to add new process to circular queue
    public void AddProcess(int ProcessID, int BurstTime, int Priority)
    {
        ProcessNode newProcess = new ProcessNode(ProcessID, BurstTime, Priority);
        
        if (head == null)
        {
            head = newProcess;
            head.next = head;  // Point to itself to create circular link
        }
        else
        {
            ProcessNode temp = head;
            while (temp.next != head)
            {
                temp = temp.next;
            }
            temp.next = newProcess;
            newProcess.next = head;
        }
        
        totalProcesses++;
        Console.WriteLine("Process " + ProcessID + " added successfully");
    }
    
    // Method to remove process by ID
    public void RemoveProcess(int ProcessID)
    {
        if (head == null)
        {
            Console.WriteLine("No processes in queue");
            return;
        }
        
        ProcessNode current = head;
        ProcessNode prev = null;
        
        // Find the process to remove
        do
        {
            if (current.ProcessID == ProcessID)
            {
                // If only one process exists
                if (current.next == head && current == head)
                {
                    head = null;
                }
                // If process is at head
                else if (current == head)
                {
                    ProcessNode temp = head;
                    while (temp.next != head)
                    {
                        temp = temp.next;
                    }
                    head = head.next;
                    temp.next = head;
                }
                // If process is in middle or end
                else
                {
                    prev.next = current.next;
                }
                
                totalProcesses--;
                Console.WriteLine("Process " + ProcessID + " removed successfully");
                return;
            }
            prev = current;
            current = current.next;
        } while (current != head);
        
        Console.WriteLine("Process not found");
    }
    
    // Method to simulate round robin scheduling
    public void SimulateRoundRobin()
    {
        if (head == null)
        {
            Console.WriteLine("No processes to schedule");
            return;
        }
        
        int currentTime = 0;
        ProcessNode current = head;
        
        Console.WriteLine("\nStarting Round Robin Scheduling with Time Quantum: " + timeQuantum);
        
        while (totalProcesses > 0)
        {
            // Execute current process for time quantum or remaining time
            int executeTime = Math.Min(timeQuantum, current.RemainingTime);
            current.RemainingTime -= executeTime;
            currentTime += executeTime;
            
            Console.WriteLine("\nTime " + (currentTime - executeTime) + " to " + currentTime + 
                            ": Executing Process " + current.ProcessID);
            
            // Update waiting times for all other processes
            ProcessNode temp = current.next;
            while (temp != current)
            {
                temp.WaitingTime += executeTime;
                temp = temp.next;
                if (temp == head)
                    break;
            }
            
            // If process is completed
            if (current.RemainingTime == 0)
            {
                current.TurnaroundTime = currentTime;
                completedProcesses.Add(current);
                
                // Remove completed process
                RemoveProcess(current.ProcessID);
                
                if (head == null)
                    break;
                
                current = head;
            }
            else
            {
                current = current.next;
                if (current == null || totalProcesses == 1)
                    current = head;
            }
            
            // Display queue after this round
            DisplayQueue();
        }
        
        // Display final statistics
        DisplayStatistics();
    }
    
    // Method to display current queue
    public void DisplayQueue()
    {
        if (head == null)
        {
            Console.WriteLine("Queue is empty");
            return;
        }
        
        Console.WriteLine("\nCurrent Queue Status:");
        ProcessNode temp = head;
        do
        {
            Console.WriteLine("Process " + temp.ProcessID + 
                            " - Remaining Time: " + temp.RemainingTime + 
                            ", Priority: " + temp.Priority);
            temp = temp.next;
        } while (temp != head);
    }
    
    // Method to display statistics
    private void DisplayStatistics()
    {
        if (completedProcesses.Count == 0)
        {
            Console.WriteLine("No processes completed yet");
            return;
        }
        
        double totalWaitingTime = 0;
        double totalTurnaroundTime = 0;
        
        Console.WriteLine("\nProcess Statistics:");
        foreach (ProcessNode process in completedProcesses)
        {
            Console.WriteLine("Process " + process.ProcessID + 
                            " - Waiting Time: " + process.WaitingTime + 
                            ", Turnaround Time: " + process.TurnaroundTime);
            
            totalWaitingTime += process.WaitingTime;
            totalTurnaroundTime += process.TurnaroundTime;
        }
        
        double avgWaitingTime = totalWaitingTime / completedProcesses.Count;
        double avgTurnaroundTime = totalTurnaroundTime / completedProcesses.Count;
        
        Console.WriteLine("\nAverage Waiting Time: " + avgWaitingTime.ToString("F2"));
        Console.WriteLine("Average Turnaround Time: " + avgTurnaroundTime.ToString("F2"));
    }
    
    // Main method to test the implementation
    public static void Main()
    {
        // Create scheduler with time quantum of 4
        RoundRobinScheduler scheduler = new RoundRobinScheduler(4);
        
        // Add sample processes
        scheduler.AddProcess(1, 10, 2);
        scheduler.AddProcess(2, 5, 1);
        scheduler.AddProcess(3, 8, 3);
        
        // Display initial queue
        scheduler.DisplayQueue();
        
        // Start simulation
        scheduler.SimulateRoundRobin();
    }
}