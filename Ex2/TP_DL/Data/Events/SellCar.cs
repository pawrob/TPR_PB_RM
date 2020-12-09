using System;
using System.Runtime.Serialization;

namespace TP_DL.Objects
{
    public class SellCar : Event, ISerializable

    {
        public Client Client;
        public WarehouseItem CarCopy;


        public SellCar(Client client, WarehouseItem carCopy, Guid id, DateTimeOffset soldTime) : base(id, soldTime)
        {
            Client = client;
            CarCopy = carCopy;
        }

/*        public SellCar(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            CarCopy = (WarehouseItem)info.GetValue("CarCopy", typeof(WarehouseItem));
            Client = (Client)info.GetValue("Client", typeof(Client));
        }*/

        public override string ToString()
        {
            return "Bought by: "+ Client + ", Car: " + CarCopy.Car.Model + ", Id: " + Id + ", Date of bought: " + eventDate;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id, typeof(Guid));
            info.AddValue("eventDate", eventDate);
            info.AddValue("CarCopy", CarCopy, typeof(WarehouseItem));
            info.AddValue("Client", Client, typeof(Client));
        }

    }
}
