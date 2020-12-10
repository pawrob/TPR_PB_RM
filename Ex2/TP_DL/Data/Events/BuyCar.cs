using System;
using System.Runtime.Serialization;
namespace TP_DL.Objects
{
    public class BuyCar : Event
    {
        public WarehouseItem CarCopy;
        

        public BuyCar( WarehouseItem carCopy, Guid id, DateTimeOffset boughtTime) : base(id, boughtTime)
        {
            CarCopy = carCopy;
        }   

        public override string ToString()
        {
            return "Bought  Car: " + CarCopy.Car.Model + ", Id: " + Id+ ", Date of bought: " + eventDate;
        }

    }
}
