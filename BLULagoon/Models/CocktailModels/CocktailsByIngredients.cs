namespace BLULagoon.Models
{
    /// <summary>
    /// Cocktail class used to search by ingredients.
    /// </summary>
    public class CocktailsByIngredients
    {
        public string cocktailName { get; set; }
        public double ingredientCount { get; set; }
        public string unitShort { get; set; }
    }
}
