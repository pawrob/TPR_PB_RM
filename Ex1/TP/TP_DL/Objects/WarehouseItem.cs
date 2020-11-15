using System;
using System.Collections.Generic;
using System.Text;

namespace TP.Objects
{
    public class WarehouseItem
    {
        public Car Car { get; set; }
        public decimal Price { get; set; }
        public Guid Id  { get; set; }

        public WarehouseItem(Car car, decimal price, Guid id)
        {
            Car = car;
            Price = price;
            Id = id;
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
