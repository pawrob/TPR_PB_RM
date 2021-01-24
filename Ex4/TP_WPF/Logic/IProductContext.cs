using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IProductContext
    {
        string addProduct(string name, string productNumber, string color, short safetyStockLevel, decimal standardCost, string size, decimal? weight);
        string removeProduct(String name);
        string updateProduct(int productID, string name, string productNumber, string color, short safetyStockLevel, decimal standardCost, string size, decimal? weight);
        List<Dictionary<String, String>> getAll();
    }
}
