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
            int numberOfSteps = ingredientsClass.NumberOfSteps();
            
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
            // user chose to scale 
            if (ingredientsClass.ChooseToScaleRecipe())
            {
                double scaleFactor = ingredientsClass.ScaleFactor();
                ingredientsClass.ScaleRecipe(ref quantities, scaleFactor);
                Console.WriteLine("Here is your scaled recipe: ");
            }
            else
            {
                Console.WriteLine("Here is your recipe: ");
            }

            // Display the full recipe
            ingredientsClass.FullRecipe(ingredients, quantities, units, numberOfSteps);

        }
    }
}
            
