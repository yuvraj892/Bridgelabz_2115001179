using System;

class MovieNode
{
    // Properties of a movie node
    public string MovieTitle;
    public string Director;
    public int YearOfRelease;
    public double Rating;
    public MovieNode next; 
    public MovieNode prev; 
    
    // Constructor to initialize a movie node
    public MovieNode(string MovieTitle, string Director, int YearOfRelease, double Rating)
    {
        this.MovieTitle = MovieTitle;
        this.Director = Director;
        this.YearOfRelease = YearOfRelease;
        this.Rating = Rating;
        next = null;
        prev = null;
    }
}

class Movie
{
    private MovieNode head; 
    
    // Constructor initializes an empty list
    public Movie()
    {
        head = null;
    }
    
    // Inserts a movie node at the beginning of the list
    public void InsertMovieBeginning(string MovieTitle, string Director, int YearOfRelease, double Rating)
    {
        MovieNode newMovie = new MovieNode(MovieTitle, Director, YearOfRelease, Rating);
        
        // If list is not empty, update previous head node
        if(head != null)
        {
            newMovie.next = head;
            head.prev = newMovie;
        }
        head = newMovie; 
    }
    
    // Deletes a movie node by title
    public void DeleteByTitle(string Title)
    {
        // If the list is empty, return
        if(head == null)
        {
            return;
        }
        
        MovieNode temp = head;

        // If the head node is the one to be deleted
        if (head.MovieTitle.ToLower() == Title)
        {
            head = head.next;
            if (head != null)
            {
                head.prev = null; 
            }
            Console.WriteLine("Movie with title '" + Title + "' deleted from the records.");
            return;
        }

        // Traverse the list to find the movie node to delete
        while (temp != null && temp.MovieTitle.ToLower() != Title)
        {
            temp = temp.next;
        }

        // If movie is not found, return
        if (temp == null)
        {
            Console.WriteLine("Movie not found.");
            return;
        }

        // Update pointers to remove the node
        if (temp.next != null)
        {
            temp.next.prev = temp.prev;
        }

        if (temp.prev != null)
        {
            temp.prev.next = temp.next;
        }

        Console.WriteLine("Movie with title '" + Title + "' deleted from the records.");
    }
    
    // Searches for a movie node by director or rating
    public MovieNode Search(string Director, double Rating)
    {
        MovieNode temp = head;
        
        // Traverse the list to find a match
        while(temp != null)
        {
            if(temp.Director == Director || temp.Rating == Rating)
            {
                return temp;
            }
            temp = temp.next;
        }
        return null; // Return null if no match found
    }
    
    // Updates the rating of a movie by title
    public void UpdateRating(string Title, double Rating)
    {
        MovieNode temp = head;
        
        // Traverse the list to find the movie
        while(temp != null)
        {
            if(temp.MovieTitle == Title)
            {
                temp.Rating = Rating; // Update rating
                Console.WriteLine("The rating of the movie " + Title + " has been upgraded to " + Rating + ".");
                return;
            }
            temp = temp.next;
        }
        
        Console.WriteLine("Movie not found");
    }
    
    // Displays the list in forward order
    public void DisplayFwd(){
        MovieNode temp = head;
        
        while(temp != null)
        {
            Console.WriteLine("Title: " + temp.MovieTitle + ", Director: " + temp.Director + ", Year of release: " + temp.YearOfRelease + ", Rating: " + temp.Rating);
            temp = temp.next;
        }
    }
    
    // Displays the list in reverse order
    public void DisplayRev()
    {
        if(head == null) return;
    
        MovieNode temp = head;
        while(temp.next != null)
        {
            temp = temp.next;
        }
    
        while(temp != null)
        {
            Console.WriteLine("Title: " + temp.MovieTitle + ", Director: " + temp.Director + ", Year of release: " + temp.YearOfRelease + ", Rating: " + temp.Rating);
            temp = temp.prev;
        }
    }
    
    public static void Main(string[] args)
    {
        Movie movie = new Movie();
        movie.InsertMovieBeginning("Fight Club", "David Fincher", 2006, 8.8);
        movie.InsertMovieBeginning("Inception", "Christopher Nolan", 2010, 8.8);
        movie.InsertMovieBeginning("The Dark Knight", "Christopher Nolan", 2008, 9.0);
        movie.InsertMovieBeginning("The Shawshank Redemption", "Frank Darabont", 1994, 9.3);
        movie.InsertMovieBeginning("Pulp Fiction", "Quentin Tarantino", 1994, 8.9);
        movie.InsertMovieBeginning("Forrest Gump", "Robert Zemeckis", 1994, 8.8);
        movie.InsertMovieBeginning("The Matrix", "The Wachowskis", 1999, 8.7);
        movie.InsertMovieBeginning("The Godfather", "Francis Ford Coppola", 1972, 9.2);
        movie.InsertMovieBeginning("Gladiator", "Ridley Scott", 2000, 8.5);

        movie.DisplayFwd();
        movie.DisplayRev();
        
        string Director = "";
        double Rating = 0;

        Console.WriteLine("Search by (1) Director or (2) Rating?: ");
        string choice = Console.ReadLine();
        if(choice == "1")
        {
            Console.WriteLine("Enter director name: ");
            Director = Console.ReadLine();
        } 
        else if(choice == "2")
        {
            Console.WriteLine("Enter rating: ");
            Rating = double.Parse(Console.ReadLine());
        }

        MovieNode foundMovie = movie.Search(Director, Rating);
        if(foundMovie != null)
        {
            Console.WriteLine("Found movie: " + foundMovie.MovieTitle);
        }
        else
        {
            Console.WriteLine("No movie found.");
        }
        
        Console.WriteLine("Enter the title of the movie that you want to delete: ");
        string Title = Console.ReadLine();
        movie.DeleteByTitle(Title);
        
        movie.DisplayFwd();
        movie.DisplayRev();
        
        Console.WriteLine("Enter the movie title that you want to upgrade the rating of: ");
        string ratingUpgrade = Console.ReadLine();
        Console.WriteLine("Enter the rating that you want to upgrade to: ");
        double upgradedRating = double.Parse(Console.ReadLine());
        movie.UpdateRating(ratingUpgrade, upgradedRating);
        
        movie.DisplayFwd();
        movie.DisplayRev();
    }
}
