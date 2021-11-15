namespace BLULagoon.Models
{
    /// <summary>
    /// Class used to get all ingredient sums.
    /// </summary>
    public class CocktailSum
    {
        public int cocktailID { get; set; }
        public string cocktailName { get; set; }
        public double cocktailSum { get; set; }
        public string unit { get; set; }
    }
}
