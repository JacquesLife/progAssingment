namespace RecipeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            RecipeBook.Classes.IngridientsClass ingridientsClass = new RecipeBook.Classes.IngridientsClass();
            Console.WriteLine("How many ingridients are in your recipe?: ");
            int numberOfIngridients;
            while (!int.TryParse(Console.ReadLine(), out numberOfIngridients))
            {
                Console.WriteLine("Please enter a number: ");
            }

            ingridientsClass.ingridients(numberOfIngridients);
        }
    }
}