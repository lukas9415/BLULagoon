using BLULagoon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BLULagoonUnitTests
{
    [TestClass]
    public class PostCocktailUnitTest
    {
        [TestMethod]
        public void PostCocktail_cocktailname_UnitTest()
        {
            PostCocktail postcocktail = new PostCocktail();
            postcocktail.cocktailName = "Patikimiausias";
            Assert.IsTrue(postcocktail.cocktailName == "Patikimiausias");
        }

        [TestMethod]
        public void PostCocktail_description_UnitTest()
        {
            PostCocktail postcocktail = new PostCocktail();
            postcocktail.description = "Patikimiausias";
            Assert.IsTrue(postcocktail.description == "Patikimiausias");
        }

        [TestMethod]
        public void PostCocktail_type_UnitTest()
        {
            PostCocktail postcocktail = new PostCocktail();
            postcocktail.type = 2;
            Assert.IsTrue(postcocktail.type == 2);
        }

        [TestMethod]
        public void PostCocktail_glass_UnitTest()
        {
            PostCocktail postcocktail = new PostCocktail();
            postcocktail.glass = 2;
            Assert.IsTrue(postcocktail.glass == 2);
        }

        [TestMethod]
        public void PostCocktail_taste_UnitTest()
        {
            PostCocktail postcocktail = new PostCocktail();
            postcocktail.taste = 2;
            Assert.IsTrue(postcocktail.taste == 2);
        }

        [TestMethod]
        public void PostCocktail_method_UnitTest()
        {
            PostCocktail postcocktail = new PostCocktail();
            postcocktail.method = 2;
            Assert.IsTrue(postcocktail.method == 2);
        }

        [TestMethod]
        public void PostCocktail_iba_UnitTest()
        {
            PostCocktail postcocktail = new PostCocktail();
            postcocktail.IBA = "TRUE";
            Assert.IsTrue(postcocktail.IBA == "TRUE");
        }

        [TestMethod]
        public void PostCocktail_instructions_UnitTest()
        {
            PostCocktail postcocktail = new PostCocktail();
            postcocktail.instructions = "TRUE";
            Assert.IsTrue(postcocktail.instructions == "TRUE");
        }

        [TestMethod]
        public void PostCocktail_userid_UnitTest()
        {
            PostCocktail postcocktail = new PostCocktail();
            postcocktail.userID = 2;
            Assert.IsTrue(postcocktail.userID == 2);
        }

    }
}