using TP_LINQ;
using TP_LINQ.MyProduct;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;

namespace TP_LINQ_TEST
{
    [TestClass]
    public class MyProductQueryTests
    {
        private List<MyProduct> insertProductsFromBase()
        {
            return (from product in DataService.GetAllProducts()
                    select new MyProduct(product)).ToList();
        }

        [TestMethod]
        public void DataContextAddTest()
        {
            MyProductContext myProductContext = new MyProductContext();
            myProductContext.Add(new MyProduct(DataService.GetProductByName("Adjustable Race")));
            Assert.AreEqual(myProductContext.GetAll().Count, 1);
        }

        [TestMethod]
        public void DataContextAddRangeTest()
        {
            MyProductContext myProductContext = new MyProductContext();
            myProductContext.Add(insertProductsFromBase());
            Assert.AreEqual(myProductContext.GetAll().Count, 504);
        }

        [TestMethod]
        public void DataContextGetAllTest()
        {
            MyProductContext myProductContext = new MyProductContext();
            myProductContext.Add(insertProductsFromBase());
            Assert.AreEqual(myProductContext.GetAll().Count, 504);
        }

        [TestMethod]
        public void GetProductsByNameTest()
        {
            MyProductContext myProductContext = new MyProductContext();
            myProductContext.Add(insertProductsFromBase());
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
            myProductContext.Add(insertProductsFromBase());
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
            myProductContext.Add(insertProductsFromBase());
            MyProductService myProductService = new MyProductService(myProductContext);

            ProductCategory categoryName = DataService.getCategoryFromString("Components");
            decimal cost = myProductService.GetTotalStandardCostByCategory(categoryName);
            Assert.AreEqual(35930.3944m, cost);
        }
    }
}
