using BLULagoon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BLULagoonUnitTests
{
    [TestClass]
    public class CocktailIngredientNoIDUnitTest
    {
        [TestMethod]
        public void CocktailIngredientNoID_ingredientname_UnitTest()
        {
            CocktailIngredientNoID cocktailIngredient = new CocktailIngredientNoID();
            cocktailIngredient.ingredientName = "PATIKIMAS";
            Assert.IsTrue(cocktailIngredient.ingredientName == "PATIKIMAS");
        }

        [TestMethod]
        public void CocktailIngredientNoID_ingredientcount_UnitTest()
        {
            CocktailIngredientNoID cocktailIngredient = new CocktailIngredientNoID();
            cocktailIngredient.ingredientCount = 6.0;
            Assert.IsTrue(cocktailIngredient.ingredientCount == 6.0);
        }

        [TestMethod]
        public void CocktailIngredientNoID_ingredientunit_UnitTest()
        {
            CocktailIngredientNoID cocktailIngredient = new CocktailIngredientNoID();
            cocktailIngredient.ingredientUnit = "PATIKIMAS";
            Assert.IsTrue(cocktailIngredient.ingredientUnit == "PATIKIMAS");
        }


    }
}