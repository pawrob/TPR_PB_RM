using System.Collections.Generic;
using System.Linq;

namespace TP_LINQ.MyProduct
{
    public class MyProductService
    {
        private IMyProductContext<MyProduct> MyProductContext { get; set; }


        public MyProductService(IMyProductContext<MyProduct> MyProductContext)
        {
            this.MyProductContext = MyProductContext;
        }

        public List<MyProduct> GetProductsByName(string namePart)
        {
            List<MyProduct> products = MyProductContext.GetAll();
            List<MyProduct> result = (from product in products
                                      where product.Name.Contains(namePart)
                                      select product).ToList();
            return result;
        }

        public List<MyProduct> GetNMyProductFromCategory(string categoryName, int n)
        {
            List<MyProduct> products = MyProductContext.GetAll();
            List<MyProduct> result = (from product in products
                                      where product.ProductSubcategory != null && product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                      select product).Take(n).ToList();
            return result;
        }

        public decimal GetTotalStandardCostByCategory(ProductCategory category)
        {
            List<MyProduct> products = MyProductContext.GetAll();
            decimal result = (from product in products
                              where product.ProductSubcategory != null && product.ProductSubcategory.ProductCategory.Equals(category)
                              select product.StandardCost).Sum();
            return result;
        }
    }
}
