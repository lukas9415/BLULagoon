namespace BLULagoon.Models
{
    /// <summary>
    /// Main cocktail ingredient class.
    /// </summary>
    public class CocktailIngredient
    {
        public int cocktailID { get; set; }
        public string ingredientName { get; set; }
        public double ingredientCount { get; set; }
        public string ingredientUnit { get; set; }
    }
}
