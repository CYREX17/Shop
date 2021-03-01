using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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
            Session.ProductAdd(new StubConsoleProvider("Test"));

            //Assert
            Assert.IsTrue(Session.productsList.Find(p => p.ProductName == "Test" && p.ProductPrice == 100) != null);
        }

        [TestMethod]
        public void Registration_AddNewUserWithNonEmptyLines_SaveToUserList()
        {
            //Act
            Session.Registration(new StubConsoleProvider("Test"));

            //Assert
            Assert.IsTrue(Session.userList.Find(u => u.userName == "Test") != null);
        }

        [TestMethod]
        public void Shopping_UserChosePay_SaveNewShoppingListToOrderList()
        {
            //Arrange
            Session session = new Session();
            Session.visitor = new Visitor() { login = "Kirill", _visitorType = Visitor.VisitorType.administrator, ShoppingList = new List<Product>() };

            //Act
            Session.Shopping(new StubConsoleProvider("Pay"));

            //Assert
            Assert.IsTrue(Session.userList.FirstOrDefault(p => p.userName == "Kirill").OrderList.Count == 1);
        }


    }

    class StubConsoleProvider : IConsoleProvider
    {
        string value;

        public StubConsoleProvider(string value)
        {
            this.value = value;
        }

        public string ReadLine()
        {
            return value;
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
}
