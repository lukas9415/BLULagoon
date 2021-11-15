using BLULagoon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BLULagoonUnitTests
{
    [TestClass]
    public class CocktailUnitTest
    {
        [TestMethod]
        public void Cocktail_cocktailid_UnitTest()
        {
            Cocktail cocktail = new Cocktail();
            cocktail.cocktailID = 50;
            Assert.IsTrue(cocktail.cocktailID == 50);
        }

        [TestMethod]
        public void Cocktail_cocktailname_UnitTest()
        {
            Cocktail cocktail = new Cocktail();
            cocktail.cocktailName = "Samyj Lutchyj";
            Assert.IsTrue(cocktail.cocktailName == "Samyj Lutchyj");
        }

        [TestMethod]
        public void Cocktail_description_UnitTest()
        {
            Cocktail cocktail = new Cocktail();
            cocktail.description = "Patikima";
            Assert.IsTrue(cocktail.description == "Patikima");
        }

        [TestMethod]
        public void Cocktail_type_UnitTest()
        {
            Cocktail cocktail = new Cocktail();
            cocktail.type = "Patikima";
            Assert.IsTrue(cocktail.type == "Patikima");
        }

        [TestMethod]
        public void Cocktail_glass_UnitTest()
        {
            Cocktail cocktail = new Cocktail();
            cocktail.glass = "Patikima";
            Assert.IsTrue(cocktail.glass == "Patikima");
        }

        [TestMethod]
        public void Cocktail_taste_UnitTest()
        {
            Cocktail cocktail = new Cocktail();
            cocktail.taste = "Patikima";
            Assert.IsTrue(cocktail.taste == "Patikima");
        }

        [TestMethod]
        public void Cocktail_method_UnitTest()
        {
            Cocktail cocktail = new Cocktail();
            cocktail.method = "Patikima";
            Assert.IsTrue(cocktail.method == "Patikima");
        }

        [TestMethod]
        public void Cocktail_iba_UnitTest()
        {
            Cocktail cocktail = new Cocktail();
            cocktail.IBA = "Patikima";
            Assert.IsTrue(cocktail.IBA == "Patikima");
        }

        [TestMethod]
        public void Cocktail_instructions_UnitTest()
        {
            Cocktail cocktail = new Cocktail();
            cocktail.instructions = "Patikima";
            Assert.IsTrue(cocktail.instructions == "Patikima");
        }

        [TestMethod]
        public void Cocktail_userid_UnitTest()
        {
            Cocktail cocktail = new Cocktail();
            cocktail.userID = 2;
            Assert.IsTrue(cocktail.userID == 2);
        }

    }
}