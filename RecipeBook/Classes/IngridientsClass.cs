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
        public void ingridients() {

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