namespace Model
{
    public class MyProduct
    {

        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public decimal StandardCost { get; set; }
        public string Size { get; set; }
        public System.Nullable<decimal>Weight { get; set; }


        public MyProduct(int productID, string name, string productNumber, string color, short safetyStockLevel, decimal standardCost, string size, decimal weight)
        {
            this.ProductID = productID;
            this.Name = name;
            this.ProductNumber = productNumber;
            this.Color = color;
            this.SafetyStockLevel = safetyStockLevel;
            this.StandardCost = standardCost;
            this.Size = size;
            this.Weight = weight;
        }

    }
}
