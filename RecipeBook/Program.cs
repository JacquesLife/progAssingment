using RecipeBook.Classes;

namespace RecipeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IngridientsClass ingredientsClass = new IngridientsClass(); // Corrected class name

            int numberOfIngredients = ingredientsClass.GetNumberOfIngredients();

            string[] ingredients = new string[numberOfIngredients];
            string[] quantities = new string[numberOfIngredients];
            string[] units = new string[numberOfIngredients];

            for (int i = 0; i < numberOfIngredients; i++)
            {
                ingredients[i] = ingredientsClass.GetIngredientName(i + 1); // Adjusted index
                quantities[i] = ingredientsClass.GetQuantity(ingredients[i]);
                units[i] = ingredientsClass.GetUnit(ingredients[i]);
            }

            ingredientsClass.FullRecipe(ingredients, quantities, units);
        }
    }
}
