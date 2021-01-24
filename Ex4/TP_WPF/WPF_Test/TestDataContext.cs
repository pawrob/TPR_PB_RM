using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Test
{
    public class TestDataContext : IProductContext
    {
        public List<MyProduct> dataContext { get;  private set; }
        
        public TestDataContext(InitData initData)
        {
            dataContext = initData.myProducts;
        }

        public TestDataContext()
        {
            dataContext =  new List<MyProduct>();
        }
    
        private readonly Random random = new Random();
        public string addProduct(string name, string productNumber, string color, short safetyStockLevel, decimal standardCost, string size, decimal? weight)
        {
            MyProduct p = new MyProduct(random.Next(10000), name, productNumber, color, safetyStockLevel, standardCost, size, weight);
            try
            {
                dataContext.Add(p);
            }
            catch (Exception e)
            {
                return "Product already exists in database";
            }
            return "Product sucessfuly added";
        }

        public string removeProduct(String name)
        {  
            try
            {
                MyProduct foundProduct = dataContext.Find(p => p.Name.Equals(name));
                dataContext.Remove(foundProduct);
            }
            catch (Exception e)
            {
                return "Product doesn't exists";
            }
            return "Product removed";
        }

        public List<Dictionary<string, string>> getAll()
        {
            List<MyProduct> products = dataContext;
            List<Dictionary<string, string>> outputData = new List<Dictionary<string, string>>();
            foreach (MyProduct p in products)
            {
                Dictionary<String, String> currentProductData = new Dictionary<string, string>();
                currentProductData.Add("ProductID", p.ProductID.ToString());
                currentProductData.Add("Name", p.Name);
                currentProductData.Add("ProductNumber", p.ProductNumber);
                if (p.Color == null)
                    currentProductData.Add("Color", "Unknown");
                else
                    currentProductData.Add("Color", p.Color);
                currentProductData.Add("SafetyStockLevel", p.SafetyStockLevel.ToString());
                currentProductData.Add("StandardCost", p.StandardCost.ToString());
                currentProductData.Add("Size", p.Size);
                currentProductData.Add("Weight", p.Weight.ToString());
                outputData.Add(currentProductData);
            }
            return outputData;
        }

        public string updateProduct(int productID, string name, string productNumber, string color, short safetyStockLevel, decimal standardCost, string size, decimal? weight)
        {
            try
            {
                MyProduct foundProduct = dataContext.Find(p => p.ProductID.Equals(productID));
                foundProduct.Name = name;
                foundProduct.ProductNumber = productNumber;
                foundProduct.Color = color;
                foundProduct.SafetyStockLevel = safetyStockLevel;
                foundProduct.StandardCost = standardCost;
                foundProduct.Size = size;
                foundProduct.Weight = weight;
            }
            catch (Exception e)
            {
                return "Product doesn't exists";
            }
            return "Product updated";
        }
    }
}
