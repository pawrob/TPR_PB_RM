using System;
using System.Runtime.Serialization;
namespace TP_DL.Objects
{
    public class BuyCar : Event, ISerializable
    {
        public WarehouseItem CarCopy;
        

        public BuyCar( WarehouseItem carCopy, Guid id, DateTimeOffset boughtTime) : base(id, boughtTime)
        {
            CarCopy = carCopy;
        }

        public BuyCar(SerializationInfo info, StreamingContext context) : base(info, context)
        {   
            CarCopy = (WarehouseItem)info.GetValue("CarCopy", typeof(WarehouseItem));
        }
        

        public override string ToString()
        {
            return "Bought  Car: " + CarCopy.Car.Model + ", Id: " + Id+ ", Date of bought: " + eventDate;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CarCopy", CarCopy, typeof(WarehouseItem));
            info.AddValue("Id", Id, typeof(Guid));
            info.AddValue("eventDate", eventDate);

        }
    }
}
