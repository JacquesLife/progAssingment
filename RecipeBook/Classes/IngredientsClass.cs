using System;
using System.Net;
using System.IO; 

namespace RecipeBook.Classes 
{
    internal class IngredientsClass
    {
        private string[]? originalQuantities;
//---------------------------------------------------------------------------------------------------------------------------------
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
//---------------------------------------------------------------------------------------------------------------------------------
        public string IngredientName(int index)
        {
            Console.WriteLine("Enter the name of ingredient " + index + ": ");
            string? ingredient = Console.ReadLine();
            return ingredient ?? string.Empty;
        }
//---------------------------------------------------------------------------------------------------------------------------------
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
//---------------------------------------------------------------------------------------------------------------------------------
        public string Unit(string ingredient)
        {
            Console.WriteLine("Enter the unit of measurement for " + ingredient + ": ");
            string? unit = Console.ReadLine();
            return unit ?? string.Empty;
        }
//---------------------------------------------------------------------------------------------------------------------------------
        public int NumberOfSteps()
        {
            Console.WriteLine("How many steps are in your recipe?: ");
            int numberOfSteps;
            while (!int.TryParse(Console.ReadLine(), out numberOfSteps) || numberOfSteps <= 0)
            {
                Console.WriteLine("Please enter a number greater than 0: ");
            }
            return numberOfSteps;
        }
//---------------------------------------------------------------------------------------------------------------------------------
        public string[] StepDescription(int numberOfSteps)
        {
            string[] steps = new string[numberOfSteps];
            for (int i = 0; i < numberOfSteps; i++)
            {
                // ask user for step description
                Console.WriteLine($"Enter a description for step {i + 1}: ");
                steps[i] = Console.ReadLine() ?? string.Empty;
            }
            return steps;
        }
//---------------------------------------------------------------------------------------------------------------------------------

        public string ValidateDescription(string description)
        {
            while (string.IsNullOrEmpty(description))
            {
                Console.WriteLine("Description cannot be empty. Please enter a description: ");
                description = Console.ReadLine() ?? string.Empty;
            }
            return description;
        }
//---------------------------------------------------------------------------------------------------------------------------------
        public static void FullRecipe(string[] ingredients, string[] quantities, string[] units, int numberOfSteps, string[] stepDescription)
        {
            Console.WriteLine();

            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine("Name: " + ingredients[i]);
                Console.WriteLine("Quantity: " + quantities[i]);
                Console.WriteLine("Unit: " + units[i]);
                Console.WriteLine();
            }
            Console.WriteLine("Number of steps: " + numberOfSteps);
            Console.WriteLine();
            for (int i = 0; i < numberOfSteps; i++)
            {
                Console.WriteLine("Step " + (i + 1) + ": " + stepDescription[i]);
            }
        }
//---------------------------------------------------------------------------------------------------------------------------------
        public static void OriginalRecipe(string[] ingredients, string[] quantities, string[] units)
        {
            Console.WriteLine("Here is your original recipe: ");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine("Name: " + ingredients[i]);
                Console.WriteLine("Quantity: " + quantities[i]);
                Console.WriteLine("Unit: " + units[i]);
                Console.WriteLine();
            }
        }
//---------------------------------------------------------------------------------------------------------------------------------
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
//---------------------------------------------------------------------------------------------------------------------------------
        public double ScaleFactor() 
        {
        // ask user for scale factor
        Console.WriteLine("How much do you want to scale your recipe 2, 3 or 0.5: ");    
        double scaleFactor;

        // scale number must be 2, 3 or 0.5
        while (!double.TryParse(Console.ReadLine(), out scaleFactor) || (scaleFactor != 2 && scaleFactor != 3 && scaleFactor != 0.5)) 
        {
            Console.WriteLine("Please enter 2, 3 or 0.5: ");
        }
        return scaleFactor;
        }
//---------------------------------------------------------------------------------------------------------------------------------

        public void AdjustQuantites(ref string[] quantities, double scaleFactor)
        {
            //store quantities before scaling
            originalQuantities = (string[])quantities.Clone();

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
//---------------------------------------------------------------------------------------------------------------------------------

        public void ScaledRecipe(string[] quantities, string[] units, string[] ingredients)
        {
            //scaled Recipe 
            Console.WriteLine("Here is your scaled recipe: ");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine("Name: " + ingredients[i]);
                Console.WriteLine("Quantity: " + quantities[i]);
                Console.WriteLine("Unit: " + units[i]);
                Console.WriteLine();
            }
        }
//---------------------------------------------------------------------------------------------------------------------------------
                
        public void ResetRecipe(string[] quantities, string[] units, string[] ingredients)
        {
            // reset the recipe to the original quantities
            Console.WriteLine("Would you like to reset the recipe to the original quantities? (yes/no): ");
            string? resetRecipe;

            while (true)
            {
                resetRecipe = Console.ReadLine();
                if (resetRecipe == "yes")
                {
                    // reset the quantities to the original quantities and ensure that the original quantities are not null
                    quantities = (string[])(originalQuantities?.Clone() ?? Array.Empty<string>());
                    OriginalRecipe(ingredients, quantities, units);
                    break;
                }
                else if (resetRecipe == "no")
                {
                    ScaledRecipe(quantities, units, ingredients);
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter yes or no: ");
                }
            }
        }
//---------------------------------------------------------------------------------------------------------------------------------
        public void EnterNewRecipe()
        {
            Console.WriteLine("Would you like to enter a new recipe? (yes/no): ");
            string? newRecipe;

            while (true)
            {
                newRecipe = Console.ReadLine();
                if (newRecipe == "yes")
                {
                    Console.WriteLine();
                    break;
                }
                else if (newRecipe == "no")
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please enter yes or no: ");
                }
            }
        }
//---------------------------------------------------------------------------------------------------------------------------------
    }
}