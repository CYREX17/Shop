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
            //Arrange
            Session session = new Session();
            Product newProduct = new Product("Test", Product.productCategoryType.Alcohol, "Test", 100);

            //Act
            session.ProductAdd(new StubConsoleProvider());

            //Assert
            Assert.IsTrue(Repository.productsList.Find(p => p.ProductName == "Test") != null);
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
}
