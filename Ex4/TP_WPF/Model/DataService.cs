using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using Logic;

namespace Model
{
    public class DataService
    {
        public IProductContext dataContext { get; set; }
        public ObservableCollection<MyProduct> products { get; set; }

        public DataService()
        {
            this.dataContext = new MyProductContext();
            products = convertData(dataContext.getAll());
        }
        public DataService(IProductContext dataContext)
        {
            this.dataContext = dataContext;
            products = convertData(dataContext.getAll());
        }


        public void setDataContext(object obj)
        {
            this.dataContext = (IProductContext)obj;
        }

        private ObservableCollection<MyProduct> convertData(List<Dictionary<String, String>> data)
        {
            ObservableCollection<MyProduct> converted = new ObservableCollection<MyProduct>();
            foreach (Dictionary<String, String> currentProduct in data)
            {
                decimal number = Decimal.Parse(currentProduct["StandardCost"]);
                decimal? val = Decimal.TryParse(currentProduct["Weight"], out var tempVal) ? tempVal : (decimal?)0;
                MyProduct p = new MyProduct(Int32.Parse(currentProduct["ProductID"]), currentProduct["Name"], currentProduct["ProductNumber"], currentProduct["Color"], short.Parse(currentProduct["SafetyStockLevel"]), number, currentProduct["Size"], (decimal)val);
                converted.Add(p);
            }
            return converted;
        }

        public string addProduct(MyProduct product)
        {
            string message = dataContext.addProduct(product.Name, product.ProductNumber, product.Color,  product.SafetyStockLevel, product.StandardCost, product.Size, product.Weight);
            products = convertData(dataContext.getAll());
            return message;
        }
        public string removeProduct(String name)
        {
            string message = dataContext.removeProduct(name);
            products = convertData(dataContext.getAll());
            return message;
        }
        public string updateProduct(MyProduct product)
        {
            string message = "";
            try
            {
                message = dataContext.updateProduct(product.ProductID, product.Name, product.ProductNumber, product.Color, product.SafetyStockLevel, product.StandardCost, product.Size, product.Weight);
                products = convertData(dataContext.getAll());
            }
            catch (NullReferenceException)
            {
                return "Firstly add product";
            }
            return message;
        }
    }
}
