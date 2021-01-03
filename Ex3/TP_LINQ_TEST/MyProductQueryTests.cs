using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TP_LINQ;
using TP_LINQ.MyProduct;

namespace TP_LINQ_TEST
{
    [TestClass]
    public class MyProductQueryTests
    {
        private List<MyProduct> getMyProducts()
        {
            return (from product in DataService.GetAllProducts()
                    select new MyProduct(product)).ToList();
        }

        [TestMethod]
        public void DataContextGetAllTest()
        {
            MyProductContext myProductContext = new MyProductContext();
            myProductContext.Add(getMyProducts());
            Assert.AreEqual(myProductContext.GetAll().Count, 504);
        }

        [TestMethod]
        public void GetProductsByNameTest()
        {
            MyProductContext myProductContext = new MyProductContext();
            myProductContext.Add(getMyProducts());
            MyProductService myProductService = new MyProductService(myProductContext);
            List<MyProduct> p1 = myProductService.GetProductsByName("Blade");
            List<MyProduct> p2 = myProductService.GetProductsByName("Flat Washer");
            List<MyProduct> p3 = myProductService.GetProductsByName("2137");
            Assert.AreEqual(1, p1.Count);
            Assert.AreEqual(9, p2.Count);
            Assert.AreEqual(0, p3.Count);
        }

        [TestMethod]
        public void GetNMyProductFromCategoryTest()
        {
            MyProductContext myProductContext = new MyProductContext();
            myProductContext.Add(getMyProducts());
            MyProductService myProductService = new MyProductService(myProductContext);
            List<MyProduct> list = myProductService.GetNMyProductFromCategory("Components", 4);
            Assert.AreEqual(list.Count, 4);

            for(int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(list[i].ProductSubcategory.ProductCategory.Name, "Components");
            }
        }

        [TestMethod]
        public void GetTotalStandardCostByCategoryTest()
        {
            MyProductContext myProductContext = new MyProductContext();
            myProductContext.Add(getMyProducts());
            MyProductService myProductService = new MyProductService(myProductContext);
            ProductCategory categoryName = DataService.getCategoryFromString("Components");
            decimal cost = myProductService.GetTotalStandardCostByCategory(categoryName);
            Assert.AreEqual(35930.3944m, cost);
        }
    }
}
