using RecipeBook.Classes;

namespace RecipeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the IngredientsClass
            IngredientsClass ingredientsClass = new IngredientsClass();

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
                units[i] = ingredientsClass.Unit(ingredients[i]);
            }

            // Step description
            string [] stepDescription = ingredientsClass.StepDescription(numberOfSteps);

            // user chose to scale 
            if (ingredientsClass.ChooseToScaleRecipe())
            {
                double scaleFactor = ingredientsClass.ScaleFactor();
                ingredientsClass.AdjustQuantites(ref quantities, scaleFactor);
                Console.WriteLine("Here is your scaled recipe: ");
            }
            else
            {
                Console.WriteLine("Here is your recipe: ");
            }

            // Remove the declaration of the variable numberOfSteps
            IngredientsClass.FullRecipe(ingredients, quantities, units, steps.Length, stepDescription);

            // Ask user to reset the recipe
            ingredientsClass.ResetRecipe(quantities, units, ingredients);

            // Close the program
            Console.WriteLine("Goodbye!");
        }
    }
}
            
