using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LINQ.MyProduct
{
    public class MyProductContext : IMyProductContext<MyProduct>
    {
        public List<MyProduct> MyProducts { get; set; }

        public MyProductContext()
        {
            MyProducts = new List<MyProduct>();
        }

        public void Add(MyProduct myProduct)
        {
            MyProducts.Add(myProduct);
        }

        public void Add(List<MyProduct> listOfMyProducts)
        {
            MyProducts.AddRange(listOfMyProducts);
        }

        public List<MyProduct> GetAll()
        {
            return MyProducts;
        }

        public MyProduct GetMyProduct(int id)
        {
            MyProduct myProduct = (from product in MyProducts
                                   where product.ProductID.Equals(id)
                                   select product).Single();
            return myProduct;
        }

    }
}
