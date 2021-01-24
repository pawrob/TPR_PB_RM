using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Test
{
    class TestDataContext : IProductContext
    {
        public string addProduct(string name, string productNumber, string color, short safetyStockLevel, decimal standardCost, string size, decimal? weight)
        {
            throw new NotImplementedException();
        }

        public List<Dictionary<string, string>> getAll()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> getProduct(string name)
        {
            throw new NotImplementedException();
        }

        public string removeProduct(string name)
        {
            throw new NotImplementedException();
        }

        public string updateProduct(int productID, string name, string productNumber, string color, short safetyStockLevel, decimal standardCost, string size, decimal? weight)
        {
            throw new NotImplementedException();
        }
    }
}
