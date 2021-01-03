using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using TP_LINQ;

namespace TP_LINQ_TEST
{
    [TestClass]
    public class AWExtensionMethodsTests
    {
        [TestMethod]
        public void SplitProductsIntoPagesTest()
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                int size = 20;
                int pages = 2;
                Table<Product> productTable = dataContext.GetTable<Product>();
                List<Product> productsFromDB = productTable.ToList();
                List<Product> productsSplited = productsFromDB.SplitProductsIntoPages(size, pages);
                Assert.AreEqual(size, productsSplited.Count);
                for (int i = 0; i < size; i++)
                {
                    Assert.AreEqual(productsFromDB[i + size * pages], productsSplited[i]);
                }
            }
        }

        [TestMethod]
        public void ListProductsWithVendorsTest()
        {
            List<Product> products = new List<Product>() { DataService.GetProductByName("LL Grip Tape") };
            List<ProductVendor> productVendors = DataService.GetAllProductVendors();
            string output = products.ListProductsWithVendors(productVendors);
            Assert.AreEqual(output, "LL Grip Tape - Gardner Touring Cycles" + "\n" + "LL Grip Tape - National Bike Association" + "\n");

        }


        public void QuerrySyntaxGetProductWithoutCategoryTest()
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                Table<Product> productTable = dataContext.GetTable<Product>();
                List<Product> products = productTable.ToList();
                products = products.GetProductsWithoutCategoryQS();
                Assert.AreEqual(209, products.Count);
            }

        }

        [TestMethod]
        public void MethodSyntaxGetProductWithoutCategoryTest()
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                Table<Product> productTable = dataContext.GetTable<Product>();
                List<Product> products = productTable.ToList();
                products = products.GetProductsWithoutCategoryMS();
                Assert.AreEqual(209, products.Count);
            }

        }
    }
}
