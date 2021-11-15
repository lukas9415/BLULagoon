using BLULagoon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLULagoonUnitTests
{
    [TestClass]
    public class IngredientUnitTest
    {
        [TestMethod]
        public void Ingredient_id_UnitTest()
        {
            Ingredient ingredient = new Ingredient();
            ingredient.ingredientID = 42;
            Assert.IsTrue(ingredient.ingredientID == 42);
        }

        [TestMethod]
        public void Ingredient_name_UnitTest()
        {
            Ingredient ingredient = new Ingredient();
            ingredient.ingredientName = "Bananas";
            Assert.IsTrue(ingredient.ingredientName == "Bananas");
        }

    }
}