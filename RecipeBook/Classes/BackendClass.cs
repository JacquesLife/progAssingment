using System;

namespace RecipeBook.Classes 
{
    internal class BackendClass {

        // Properties
        public int numberOfIngridients { get; set; }
        public string[] ingridients { get; set; }
        public int numberOfSteps { get; set; }
        public string[] steps { get; set; }
        public string fullRecipe { get; set; }
        public string scaleRecipe { get; set; }
        public string resetRecipe { get; set; }
        public string clearRecipe { get; set; }

        // Constructors
        public BackendClass() {
            this.numberOfIngridients = 0;
            this.ingridients = new string[0];
            this.numberOfSteps = 0;
            this.steps = new string[0];
            this.fullRecipe = "";
            this.scaleRecipe = "";
            this.resetRecipe = "";
            this.clearRecipe = "";
        }
    }
}
    