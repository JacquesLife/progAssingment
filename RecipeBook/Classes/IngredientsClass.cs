/// <summary>
/// Name: Jacques du Plessis
/// Student: ST10329686
/// Module: PROG6221
/// </summary>
/// This class is responsible for getting the number of ingredients, 
/// the name of each ingredient, the quantity of each ingredient, the unit of each ingredient, 
/// the number of steps, and the description of each step from the user.
/// References:
/// https://learn.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=net-8.0
/// https://www.tutorialsteacher.com/csharp/csharp-ternary-operator
/// https://www.youtube.com/watch?v=5VvAcoBJGJs
/// https://www.geeksforgeeks.org/c-sharp-arrays/
/// https://stackoverflow.com/questions/169217/c-sharp-equivalent-of-the-isnull-function-in-sql-server
/// 



using System;
using System.Net;
using System.IO; 

namespace RecipeBook.Classes 
{
    internal class IngredientsClass
    {
//---------------------------------------------------------------------------------------------------------------------------------
       public int NumberOfIngredients()
        /// <summary>
        ///https://learn.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=net-8.0
        /// This method asks the user for the number of ingredients in the recipe.
        /// It checks if the input is a number.
        /// </summary>
        {   
            // ask user for number of ingredients
            Console.WriteLine("How many ingredients are in your recipe?: ");

            int numberOfIngredients;

            // check if input is a number
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
        /// <summary>
        /// https://www.tutorialsteacher.com/csharp/csharp-ternary-operator
        /// This method asks the user for the name of each ingredient in the recipe.
        /// </summary>
        {
            // ask user for ingredient name
            Console.WriteLine("Enter the name of ingredient " + index + ": ");

            // check if input is null
            string? ingredient = Console.ReadLine();
            return ingredient ?? string.Empty;
        }
//---------------------------------------------------------------------------------------------------------------------------------
        public string Quantity(string ingredient)
        {   

            while (true)
            {
                // ask user for quantity of ingredient
                Console.WriteLine("Enter the quantity of " + ingredient + ": ");
                string quantity = Console.ReadLine() ?? string.Empty;

                // check if input is a number
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
        public Dictionary<string, double> Units()
        /// <summary>
        /// https://www.youtube.com/watch?v=5VvAcoBJGJs
        /// This method creates a dictionary to store the units of measurement for the ingredients.
        /// </summary>
        {
            // Dictionary to store the units
            Dictionary<string, double> units = new()
            {
                {"cups", 1.0},
                {"tablespoons", 1.0 * 16},
                {"teaspoons", 1.0 * 48},
            };
                return units;
        }

            
//---------------------------------------------------------------------------------------------------------------------------------
        public int NumberOfSteps()
        {
            // ask user for number of steps
            Console.WriteLine("How many steps are in your recipe?: ");
            int numberOfSteps;

            // check if input is a number greater than 0
            while (!int.TryParse(Console.ReadLine(), out numberOfSteps) || numberOfSteps <= 0)
            {
                Console.WriteLine("Please enter a number greater than 0: ");
            }
            return numberOfSteps;
        }
//---------------------------------------------------------------------------------------------------------------------------------
        public string[] StepDescription(int numberOfSteps)
        /// <summary>
        /// https://www.geeksforgeeks.org/c-sharp-arrays/
        /// This method asks the user for the description of each step in the recipe.
        /// It stores the steps in an array.
        /// </summary>
        {
            // Create an array to store the steps
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
        /// <summary>
        /// https://stackoverflow.com/questions/169217/c-sharp-equivalent-of-the-isnull-function-in-sql-server
        /// This method checks if the description is empty and asks the user to enter a description if it is empty.
        /// </summary>
        {
            // check if description is empty
            while (string.IsNullOrEmpty(description))
            {
                Console.WriteLine("Description cannot be empty. Please enter a description: ");
                description = Console.ReadLine() ?? string.Empty;
            }
            return description;
        }
//------------------------------------------------------end of file------------------------------------------------------------------
    }
}