namespace BLULagoon.Models
{
    public class AddCocktailIngredient
    {
        public int cocktailID { get; set; }
        public int ingredientID { get; set; }
        public double ingredientCount { get; set; }
        public int ingredientUnit { get; set; }
    }
}
