using System;
using InventaryWeb.Controllers;
using InventaryWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InventaryUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Magic()
        {
            //ARRANGE
            using (ProductsController productsController = new ProductsController())
            {
                ProductsController producto = productsController;
                int val1 = 3;
                int val2 = 4;
                int result = 7;
                int CurrentResult = 0;
                //ACT
                CurrentResult = productsController.Sum(val1, val2);
                Assert.IsTrue(CurrentResult == result, "Incorrect number");
            }
        }
        [TestMethod]
        public void pruebaOldestProduct()
        {
            _ = new Product() { Id = 9 };
            int id = 9;
            using (var homecontroller = new HomeController())
            {
                int CurrentResult = homecontroller.OldestProducts();
                Assert.AreEqual(id, CurrentResult);
            }

        }
        [TestMethod]
        public void PruebaNewProduct()
        {
            _ = new Product() { Id = 9 };
            int id = 8;
            using (var homecontroller = new HomeController())
            {
                int CurrentResult = homecontroller.NewProduct();
                Assert.AreEqual(id, CurrentResult);
            }
        }
        [TestMethod]
        public void IndexProviders()
        {
            int cant = 8;
            using (var providers = new ProvidersController())
            {
                int CurrentResult = providers.ProvidersIndex();
                Assert.AreEqual(cant, CurrentResult);
            }

        }
        [TestMethod]
        public void productWithAmount()
        {
            int cant = 12;
            using (var products = new ProductsController())
            {
                int CurrentResult = products.ProductWithAmount();
                Assert.AreEqual(cant, CurrentResult);
            }

        }
    }
}
