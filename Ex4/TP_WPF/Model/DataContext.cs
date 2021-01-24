﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using Logic;

namespace Model
{
    public class DataContext
    {
        public IMyProductContextCRUD dataService { get; set; }
        public ObservableCollection<MyProduct> products { get; set; }

        public DataContext()
        {
            this.dataService = new MyProductContextCRUD();
            products = convertData(dataService.getAll());
        }
        public DataContext(IMyProductContextCRUD dataService)
        {
            this.dataService = dataService;
            products = convertData(dataService.getAll());
        }


        public void setDataService(object obj)
        {
            this.dataService = (IMyProductContextCRUD)obj;
        }

        private ObservableCollection<MyProduct> convertData(List<Dictionary<String, String>> data)
        {
            ObservableCollection<MyProduct> converted = new ObservableCollection<MyProduct>();
            foreach (Dictionary<String, String> currentProduct in data)
            {
                decimal number = Decimal.Parse(currentProduct["StandardCost"]);
                decimal? val = Decimal.TryParse(currentProduct["Weight"], out var tempVal) ? tempVal : (decimal?)0;
                /*int productID, string name, string productNumber, string color, short safetyStockLevel, decimal standardCost, string size, decimal? weight*/
                // MyProduct p = new MyProduct(Int32.Parse(currentProduct["ProductID"]), currentProduct["Name"], currentProduct["ProductNumber"], currentProduct["Color"], short.Parse(currentProduct["SafetyStockLevel"], CultureInfo.CurrentCulture), decimal.Parse(currentProduct["StandardCost"], CultureInfo.CurrentCulture), currentProduct["Size"], decimal.Parse(currentProduct["Weight"], CultureInfo.CurrentCulture));
                MyProduct p = new MyProduct(Int32.Parse(currentProduct["ProductID"]), currentProduct["Name"], currentProduct["ProductNumber"], currentProduct["Color"], short.Parse(currentProduct["SafetyStockLevel"]), number, currentProduct["Size"], (decimal)val);
                converted.Add(p);
            }
            return converted;
        }

        public string addProduct(MyProduct product)
        {
            string message = dataService.addProduct(product.Name, product.ProductNumber, product.Color,  product.SafetyStockLevel, product.StandardCost, product.Size, product.Weight);
            products = convertData(dataService.getAll());
            return message;
        }
        public string removeProduct(String name)
        {
            string message = dataService.removeProduct(name);
            products = convertData(dataService.getAll());
            return message;
        }
        public string updateProduct(MyProduct product)
        {
            string message = "";
            try
            {
                message = dataService.updateProduct(product.ProductID, product.Name, product.ProductNumber, product.Color, product.SafetyStockLevel, product.StandardCost, product.Size, product.Weight);
                products = convertData(dataService.getAll());
            }
            catch (NullReferenceException)
            {
                return "Firstly add product";
            }
            return message;
        }
    }
}
