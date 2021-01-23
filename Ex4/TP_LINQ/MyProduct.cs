using System.Data.Linq;

namespace TP_LINQ.MyProduct
{
    public class MyProduct
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public int SafetyStockLevel { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public decimal? Weight { get; set; }

        public MyProduct(Product product)
        {
            this.ProductID = product.ProductID;
            this.Name = product.Name;
            this.ProductNumber = product.ProductNumber;
            this.Color = product.Color;
            this.SafetyStockLevel = product.SafetyStockLevel;
            this.StandardCost = product.StandardCost;
            this.ListPrice = product.ListPrice;
            this.Size = product.Size;
            this.Weight = product.Weight;
        }

    }

}
