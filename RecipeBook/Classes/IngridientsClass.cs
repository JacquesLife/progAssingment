using System;

namespace RecipeBook.Classes
{
    internal class IngridientsClass

    {
       public int GetNumberOfIngredients()
        {
            Console.WriteLine("How many ingredients are in your recipe?: ");
            int numberOfIngredients;
            while (!int.TryParse(Console.ReadLine(), out numberOfIngredients))
            {
                Console.WriteLine("Please enter a number: ");
            }
            Console.WriteLine("You have " + numberOfIngredients + " ingredients in your recipe.");
            return numberOfIngredients;
        }

        public string GetIngredientName(int index)
        {
            Console.WriteLine("Enter the name of ingredient " + index + ": ");
            string? ingredient = Console.ReadLine();
            return ingredient ?? string.Empty;
        }

        public string GetQuantity(string ingredient)
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

        public string GetUnit(string ingredient)
        {
            Console.WriteLine("Enter the unit of measurement for " + ingredient + ": ");
            string? unit = Console.ReadLine();
            return unit ?? string.Empty;
        }

        public void numberOfSteps() {

        }
        public void FullRecipe(string[] ingredients, string[] quantities, string[] units)
{
        Console.WriteLine("Here is your recipe: ");
        Console.WriteLine();
        for (int i = 0; i < ingredients.Length; i++)
        {
        Console.WriteLine("Name: " + ingredients[i]);
        Console.WriteLine("Ingredient: " + quantities[i]);
        Console.WriteLine("Quantity: " + units[i]);
        Console.WriteLine("Unit: " + units[i]);
        Console.WriteLine(); 
        }

}

        public void scaleRecipe() {

        }
        public void resetRecipe() {

        }
        public void clearRecipe() {

        }
    }
}