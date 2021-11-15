using BLULagoon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BLULagoonUnitTests
{
    [TestClass]
    public class CocktailsByIngredientsUnitTest
    {
        [TestMethod]
        public void Cocktail_cocktailname_UnitTest()
        {
            CocktailsByIngredients cocktail = new CocktailsByIngredients();
            cocktail.cocktailName = "SAMYJ";
            Assert.IsTrue(cocktail.cocktailName == "SAMYJ");
        }

        [TestMethod]
        public void Cocktail_ingredientcount_UnitTest()
        {
            CocktailsByIngredients cocktail = new CocktailsByIngredients();
            cocktail.ingredientCount = 4.0;
            Assert.IsTrue(cocktail.ingredientCount == 4.0);
        }

        [TestMethod]
        public void Cocktail_unitshort_UnitTest()
        {
            CocktailsByIngredients cocktail = new CocktailsByIngredients();
            cocktail.unitShort = "SAMYJ";
            Assert.IsTrue(cocktail.unitShort == "SAMYJ");
        }

    }
}