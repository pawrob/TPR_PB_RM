using System.Collections.Generic;

namespace TP_LINQ.MyProduct
{
    public interface IMyProductContext<MyProduct>
    {
        void Add(MyProduct myProduct);

        void Add(List<MyProduct> listOfMyProducts);

        List<MyProduct> GetAll();
    }
}
