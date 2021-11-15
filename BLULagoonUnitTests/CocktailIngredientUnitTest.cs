using BLULagoon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BLULagoonUnitTests
{
    [TestClass]
    public class CocktailIngredientUnitTest
    {
        [TestMethod]
        public void CocktailIngredient_cocktailid_UnitTest()
        {
            CocktailIngredient cocktailIngredient = new CocktailIngredient();
            cocktailIngredient.cocktailID = 50;
            Assert.IsTrue(cocktailIngredient.cocktailID == 50);
        }

        [TestMethod]
        public void CocktailIngredient_ingredientname_UnitTest()
        {
            CocktailIngredient cocktailIngredient = new CocktailIngredient();
            cocktailIngredient.ingredientName = "TEST";
            Assert.IsTrue(cocktailIngredient.ingredientName == "TEST");
        }

        [TestMethod]
        public void CocktailIngredient_ingredientcount_UnitTest()
        {
            CocktailIngredient cocktailIngredient = new CocktailIngredient();
            cocktailIngredient.ingredientCount = 4.2;
            Assert.IsTrue(cocktailIngredient.ingredientCount == 4.2);
        }


        [TestMethod]
        public void CocktailIngredient_ingredientunit_UnitTest()
        {
            CocktailIngredient cocktailIngredient = new CocktailIngredient();
            cocktailIngredient.ingredientUnit = "TEST";
            Assert.IsTrue(cocktailIngredient.ingredientUnit == "TEST");
        }
    }
}