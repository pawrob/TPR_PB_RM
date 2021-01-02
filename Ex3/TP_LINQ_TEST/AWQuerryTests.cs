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

        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> p1 = DataService.GetProductsWithNRecentReviews(3);
            List<Product> p2 = DataService.GetProductsWithNRecentReviews(37);
            Assert.AreEqual(2, p1.Count);
            Assert.AreEqual(3, p2.Count);
        }

        [TestMethod]
        public void GetNRecentlyReviewedProductsTest()
        {
            List<Product> p1 = DataService.GetNRecentlyReviewedProducts(2);
            Assert.AreEqual(2, p1.Count);
        }

        [TestMethod]
        public void GetNProductFromCategoryTest()
        {
            List<Product> p1 = DataService.GetNProductFromCategory("Components", 10);
            Assert.AreEqual("Components", p1[0].ProductSubcategory.ProductCategory.Name);
            Assert.AreEqual(10, p1.Count);
        }

        [TestMethod]
        public void GetTotalStandardCostByCategoryTest()

        {
            ProductCategory categoryName = DataService.getCategoryFromString("Components");
            decimal cost = DataService.GetTotalStandardCostByCategory(categoryName);
            Assert.AreEqual(35930.3944m, cost);
        }
    }
}
