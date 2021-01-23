using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace Logic
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

        public bool Update(MyProduct item)
        {
            MyProduct myProduct = (from product in MyProducts
                                   where product.ProductID.Equals(item.ProductID)
                                   select product).Single();
            if (myProduct != null)
            {
                myProduct.Name = item.Name;
                myProduct.ProductNumber = item.ProductNumber;
                myProduct.ProductReview = item.ProductReview;
                myProduct.ProductSubcategory = item.ProductSubcategory;
                myProduct.Size = item.Size;
                myProduct.Weight = item.Weight;
                myProduct.Color = item.Color;
                myProduct.SafetyStockLevel = item.SafetyStockLevel;
                myProduct.StandardCost = item.StandardCost;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            return MyProducts.Remove((from product in MyProducts
                                      where product.ProductID.Equals(id)
                                      select product).Single());
        }
    }
}
