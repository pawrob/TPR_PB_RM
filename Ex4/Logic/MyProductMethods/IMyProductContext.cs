using System.Collections.Generic;

namespace Logic.MyProduct
{
    public interface IMyProductContext<MyProduct>
    {
        void Add(MyProduct myProduct);

        void Add(List<MyProduct> listOfMyProducts);

        List<MyProduct> GetAll();

        bool Update(MyProduct item);

        bool Delete(int id);
    }
}
