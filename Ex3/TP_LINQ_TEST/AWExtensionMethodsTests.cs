using TP_LINQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;

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
                int pages = 1;
                Table<Product> table = dataContext.GetTable<Product>();
                List<Product> productsFromDB = table.ToList();
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
            List<ProductVendor> productVendors = DataService.GetAllVendors();
            string description = products.ListProductsWithVendors(productVendors);
            Assert.AreEqual(description, "LL Grip Tape - Gardner Touring Cycles" + "\n"
                                       + "LL Grip Tape - National Bike Association" + "\n");

        }


        public void QuerrySyntaxGetProductWithoutCategoryTest()
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                Table<Product> table = dataContext.GetTable<Product>();
                List<Product> products = table.ToList();
                products = products.GetProductsWithoutCategoryQS();
                Assert.AreEqual(209, products.Count);
            }

        }

        [TestMethod]
        public void MethodSyntaxGetProductWithoutCategoryTest()
        {
            using (DataClassesDataContext dataContext = new DataClassesDataContext())
            {
                Table<Product> table = dataContext.GetTable<Product>();
                List<Product> products = table.ToList();
                products = products.GetProductsWithoutCategoryMS(); ;
                Assert.AreEqual(209, products.Count);
            }

        }
    }
}
