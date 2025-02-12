using System;

class TaskNode
{
    // Properties of a task node
    public long TaskId;
    public string TaskName;
    public int Priority;
    public DateTime DueDate;
    public TaskNode next; // Pointer to the next node in the circular linked list
    
    // Constructor to initialize a task node
    public TaskNode(long TaskId, string TaskName, int Priority, DateTime DueDate)
    {
        this.TaskId = TaskId;
        this.TaskName = TaskName;
        this.Priority = Priority;
        this.DueDate = DueDate;
        next = null; 
    }
}

class Task
{
    private TaskNode head; // Head pointer for the circular linked list
    
    // Constructor initializes an empty list
    public Task()
    {
        head = null;
    }
    
    // Inserts a task node at the beginning of the list
    public void InsertTaskBeginning(long taskId, string taskName, int priority, DateTime dueDate)
    {
        TaskNode newTask = new TaskNode(taskId, taskName, priority, dueDate);
        
        // If list is empty, set the new task to point to itself
        if (head == null)
        {
            newTask.next = newTask;
            head = newTask;
        }
        else
        {
            TaskNode temp = head;
            while (temp.next != head) 
            {
                temp = temp.next;
            }
            temp.next = newTask; 
            newTask.next = head; 
            head = newTask; 
        }
    }
    
    // Deletes a task node by task ID
    public void DeleteTask(long taskId)
    {
        // If the list is empty, return
        if (head == null)
        {
            Console.WriteLine("No tasks to delete.");
            return;
        }

        TaskNode temp = head;
        TaskNode prev = null;

        // If the head node is the one to be deleted and it's the only node
        if (head.TaskId == taskId && head.next == head)
        {
            head = null;
            Console.WriteLine("Task with TaskID " + taskId + " has been deleted.");
            return;
        }

        // If the head node is the one to be deleted
        if (head.TaskId == taskId)
        {
            while (temp.next != head) 
            {
                temp = temp.next;
            }
            temp.next = head.next; 
            head = head.next; 
            Console.WriteLine("Task with TaskID " + taskId + " has been deleted.");
            return;
        }

        // Traverse the list to find the task node to delete
        prev = head;
        temp = head.next;
        while (temp != head) 
        {
            if (temp.TaskId == taskId)
            {
                prev.next = temp.next;
                Console.WriteLine("Task with TaskID " + taskId + " has been deleted.");
                return;
            }
            prev = temp;
            temp = temp.next;
        }

        // If task is not found, return
        Console.WriteLine("Task with TaskID " + taskId + " not found.");
    }
    
    // Searches for a task node by priority
    public TaskNode Search(int priority)
    {
        // If the list is empty, return
        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return null;
        }

        TaskNode temp = head;
        do
        {
            if (temp.Priority == priority)
            {
                return temp; 
            }
            temp = temp.next;
        } while (temp != head);

        Console.WriteLine("No task found with priority " + priority);
        return null;
    }

    // Displays the list in circular order
    public void Display()
    {
        // If the list is empty, return
        if (head == null)
        {
            Console.WriteLine("No tasks in the list.");
            return;
        }

        TaskNode temp = head;
        do
        {
            Console.WriteLine("TaskID: " + temp.TaskId + ", Task Name: " + temp.TaskName + ", Priority: " + temp.Priority + ", Due Date: " + temp.DueDate);
            temp = temp.next;
        } while (temp != head);
    }

    public static void Main(string[] args)
    {
        Task taskList = new Task();

        // Insert sample tasks into the list
        taskList.InsertTaskBeginning(12345, "Drink Water", 3, DateTime.Now.AddHours(2));
        taskList.InsertTaskBeginning(12346, "Complete Assignment", 1, DateTime.Now.AddDays(1));
        taskList.InsertTaskBeginning(12347, "Go for a Walk", 2, DateTime.Now.AddMinutes(30));
        taskList.InsertTaskBeginning(12348, "Read a Book", 2, DateTime.Now.AddDays(2));

        taskList.Display();
    
        Console.Write("\nEnter priority to search for a task: ");
        int priority = int.Parse(Console.ReadLine());

        TaskNode foundTask = taskList.Search(priority);
        if (foundTask != null)
        {
            Console.WriteLine("\nTask Found:");
            Console.WriteLine("TaskID: " + foundTask.TaskId + ", Task Name: " + foundTask.TaskName + ", Priority: " + foundTask.Priority + ", Due Date: " + foundTask.DueDate);
        }

        Console.WriteLine("Enter the taskID for the task to be deleted: ");
        int taskId = int.Parse(Console.ReadLine());
        taskList.DeleteTask(taskId);
    
        taskList.Display();
    }
}
