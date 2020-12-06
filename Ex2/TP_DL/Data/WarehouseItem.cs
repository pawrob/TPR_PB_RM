using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TP_DL.Objects
{
    public class WarehouseItem : ISerializable
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

        public WarehouseItem(SerializationInfo info, StreamingContext context)
        {
            Car = (Car)info.GetValue("Car", typeof(Car));
            Price = info.GetDecimal("Price");

            Id = (Guid)info.GetValue("Id", typeof(Guid));
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
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Car", Car, typeof(Car));
            info.AddValue("Price", Price);
            info.AddValue("Id", Id, typeof(Guid));
        }
    }
}
