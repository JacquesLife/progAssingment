using System;
using System.Net;

namespace RecipeBook.Classes
{
    internal class IngridientsClass
    {
       public int NumberOfIngredients()
        {
            Console.WriteLine("How many ingredients are in your recipe?: ");
            int numberOfIngredients;
            while (!int.TryParse(Console.ReadLine(), out numberOfIngredients))
            {
                Console.WriteLine("Please enter a number: ");
            }
            Console.WriteLine("You have " + numberOfIngredients + " ingredients in your recipe.");
            Console.WriteLine();
            return numberOfIngredients;

        }

        public string IngredientName(int index)
        {
            Console.WriteLine("Enter the name of ingredient " + index + ": ");
            string? ingredient = Console.ReadLine();
            return ingredient ?? string.Empty;
        }

        public string Quantity(string ingredient)
        {
            while (true)
            {
                Console.WriteLine("Enter the quantity of " + ingredient + ": ");
                string quantity = Console.ReadLine() ?? string.Empty;
                if (double.TryParse(quantity, out double result))
                {
                    return quantity;
                }
                else
                {
                    Console.WriteLine("Please enter a number: ");
                }
            }
        }

        public string Unit(string ingredient)
        {
            Console.WriteLine("Enter the unit of measurement for " + ingredient + ": ");
            string? unit = Console.ReadLine();
            return unit ?? string.Empty;
        }

        public void NumberOfSteps() {

        }
        public void FullRecipe(string[] ingredients, string[] quantities, string[] units)
        {
        Console.WriteLine("Here is your recipe: ");
        Console.WriteLine();
        for (int i = 0; i < ingredients.Length; i++)
        {
        Console.WriteLine("Name: " + ingredients[i]);
        Console.WriteLine("Quantity: " + quantities[i]);
        Console.WriteLine("Unit: " + units[i]);
        Console.WriteLine(); 
        }
    }

        public bool ChooseToScaleRecipe()
        {
            // ask user if they want to scale the recipe
            Console.WriteLine("Would you like to scale the recipe? (yes/no): ");
            
            // input must be yes or no
            string? scaleRecipe;
            while (true)
            {
                scaleRecipe = Console.ReadLine();
                if (scaleRecipe == "yes" || scaleRecipe == "no")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter yes or no: ");
                }
            }
            return scaleRecipe == "yes";
        }
        public double ScaleFactor() {
        
        // ask user for scale factor
        Console.WriteLine("How much do you want to scale your recipe 2, 3 or 0.5: ");    
        double scaleFactor;

        // scale number must be 2, 3 or 0.5
        while (!double.TryParse(Console.ReadLine(), out scaleFactor) || (scaleFactor != 2 && scaleFactor != 3 && scaleFactor != 0.5)) {
            Console.WriteLine("Please enter 2, 3 or 0.5: ");
        }
        return scaleFactor;
        }

        public void ScaleRecipe(ref string[] quantities, double scaleFactor)
        {
            for (int i = 0; i < quantities.Length; i++)
            {
                if (double.TryParse(quantities[i], out double result))
                {
                    // scale the quantity by the scale factor 2, 3 or 0.5
                    quantities[i] = (result * scaleFactor).ToString();
                }
                else
                {
                    Console.WriteLine("Error: Quantity must be a number!");
                }
            }
        }
                
        public void ResetRecipe() {

        }
        public void ClearRecipe() {

        }
        
    }
}