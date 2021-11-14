namespace BLULagoon.Models
{
    public class PostCocktail
    {
        public string? cocktailName { get; set; }

        public string? description { get; set; }
        public int type { get; set; }
        public int glass { get; set; }
        public int taste { get; set; }
        public int method { get; set; }

        public string? IBA { get; set; }

        public string? instructions { get; set; }

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
