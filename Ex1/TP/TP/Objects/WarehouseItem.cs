using System;
using System.Collections.Generic;
using System.Text;

namespace TP.Objects
{
    public class WarehouseItem
    {
       
        public Guid Id  { get; set; }
        public Car Car { get; set; }
        public decimal Price { get; set; }

        public WarehouseItem(Car car, decimal price)
        {
            this.Id = Guid.NewGuid();
            this.Car = car;
            this.Price = price;
        }

        public override string ToString()
        {
            return "Car: " + Car.Model + " Car Id: " + Id;
        }
        public override bool Equals(object obj)
        {
            return obj is WarehouseItem stock &&
                   Id.Equals(stock.Id) &&
                   EqualityComparer<Car>.Default.Equals(Car, stock.Car) &&
                   Price == stock.Price;
        }
    }
}
