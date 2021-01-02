using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LINQ
{
    public class DataService
    {
        private static DataClassesDataContext dataContext = new DataClassesDataContext();


        public static Product GetProductByName(string productName)
        {
            Table<Product> products = dataContext.GetTable<Product>();
            Product result = (from product in products
                              where product.Name.Equals(productName)
                              select product).First();
            return result;
        }
        public static List<Product> GetProductsByName(string namePart)
        {
            Table<Product> products = dataContext.GetTable<Product>();
            List<Product> result = (from product in products
                                    where product.Name.Contains(namePart)
                                    select product).ToList();

            return result;
        }


        public static List<ProductVendor> GetAllVendors()
        {
            Table<ProductVendor> vendors = dataContext.GetTable<ProductVendor>();
            List<ProductVendor> result = (from vendor in vendors
                                          select vendor).ToList();
            return result;
        }

        public static List<Product> GetProductByVendorName(string vendorName)
        {
            Table<ProductVendor> productVendors = dataContext.GetTable<ProductVendor>();
            List<Product> result = (from productVendor in productVendors
                                    where productVendor.Vendor.Name.Equals(vendorName)
                                    select productVendor.Product).ToList();

            return result;
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {

            Table<ProductVendor> productVendors = dataContext.GetTable<ProductVendor>();
            List<string> result = (from productVendor in productVendors
                                   where productVendor.Vendor.Name.Equals(vendorName)
                                   select productVendor.Product.Name).ToList();

            return result;
        }

        public static string GetProductVendorByProductName(string productName)
        {
            Table<ProductVendor> productVendors = dataContext.GetTable<ProductVendor>();
            string result = (from productVendor in productVendors
                             where productVendor.Product.Name.Equals(productName)
                             select productVendor.Vendor.Name).First();

            return result;
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            Table<ProductReview> productReviews = dataContext.GetTable<ProductReview>();
            List<Product> result = (from productReview in productReviews
                                    orderby productReview.ReviewDate descending
                                    select productReview.Product).Take(howManyReviews).ToList();

            return result.Distinct().ToList();
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            Table<ProductReview> productReviews = dataContext.GetTable<ProductReview>();
            List<Product> result = (from productReview in productReviews
                                    orderby productReview.ReviewDate descending
                                    group productReview.Product by productReview.ProductID into g
                                    select g.First()).Take(howManyProducts).ToList();

            return result;
        }

        public static List<Product> GetNProductFromCategory(string categoryName, int n)
        {
            Table<Product> products = dataContext.GetTable<Product>();
            List<Product> result = (from product in products
                                    orderby product.Name
                                    where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                    select product).Take(n).ToList();

            return result;
        }

        public static decimal GetTotalStandardCostByCategory(ProductCategory category)
        {
            Table<Product> products = dataContext.GetTable<Product>();
            decimal result = (from product in products
                              where product.ProductSubcategory.ProductCategory.Equals(category)
                              select product.StandardCost).Sum();

            return result;
        }

        public static ProductCategory getCategoryFromString(String categoryName)
        {
            Table<ProductCategory> categories = dataContext.GetTable<ProductCategory>();
            ProductCategory result = (from category in categories 
                                      where category.Name.Equals(categoryName) 
                                      select category).First();
            return result;
        }
    }
}
