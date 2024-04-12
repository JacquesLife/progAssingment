using System;

namespace RecipeBook.Classes
{
    internal class IngridientsClass

    {
        public void numberOfIngridients()
        {
        
            Console.WriteLine("How many ingridients are in your recipe?: ");

            // check to see if the user input is a number
            int numberOfIngridients;
            while (!int.TryParse(Console.ReadLine(), out numberOfIngridients))
            {
                Console.WriteLine("Please enter a number: ");
            }

            // output the number of ingridients
            Console.WriteLine("You have " + numberOfIngridients + " ingridients in your recipe.");
        }
        
       public void ingridients(int numberOfIngridients)
{
        // create arrays to store the ingredients, quantities, and units of measurement
        string[] ingredients = new string[numberOfIngridients];
        string[] quantities = new string[numberOfIngridients];
        string[] units = new string[numberOfIngridients];

        // ask the user for the ingredients, quantities, and units
        for (int i = 0; i < numberOfIngridients; i++)
    {
        Console.WriteLine("Enter ingredient name " + (i + 1) + ": ");
        ingredients[i] = Console.ReadLine() ?? string.Empty;

        // Prompt for quantity until a valid integer is entered
        int quantity;
        // Check if the quantity is a number
        bool isValidQuantity = false;
        do
        {
            Console.WriteLine("Enter the quantity of " + ingredients[i] + ": ");
            string? input = Console.ReadLine();
            // Check if the quantity is a number
            if (!int.TryParse(input, out quantity))
            {
                Console.WriteLine("Error: Quantity must be a number. Please try again.");
            }
            else
            {
                isValidQuantity = true;
            }
        }
        while (!isValidQuantity);

        units[i] = Console.ReadLine() ?? string.Empty;
        // Add a space between each ingredient
        Console.WriteLine();
    }

        // output the ingredients with quantities and units
        Console.WriteLine("Your ingredients are: ");
        Console.WriteLine();
        for (int i = 0; i < numberOfIngridients; i++)
    {
        Console.WriteLine(ingredients[i]);
        Console.WriteLine(quantities[i] + units[i]);
        Console.WriteLine();
    }

      }

        public void numberOfSteps() {

        }
        public void fullRecipe() {

        }
        public void scaleRecipe() {

        }
        public void resetRecipe() {

        }
        public void clearRecipe() {

        }
    }
}