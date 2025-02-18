using System;
using System.Collections.Generic;


public interface IMealPlan
{
    string MealName { get; set; }
    List<string> Ingredients { get; set; }
    void DisplayMealPlan();
}

// Vegetarian meal class implementing IMealPlan
public class VegetarianMeal : IMealPlan
{
    public string MealName { get; set; }
    public List<string> Ingredients { get; set; }

    public VegetarianMeal(string name, List<string> ingredients)
    {
        MealName = name;
        Ingredients = ingredients;
    }

    public void DisplayMealPlan()
    {
        Console.WriteLine("Vegetarian Meal: " + MealName);
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in Ingredients)
        {
            Console.WriteLine("- " + ingredient);
        }
    }
}

// Vegan meal class implementing IMealPlan
public class VeganMeal : IMealPlan
{
    public string MealName { get; set; }
    public List<string> Ingredients { get; set; }

    public VeganMeal(string name, List<string> ingredients)
    {
        MealName = name;
        Ingredients = ingredients;
    }

    public void DisplayMealPlan()
    {
        Console.WriteLine("Vegan Meal: " + MealName);
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in Ingredients)
        {
            Console.WriteLine("- " + ingredient);
        }
    }
}

// Keto meal class implementing IMealPlan
public class KetoMeal : IMealPlan
{
    public string MealName { get; set; }
    public List<string> Ingredients { get; set; }

    public KetoMeal(string name, List<string> ingredients)
    {
        MealName = name;
        Ingredients = ingredients;
    }

    public void DisplayMealPlan()
    {
        Console.WriteLine("Keto Meal: " + MealName);
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in Ingredients)
        {
            Console.WriteLine("- " + ingredient);
        }
    }
}

// High-protein meal class implementing IMealPlan
public class HighProteinMeal : IMealPlan
{
    public string MealName { get; set; }
    public List<string> Ingredients { get; set; }

    public HighProteinMeal(string name, List<string> ingredients)
    {
        MealName = name;
        Ingredients = ingredients;
    }

    public void DisplayMealPlan()
    {
        Console.WriteLine("High-Protein Meal: " + MealName);
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in Ingredients)
        {
            Console.WriteLine("- " + ingredient);
        }
    }
}

public class Meal<T> where T : IMealPlan
{
    private List<T> meals = new List<T>();  

    // Method to add a meal
    public void AddMeal(T meal)
    {
        if (meal != null)
        {
            meals.Add(meal);
            Console.WriteLine("Meal '" + meal.MealName + "' added successfully.");
        }
        else
        {
            Console.WriteLine("Invalid meal. Cannot add.");
        }
    }

    // Method to remove a meal by its name
    public void RemoveMeal(string mealName)
    {
        var mealToRemove = meals.Find(meal => meal.MealName.Equals(mealName, StringComparison.OrdinalIgnoreCase));
        if (mealToRemove != null)
        {
            meals.Remove(mealToRemove);
            Console.WriteLine("Meal '" + mealName + "' removed successfully.");
        }
        else
        {
            Console.WriteLine("Meal '" + mealName + "' not found.");
        }
    }

    // Generic method to validate meal plans based on dietary constraints
    public bool ValidateMeal(T meal)
    {
        // Example validation: Ensure no meat in Vegan meals
        if (meal is VeganMeal && meal.Ingredients.Exists(ingredient => ingredient.Contains("meat", StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Validation failed: Vegan meal cannot contain meat.");
            return false;
        }
        return true;
    }

    // Method to display all meals
    public void DisplayAllMeals()
    {
        foreach (var meal in meals)
        {
            meal.DisplayMealPlan();
            Console.WriteLine();  
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create some sample meals
        var vegMeal = new VegetarianMeal("Vegetarian Pasta", new List<string> { "Pasta", "Tomato", "Cheese", "Olives" });
        var veganMeal = new VeganMeal("Vegan Salad", new List<string> { "Lettuce", "Tomato", "Cucumber", "Avocado" });
        var ketoMeal = new KetoMeal("Keto Chicken Salad", new List<string> { "Chicken", "Lettuce", "Cheese", "Olive Oil" });
        var highProteinMeal = new HighProteinMeal("High-Protein Omelette", new List<string> { "Eggs", "Cheese", "Spinach", "Peppers" });

        // Create a Meal object that can manage all meal types
        var mealManager = new Meal<IMealPlan>();

        // Add meals to the system
        mealManager.AddMeal(vegMeal);
        mealManager.AddMeal(veganMeal);
        mealManager.AddMeal(ketoMeal);
        mealManager.AddMeal(highProteinMeal);

        // Display all meals
        Console.WriteLine("All Meal Plans:");
        mealManager.DisplayAllMeals();

        // Remove a meal by name
        mealManager.RemoveMeal("Vegan Salad");

        // Validate a specific meal (e.g., VeganMeal)
        Console.WriteLine("Validating Vegan Meal...");
        mealManager.ValidateMeal(veganMeal); 
    }
}
