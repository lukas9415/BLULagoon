using BLULagoon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BLULagoonUnitTests
{
    [TestClass]
    public class CocktailSumUnitTest
    {
        [TestMethod]
        public void CocktailSum_cocktailid_UnitTest()
        {
            CocktailSum cocktailSum = new CocktailSum();
            cocktailSum.cocktailID = 50;
            Assert.IsTrue(cocktailSum.cocktailID == 50);
        }

        [TestMethod]
        public void CocktailSum_cocktailname_UnitTest()
        {
            CocktailSum cocktailSum = new CocktailSum();
            cocktailSum.cocktailName = "Test";
            Assert.IsTrue(cocktailSum.cocktailName == "Test");
        }

        [TestMethod]
        public void CocktailSum_cocktailsum_UnitTest()
        {
            CocktailSum cocktailSum = new CocktailSum();
            cocktailSum.cocktailSum = 50.0;
            Assert.IsTrue(cocktailSum.cocktailSum == 50.0);
        }

        [TestMethod]
        public void CocktailSum_unit_UnitTest()
        {
            CocktailSum cocktailSum = new CocktailSum();
            cocktailSum.unit = "Testas";
            Assert.IsTrue(cocktailSum.unit == "Testas");
        }


    }
}