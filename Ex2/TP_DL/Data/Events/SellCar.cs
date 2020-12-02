using System;

namespace TP_DL.Objects
{
    public class SellCar : Event

    {
        public Client Client;
        public WarehouseItem CarCopy;


        public SellCar(Client client, WarehouseItem carCopy, Guid id, DateTimeOffset soldTime) : base(id, soldTime)
        {
            Client = client;
            CarCopy = carCopy;
        }

        public override string ToString()
        {
            return "Bought by: "+ Client + ", Car: " + CarCopy.Car.Model + ", Id: " + Id + ", Date of bought: " + eventDate;
        }

    }
}
