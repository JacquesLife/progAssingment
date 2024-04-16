/// <summary>
/// Name: Jacques du Plessis
/// Student: ST10329686
/// Module: PROG6221
/// </summary>
/// This class displays the recipe with ingredients, quantities, units, number of steps, and step descriptions.
/// it also allows the user to scale the recipe and reset it to the original quantities.
/// References:
/// https://www.c-sharpcorner.com/article/change-console-foreground-and-background-color-in-c-sharp/
/// https://www.w3schools.com/cs/cs_operators_logical.php
/// https://www.geeksforgeeks.org/ref-in-c-sharp/
/// https://www.c-sharpcorner.com/article/how-to-copy-an-array-in-c-sharp/
/// https://www.c-sharpcorner.com/UploadFile/c713c3/how-to-exit-in-C-Sharp/#
/// 



using System;
using System.Net;
using System.IO; 

namespace RecipeBook.Classes 
{
    internal class RecipeClass
     {
        private string[] originalQuantities = Array.Empty<string>();
//---------------------------------------------------------------------------------------------------------------------------------
        public static void FullRecipe(string[] ingredients, string[] quantities, string[] units, int numberOfSteps, string[] stepDescription, Dictionary<string, double> unitConversions)
        {
            /// <summary>
            /// https://www.c-sharpcorner.com/article/change-console-foreground-and-background-color-in-c-sharp/
            /// This method displays the full recipe with ingredients, quantities, units, number of steps, and step descriptions.
            /// It also colours the text.
            /// </summary>

            // Display the recipe with ingredients, quantities, units, number of steps, and step descriptions and colour the text
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Name:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(ingredients[i]);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Quantity:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(quantities[i]);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Unit:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(units[i]);
                Console.ForegroundColor = ConsoleColor.Blue;

            // Display the unit conversions
            foreach (var entry in unitConversions)
            {
                Console.WriteLine($"{entry.Key} = {entry.Value} cups");
            }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
            }
    
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Number of steps:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(numberOfSteps);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------------------------");
                Console.WriteLine();

            // Display the step descriptions
            for (int i = 0; i < numberOfSteps; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Step " + (i + 1) + ":");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(stepDescription[i]);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------------------------");
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
        /// <summary>
        /// https://www.w3schools.com/cs/cs_operators_logical.php
        /// This method asks the user for the scale factor 2, 3 or 0.5.
        /// </summary>
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
        /// <summary>
        /// https://www.geeksforgeeks.org/ref-in-c-sharp/
        /// This method scales the quantities by the scale factor 2, 3 or 0.5.
        /// It does this by multiplying the quantity by the scale factor.
        /// </summary>
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
                
        public void ResetRecipe(ref string[] quantities, string[] units, string[] ingredients, Dictionary<string, double> unitConversions, ref string[] stepDescriptions)
        /// <summary>
        /// https://www.c-sharpcorner.com/article/how-to-copy-an-array-in-c-sharp/
        /// This method asks the user if they want to reset the recipe to the original quantities.
        /// it does this by cloning the original quantities.
        /// <summary>

        {
            // Ask user if they want to reset the recipe to the original quantities
            Console.WriteLine("Would you like to reset the recipe to the original quantities? (yes/no): ");
            string? resetRecipe;

            while (true)
            {
                resetRecipe = Console.ReadLine();
                if (resetRecipe == "yes")
                {
                    // Reset quantities to original quantities by cloning the original quantities
                    quantities = originalQuantities.Clone() as string[];
            
                    // Display original recipe
                    FullRecipe(ingredients, quantities, units, originalQuantities.Length, stepDescriptions, unitConversions);
                    break;
                }
                else if (resetRecipe == "no")
                {
                    // Display current recipe
                    FullRecipe(ingredients, quantities, units, stepDescriptions.Length, stepDescriptions, unitConversions);
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
        /// <summary>
        /// https://www.c-sharpcorner.com/UploadFile/c713c3/how-to-exit-in-C-Sharp/#
        /// This method asks the user if they want to enter a new recipe.
        /// if not, the program exits.
        /// </summary>
        {
            // ask user if they want to enter a new recipe
            Console.WriteLine("Would you like to enter a new recipe? (yes/no): ");
            string? newRecipe;
            
            // input must be yes or no
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
                    // exit the program
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please enter yes or no: ");
                }
            }
        }
//----------------------------------------end of file---------------------------------------------------------------------------
    }
}