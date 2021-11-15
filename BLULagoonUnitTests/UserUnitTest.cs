using BLULagoon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLULagoonUnitTests
{
    [TestClass]
    public class UserUnitTest
    {
        [TestMethod]
        public void User_userid_UnitTest()
        {
            User user = new User();
            user.UserID = 15;
            Assert.IsTrue(user.UserID == 15);
        }

        [TestMethod]
        public void User_name_UnitTest()
        {
            User user = new User();
            user.Name = "Alekdandr";
            Assert.IsTrue(user.Name == "Alekdandr");
        }

        [TestMethod]
        public void User_surname_UnitTest()
        {
            User user = new User();
            user.Surname = "Testanov";
            Assert.IsTrue(user.Surname == "Testanov");
        }
    }
}