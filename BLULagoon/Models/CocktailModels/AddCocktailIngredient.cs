namespace BLULagoon.Models
{
    /// <summary>
    /// Class used for adding ingredient to the cocktail.
    /// </summary>
    public class AddCocktailIngredient
    {
        public int cocktailID { get; set; }
        public int ingredientID { get; set; }
        public double ingredientCount { get; set; }
        public int ingredientUnit { get; set; }
    }
}
