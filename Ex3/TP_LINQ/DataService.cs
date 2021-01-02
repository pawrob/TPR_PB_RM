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

        public static List<Product> GetProductsByName(string namePart)
        {
            Table<Product> products = dataContext.GetTable<Product>();
            List<Product> result = (from product in products
                                    where product.Name.Contains(namePart)
                                    select product).ToList();

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
    }



}
