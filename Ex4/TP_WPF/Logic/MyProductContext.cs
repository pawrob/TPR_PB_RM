using Data;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class MyProductContext : IProductContext , IDisposable
    {
        private static AdventureWorksDataContext dataContext = new AdventureWorksDataContext();
        private  readonly Random random = new Random();
        public string addProduct(string name, string productNumber, string color, short safetyStockLevel, decimal standardCost, string size, decimal? weight)
        {
            Product p = new Product();
            p.ProductID = random.Next(10000);
            p.Name = name;
            p.ProductNumber = productNumber;
            p.Color = color;
            p.SafetyStockLevel = safetyStockLevel;
            p.StandardCost = standardCost;
            p.Size = size;
            p.Weight = weight;

            dataContext.Product.InsertOnSubmit(p);
            try
            {
                dataContext.SubmitChanges();
            }
            catch (Exception e)
            {
                dataContext.Product.DeleteOnSubmit(p);
                return "Product already exists in database";
            }
            return "Product sucessfuly added";
        }

        public string removeProduct(string name)
        {
            var remove = (from product in dataContext.Product
                          where product.Name.Equals(name)
                          select product).FirstOrDefault();

            if (remove != null)
            {
                dataContext.Product.DeleteOnSubmit(remove);
                try
                {
                    dataContext.SubmitChanges();
                }
                catch (Exception e)
                {
                    dataContext.Product.InsertOnSubmit(remove);
                    return "Product doesn't exists";
                }
            }
            return "Product removed";
        }

        public List<Dictionary<string, string>> getAll()
        {
            List<Product> products = QuerrySyntax.GetAllProducts();
            List<Dictionary<string, string>> outputData = new List<Dictionary<string, string>>();
            foreach (Product p in products)
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

        public Dictionary<string, string> getProduct(string name)
        {
            /*            List<Product> products = DataService.GetProductsByName(name);
                        Dictionary<String, String> product = new Dictionary<string, string>(, name);
                        return */
            throw new NotImplementedException();
        }

        public string updateProduct(int productID, string name, string productNumber, string color, short safetyStockLevel, decimal standardCost, string size, decimal? weight)
        {
            var update = (from p in dataContext.Product
                          where productID == p.ProductID
                          select p).SingleOrDefault();

            update.Name = name;
            update.ProductNumber = productNumber;
            update.Color = color;
            update.SafetyStockLevel = safetyStockLevel;
            update.StandardCost = standardCost;
            update.Size = size;
            update.Weight = weight;

            try
            {
                dataContext.SubmitChanges();
            }
            catch
            {
                return "Update unsucessful";
            }
            return "Update sucessful";
        }

        public void Dispose()
        {
            dataContext.Dispose();
        }
    }
}
