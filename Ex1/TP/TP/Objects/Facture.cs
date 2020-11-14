using System;
using System.Collections.Generic;
using System.Text;

namespace TP.Objects
{
    public class Facture

    {
        public Client Client;
        public WarehouseItem CarCopy;
        public Guid Id { get; }
        public DateTimeOffset BoughtTime { get; }


        public Facture(Client client, WarehouseItem warehouseItem)
        {
            Client = client;
            CarCopy = warehouseItem;
            Id = Guid.NewGuid();
            BoughtTime = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return Client + " " + CarCopy + " " + Id + "Data zakupu: " + BoughtTime;
        }

        /*        public override bool Equals(object obj)
                {
                    return obj is Facture facture &&
                           EqualityComparer<Client>.Default.Equals(Client, facture.Client) &&
                           EqualityComparer<Stock>.Default.Equals(CarCopy, facture.CarCopy) &&
                           Id.Equals(facture.Id) &&
                           BoughtTime.Equals(facture.BoughtTime);
                }*/
    }
}
