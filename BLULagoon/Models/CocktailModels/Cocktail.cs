namespace BLULagoon.Models
{
    /// <summary>
    /// Main cocktail class with all required information.
    /// </summary>
    public class Cocktail
    {
        public int cocktailID { get; set; }
        public string cocktailName { get; set; }

        public string description { get; set; }
        public string type { get; set; }
        public string glass { get; set; }
        public string taste { get; set; }
        public string method { get; set; }

        public string IBA { get; set; }

        public string instructions { get; set; }

        public int userID { get; set; }

        public List<CocktailIngredientNoID> cocktailIngredients;
        public List<CocktailIngredientNoID> CocktailIngredients
        {
            get
            {
                if (cocktailIngredients == null)
                    cocktailIngredients = new List<CocktailIngredientNoID>();

                return cocktailIngredients;
            }
            
        }
    }
}
