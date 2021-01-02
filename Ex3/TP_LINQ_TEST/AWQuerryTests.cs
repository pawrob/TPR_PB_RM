using TP_LINQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;


namespace TP_LINQ_TEST
{
    [TestClass]
    public class AWQuerryTests
    {
        [TestMethod]
        public void GetProductsByNameTest()
        {
            List<Product> p1 = DataService.GetProductsByName("Blade");
            List<Product> p2 = DataService.GetProductsByName("Flat Washer");
            List<Product> p3 = DataService.GetProductsByName("2137");
            Assert.AreEqual(1, p1.Count);
            Assert.AreEqual(9, p2.Count);
            Assert.AreEqual(0, p3.Count);
        }

        [TestMethod]
        public void GetProductByVendorNameTest()
        {
            List<Product> p1 = DataService.GetProductByVendorName("Vista Road Bikes");
            List<Product> p2 = DataService.GetProductByVendorName("");
            Assert.AreEqual(2, p1.Count);
            Assert.AreEqual(0, p2.Count);
        }

        [TestMethod]
        public void GetProductNamesByVendorNameTest()
        {
            List<string> p1 = DataService.GetProductNamesByVendorName("Vista Road Bikes");
            List<string> p2 = DataService.GetProductNamesByVendorName("");
            Assert.AreEqual(2, p1.Count);
            Assert.AreEqual(0, p2.Count);
        }

        [TestMethod]
        public void GetProductVendorByProductNameTest()
        {
            string vendorName = "Continental Pro Cycles";
            string v1 = DataService.GetProductVendorByProductName("Flat Washer 1");
            Assert.AreEqual(vendorName, v1);
        }
    }
}
