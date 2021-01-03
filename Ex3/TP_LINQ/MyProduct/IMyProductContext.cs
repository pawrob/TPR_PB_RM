using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LINQ.MyProduct
{
    public interface IMyProductContext<MyProduct>
    {
        void Add(MyProduct myProduct);

        void Add(List<MyProduct> listOfMyProducts);

        MyProduct GetMyProduct(int id);

        List<MyProduct> GetAll();
    }
}
