using System.Collections.Generic;

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

    }
}
