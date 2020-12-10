using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

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

        public override bool Equals(object obj)
        {
            return obj is SellCar car &&
                   Id.Equals(car.Id) &&
                   EqualityComparer<Client>.Default.Equals(Client, car.Client) &&
                   EqualityComparer<WarehouseItem>.Default.Equals(CarCopy, car.CarCopy);
        }

        public override string ToString()
        {
            return "Bought by: "+ Client + ", Car: " + CarCopy.Car.Model + ", Id: " + Id + ", Date of bought: " + eventDate;
        }



    }
}
