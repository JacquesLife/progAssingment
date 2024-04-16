/// <summary>
/// Name: Jacques du Plessis
/// Student: ST10329686
/// Module: PROG6221
/// </summary>
/// This program is a recipe book that allows the user to enter a recipe with ingredients, quantities, and units. 
/// The user can then scale the recipe and reset it to the original quantities.
/// References All
/// https://www.c-sharpcorner.com/article/change-console-foreground-and-background-color-in-c-sharp/
/// https://www.w3schools.com/cs/cs_operators_logical.php
/// https://www.geeksforgeeks.org/ref-in-c-sharp/
/// https://www.c-sharpcorner.com/article/how-to-copy-an-array-in-c-sharp/
/// https://www.c-sharpcorner.com/UploadFile/c713c3/how-to-exit-in-C-Sharp/#
/// https://www.c-sharpcorner.com/article/change-console-foreground-and-background-color-in-c-sharp/
/// https://www.w3schools.com/cs/cs_operators_logical.php
/// https://www.geeksforgeeks.org/ref-in-c-sharp/
/// https://www.c-sharpcorner.com/article/how-to-copy-an-array-in-c-sharp/
/// https://www.c-sharpcorner.com/UploadFile/c713c3/how-to-exit-in-C-Sharp/#

using RecipeBook.Classes;

namespace RecipeBook
{
    class Program
    {
        /// <summary>
	   /// This is the main method that runs the program it it utlisies the IngredientsClass and RecipeClass to get the recipe from the user and display it
       /// It is responsible for ordering the methods in the correct order and calling the correct methods
       /// It is the structure of the program
	   /// </summary>

// --------------------------------------------------------------------------------------------------------------------------------
        static void Main(string[] args)
        {
            
            // Instantiate the IngredientsClass
            IngredientsClass ingredientsClass = new IngredientsClass();

            // Instantiate the RecipeClass
            RecipeClass recipeClass = new RecipeClass();

            while (true) {

            // Get the number of ingredients
            int numberOfIngredients = ingredientsClass.NumberOfIngredients();

            // number of steps
            Console.WriteLine("How many steps are in your recipe?: ");
            int numberOfSteps;
            while (!int.TryParse(Console.ReadLine(), out numberOfSteps) || numberOfSteps <= 0)
            {
                Console.WriteLine("Please enter a number greater than 0: ");
            }

            // Create an array to store the steps
            string[] steps = new string[numberOfSteps];

            // Create arrays to store the ingredients, quantities, and units
            string[] ingredients = new string[numberOfIngredients];
            string[] quantities = new string[numberOfIngredients];
            string[] units = new string[numberOfIngredients];

            // Get the name, quantity, and unit of each ingredient
            for (int i = 0; i < numberOfIngredients; i++)
            {
                ingredients[i] = ingredientsClass.IngredientName(i + 1);
                quantities[i] = ingredientsClass.Quantity(ingredients[i]);
            }
            // Get the unit conversion for each ingredient
            Dictionary<string, double> unitConversion = ingredientsClass.Units();

            // Call StepDescription
            string [] stepDescription = ingredientsClass.StepDescription(numberOfSteps);

            // Display the current recipe
            RecipeClass.FullRecipe(ingredients, quantities, units, steps.Length, stepDescription, unitConversion);

            // user chose to scale 
            if (recipeClass.ChooseToScaleRecipe())
            {
                double scaleFactor = recipeClass.ScaleFactor();
                recipeClass.AdjustQuantites(ref quantities, scaleFactor);
                Console.WriteLine("Here is your scaled recipe: ");

                // Display the scaled recipe
                RecipeClass.FullRecipe(ingredients, quantities, units, steps.Length, stepDescription, unitConversion);

                // Ask user to reset the recipe to original quantities only if they scaled the recipe
                recipeClass.ResetRecipe(ref quantities, units, ingredients, unitConversion, ref stepDescription);
            }
            else
            {
                Console.WriteLine("Here is your recipe: ");
                // Display the current recipe
                RecipeClass.FullRecipe(ingredients, quantities, units, steps.Length, stepDescription, unitConversion);
            }

            // Ask user if they want to enter a new recipe
            recipeClass.EnterNewRecipe();

            }
        }
    }
}
            
//-------------------------------------------------end of file --------------------------------------------------------------