using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LINQ
{
    public static class ExtensionMethods
    {
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
    }
}
