using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DataService : IDisposable
    {
        private static AdventureWorksDataContext dataContext = new AdventureWorksDataContext();


        #region 3 - QueryMethods
        public static Product GetProductByName(string productName)
        {
            Table<Product> products = dataContext.GetTable<Product>();
            IEnumerable<Product> result = (from product in products
                              where product.Name.Equals(productName)
                              select product);
            return result.First();
        }
        public static List<Product> GetProductsByName(string namePart)
        {
            Table<Product> products = dataContext.GetTable<Product>();
            IEnumerable<Product> result = (from product in products
                                    where product.Name.Contains(namePart)
                                    select product);

            return result.ToList();
        }

        public static List<Product> GetAllProducts()
        {
            Table<Product> products = dataContext.GetTable<Product>();
            IEnumerable<Product> result = (from product in products
                                           select product);
            
            return products.ToList();
        }

        public static List<ProductVendor> GetAllProductVendors()
        {
            Table<ProductVendor> vendors = dataContext.GetTable<ProductVendor>();
            IEnumerable<ProductVendor> result = (from vendor in vendors
                                          select vendor);
            return result.ToList();
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            Table<ProductVendor> productVendors = dataContext.GetTable<ProductVendor>();
            IEnumerable<Product> result = (from productVendor in productVendors
                                    where productVendor.Vendor.Name.Equals(vendorName)
                                    select productVendor.Product);
            return result.ToList();
        }

        
        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            Table<ProductVendor> productVendors = dataContext.GetTable<ProductVendor>();
            IEnumerable<string> result = (from productVendor in productVendors
                                   where productVendor.Vendor.Name.Equals(vendorName)
                                   select productVendor.Product.Name);
            return result.ToList();
        }

        public static string GetProductVendorByProductName(string productName)
        {
            Table<ProductVendor> productVendors = dataContext.GetTable<ProductVendor>();
            IEnumerable<string> result = (from productVendor in productVendors
                             where productVendor.Product.Name.Equals(productName)
                             select productVendor.Vendor.Name);
            return result.First();
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            Table<ProductReview> productReviews = dataContext.GetTable<ProductReview>();
            IEnumerable<Product> result = (from productReview in productReviews
                                    orderby productReview.ReviewDate descending
                                    select productReview.Product);
            return result.Distinct().Take(howManyReviews).ToList();
        }
       
        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            Table<ProductReview> productReviews = dataContext.GetTable<ProductReview>();
            IEnumerable<Product> result = (from productReview in productReviews
                                    orderby productReview.ReviewDate descending
                                    group productReview.Product by productReview.ProductID into g
                                    select g.First()).Take(howManyProducts);
            return result.ToList();
        }
       public static List<Product> GetNProductFromCategory(string categoryName, int n)
       {
           Table<Product> products = dataContext.GetTable<Product>();
           IEnumerable<Product> result = (from product in products
                                           orderby product.Name
                                           where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                           select product).Take(n);
           return result.ToList();
       }

       public static decimal GetTotalStandardCostByCategory(ProductCategory category)
       {
           Table<Product> products = dataContext.GetTable<Product>();
           IEnumerable<decimal> result = (from product in products
                             where product.ProductSubcategory.ProductCategory.Equals(category)
                             select product.StandardCost);
           return result.Sum();
       }

       public static ProductCategory getCategoryFromString(string categoryName)
       {
           Table<ProductCategory> categories = dataContext.GetTable<ProductCategory>();
           IEnumerable<ProductCategory> result = (from category in categories
                                     where category.Name.Equals(categoryName)
                                     select category);
           return result.First();
       }

        public void Dispose()
        {
            dataContext.Dispose();
        }
        #endregion
    }
}
