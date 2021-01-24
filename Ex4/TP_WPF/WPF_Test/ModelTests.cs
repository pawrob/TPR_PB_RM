using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Model;

namespace WPF_Test
{
    [TestClass]
    public class ModelTests
    {
        private TestDataContext dataService;
        private InitData initData = new InitData();

        public ModelTests()
        {           
            dataService = new TestDataContext(initData);
        }

        [TestMethod]
        public void GetAllTest()
        {
            Assert.AreEqual(5, dataService.getAll().Count);
        }


        [TestMethod]
        public void AddProductTest()
        {
            Assert.AreEqual(5, dataService.getAll().Count);
            Assert.AreEqual(dataService.addProduct("Bike Faster", "XA-2222", "Bluberry purple", 28, 200.4m, "standard", 8.2m), "Product sucessfuly added");
            Assert.AreEqual(6, dataService.getAll().Count);
        }

        [TestMethod]
        public void RemoveProductTest()
        {
            Assert.AreEqual(5, dataService.getAll().Count);
            Assert.AreEqual(dataService.removeProduct("Bike Fast"), "Product removed");
            Assert.AreEqual(4, dataService.getAll().Count);
        }

        [TestMethod]
        public void UpdateProductTest()
        {
            Assert.AreEqual(dataService.updateProduct(2137, "Motorbike Slow", "XY-7312", "Black", 13, 1220.2m, "small", 47.3m), "Update sucessful");
            Assert.AreEqual(dataService.dataContext[4].Name, "Motorbike Slow");
            Assert.AreEqual(dataService.dataContext[4].ProductNumber, "XY-7312");
            Assert.AreEqual(dataService.dataContext[4].Color, "Black");
            Assert.AreEqual(dataService.dataContext[4].SafetyStockLevel, 13);
            Assert.AreEqual(dataService.dataContext[4].StandardCost, 1220.2m);
            Assert.AreEqual(dataService.dataContext[4].Size, "small");
            Assert.AreEqual(dataService.dataContext[4].Weight, 47.3m);
        }
        
    }
}
