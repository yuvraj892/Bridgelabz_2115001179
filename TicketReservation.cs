using System;

// Define a node class to store ticket information
class TicketNode
{
    // Ticket attributes
    public string TicketID;
    public string CustomerName;
    public string MovieName;
    public string SeatNumber;
    public DateTime BookingTime;
    public TicketNode next;
    
    // Constructor to initialize a ticket node
    public TicketNode(string TicketID, string CustomerName, string MovieName, string SeatNumber)
    {
        this.TicketID = TicketID;
        this.CustomerName = CustomerName;
        this.MovieName = MovieName;
        this.SeatNumber = SeatNumber;
        this.BookingTime = DateTime.Now;
        this.next = null;
    }
}

// Define the ticket reservation system class
class TicketReservationSystem
{
    private TicketNode head;
    private int totalTickets;
    
    // Constructor to initialize empty reservation system
    public TicketReservationSystem()
    {
        head = null;
        totalTickets = 0;
    }
    
    // Method to generate unique ticket ID
    private string GenerateTicketID()
    {
        return "TKT" + (totalTickets + 1).ToString("D4");
    }
    
    // Method to add new ticket reservation
    public void AddReservation(string CustomerName, string MovieName, string SeatNumber)
    {
        string ticketID = GenerateTicketID();
        TicketNode newTicket = new TicketNode(ticketID, CustomerName, MovieName, SeatNumber);
        
        if (head == null)
        {
            head = newTicket;
            head.next = head;  // Point to itself to create circular link
        }
        else
        {
            TicketNode temp = head;
            while (temp.next != head)
            {
                temp = temp.next;
            }
            temp.next = newTicket;
            newTicket.next = head;
        }
        
        totalTickets++;
        Console.WriteLine("Ticket " + ticketID + " booked successfully for " + CustomerName);
    }
    
    // Method to remove ticket by ID
    public void RemoveTicket(string TicketID)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets in system");
            return;
        }
        
        TicketNode current = head;
        TicketNode prev = null;
        
        // Find the ticket to remove
        do
        {
            if (current.TicketID == TicketID)
            {
                // If only one ticket exists
                if (current.next == head && current == head)
                {
                    head = null;
                }
                // If ticket is at head
                else if (current == head)
                {
                    TicketNode temp = head;
                    while (temp.next != head)
                    {
                        temp = temp.next;
                    }
                    head = head.next;
                    temp.next = head;
                }
                // If ticket is in middle or end
                else
                {
                    prev.next = current.next;
                }
                
                totalTickets--;
                Console.WriteLine("Ticket " + TicketID + " cancelled successfully");
                return;
            }
            prev = current;
            current = current.next;
        } while (current != head);
        
        Console.WriteLine("Ticket not found");
    }
    
    // Method to search tickets by customer name
    public void SearchByCustomer(string CustomerName)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets in system");
            return;
        }
        
        Console.WriteLine("\nTickets booked by " + CustomerName + ":");
        bool found = false;
        TicketNode temp = head;
        
        do
        {
            if (temp.CustomerName.ToLower() == CustomerName.ToLower())
            {
                DisplayTicket(temp);
                found = true;
            }
            temp = temp.next;
        } while (temp != head);
        
        if (!found)
        {
            Console.WriteLine("No tickets found for " + CustomerName);
        }
    }
    
    // Method to search tickets by movie name
    public void SearchByMovie(string MovieName)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets in system");
            return;
        }
        
        Console.WriteLine("\nTickets booked for movie " + MovieName + ":");
        bool found = false;
        TicketNode temp = head;
        
        do
        {
            if (temp.MovieName.ToLower() == MovieName.ToLower())
            {
                DisplayTicket(temp);
                found = true;
            }
            temp = temp.next;
        } while (temp != head);
        
        if (!found)
        {
            Console.WriteLine("No tickets found for movie " + MovieName);
        }
    }
    
    // Method to display all current tickets
    public void DisplayAllTickets()
    {
        if (head == null)
        {
            Console.WriteLine("No tickets in system");
            return;
        }
        
        Console.WriteLine("\nCurrent Tickets:");
        TicketNode temp = head;
        
        do
        {
            DisplayTicket(temp);
            temp = temp.next;
        } while (temp != head);
        
        Console.WriteLine("\nTotal tickets: " + totalTickets);
    }
    
    // Helper method to display a single ticket
    private void DisplayTicket(TicketNode ticket)
    {
        Console.WriteLine("Ticket ID: " + ticket.TicketID + 
                        ", Customer: " + ticket.CustomerName + 
                        ", Movie: " + ticket.MovieName + 
                        ", Seat: " + ticket.SeatNumber + 
                        ", Booked: " + ticket.BookingTime.ToString("g"));
    }
    
    // Method to get total number of tickets
    public int GetTotalTickets()
    {
        return totalTickets;
    }
    
    // Main method to test the implementation
    public static void Main()
    {
        TicketReservationSystem reservationSystem = new TicketReservationSystem();
        
        // Add sample reservations
 AvengersreservationSystem.AddReservation("Krati", "Avengers", "A1");
        reservationSystem.AddReservation("Rishabh", "Logan", "B3");
        reservationSystem.AddReservation("Yuvraj", "Logan", "B4");
        
        // Display all tickets
        reservationSystem.DisplayAllTickets();
        
        // Search by customer name
        Console.WriteLine("\nSearching tickets for Krati:");
        reservationSystem.SearchByCustomer("Krati");
        
        // Search by movie name
        Console.WriteLine("\nSearching tickets for Avengers:");
        reservationSystem.SearchByMovie("Avengers");
        
        // Cancel a ticket
        Console.WriteLine("\nCancelling ticket TKT0002:");
        reservationSystem.RemoveTicket("TKT0002");
        
        // Display updated tickets
        reservationSystem.DisplayAllTickets();
    }
}