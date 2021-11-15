using BLULagoon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLULagoonUnitTests
{
    [TestClass]
    public class AddCocktailIngredientUnitTest
    {
        [TestMethod]
        public void AddCocktailIngredient_cocktailid_UnitTest()
        {
            AddCocktailIngredient addCocktailIngredient = new AddCocktailIngredient();
            addCocktailIngredient.cocktailID = 54;
            Assert.IsTrue(addCocktailIngredient.cocktailID == 54);
        }

        [TestMethod]
        public void AddCocktailIngredient_ingredientid_UnitTest()
        {
            AddCocktailIngredient addCocktailIngredient = new AddCocktailIngredient();
            addCocktailIngredient.ingredientID = 54;
            Assert.IsTrue(addCocktailIngredient.ingredientID == 54);
        }

        [TestMethod]
        public void AddCocktailIngredient_ingredientcount_UnitTest()
        {
            AddCocktailIngredient addCocktailIngredient = new AddCocktailIngredient();
            addCocktailIngredient.ingredientCount = 4.20;
            Assert.IsTrue(addCocktailIngredient.ingredientCount == 4.20);
        }

        [TestMethod]
        public void AddCocktailIngredient_ingredientunit_UnitTest()
        {
            AddCocktailIngredient addCocktailIngredient = new AddCocktailIngredient();
            addCocktailIngredient.ingredientUnit = 2;
            Assert.IsTrue(addCocktailIngredient.ingredientUnit == 2);
        }

    }
}