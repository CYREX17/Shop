using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Shop.Tests
{
    [TestClass]
    public class SessionTests
    {
        [TestMethod]
        public void ProductAdd_AddNewProduct_SaveToProductList()
        {
            //Act
            Session.ProductAdd(new StubConsoleProvider());

            //Assert
            Assert.IsTrue(Session.productsList.Find(p => p.ProductName == "Test" && p.ProductPrice == 100) != null);
        }

        [TestMethod]
        public void Registration_AddNewUserWithNonEmptyLines_SaveToUserList()
        {
            //Act
            Session.Registration(new StubConsoleProvider());

            //Assert
            Assert.IsTrue(Session.userList.Find(u => u.userName == "Test") != null);
        }

    }

    class StubConsoleProvider : IConsoleProvider
    {
        public string ReadLine()
        {
            return "Test";
        }

        public string ReadLineCategory()
        {
            return "4";
        }

        public string ReadLinePrice()
        {
            return "100";
        }

    }

    class StubEmptyLinesConsoleProvider : IConsoleProvider
    {
        public string ReadLine()
        {
            return "";
        }

        public string ReadLineCategory()
        {
            return "";
        }

        public string ReadLinePrice()
        {
            return "";
        }

    }

}
