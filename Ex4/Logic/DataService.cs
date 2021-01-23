using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using TP_WPF.Data;

namespace Logic
{
    public static class DataService
    {
        private static DataClassesDataContext dataContext = new DataClassesDataContext();


        #region 3 - QueryMethods
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

        public static List<Product> GetAllProducts()
        {
            Table<Product> products = dataContext.GetTable<Product>();
            List<Product> result = (from product in products
                                    select product).ToList();
            return result;
        }

        public static List<ProductVendor> GetAllProductVendors()
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

        public static ProductCategory getCategoryFromString(string categoryName)
        {
            Table<ProductCategory> categories = dataContext.GetTable<ProductCategory>();
            ProductCategory result = (from category in categories 
                                      where category.Name.Equals(categoryName)
                                      select category).First();
            return result;
        }
        #endregion

        #region 4 - ExtensionMethods

        public static List<Product> GetProductsWithoutCategoryQS(this List<Product> products)
        {
            List<Product> result = (from product in products
                                    where product.ProductSubcategoryID == null
                                    select product).ToList();
            return result;
        }

        public static List<Product> GetProductsWithoutCategoryMS(this List<Product> products)
        {
            return products.Where(product => product.ProductSubcategoryID == null).ToList();
        }
        public static List<Product> SplitProductsIntoPages(this List<Product> products, int pageSize, int pageNumber)
        {
            //metoda pomija elementy ktore znajdują sie na poprzenich stronach oraz wybiera ze wskazanej strony zadana ilosc elementów
            return products.Skip(pageNumber * pageSize).Take(pageSize).ToList();
        }


        public static string ListProductsWithVendors(this List<Product> products, List<ProductVendor> productVendors)
        {
            var result = (from product in products
                          from productVendor in productVendors
                          where product.ProductID.Equals(productVendor.ProductID)
                          select new { productName = product.Name, productVendorName = productVendor.Vendor.Name }).ToList();

            string listOfProductsAndVendors = "";
            foreach (var item in result)
            {
                listOfProductsAndVendors += item.productName + " - " + item.productVendorName + "\n";
            }

            return listOfProductsAndVendors;
        }
        #endregion
    }
}
