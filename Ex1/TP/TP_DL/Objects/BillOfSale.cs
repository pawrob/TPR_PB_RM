using System;

namespace TP_DL.Objects
{
    public class BillOfSale : PaymentType
    {

        public Client Client;
        public WarehouseItem CarCopy;
        public Guid Id { get; }
        public DateTimeOffset BoughtTime { get; }

        public BillOfSale( WarehouseItem carCopy, Guid id, DateTimeOffset boughtTime) : base(id, boughtTime)
        {
            CarCopy = carCopy;
            Id = id;
            BoughtTime = boughtTime;
        }

        public override string ToString()
        {
            return "Bought by: " + Client + ", Car: " + CarCopy.Car.Model + ", Id: " + Id + ", Date of bought: " + BoughtTime;
        }
    }
}
