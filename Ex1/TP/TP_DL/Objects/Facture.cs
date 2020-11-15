using System;

namespace TP_DL.Objects
{
    public class Facture

    {
        public Client Client;
        public WarehouseItem CarCopy;
        public Guid Id { get; }
        public DateTimeOffset BoughtTime { get; }

        public Facture(Client client, WarehouseItem carCopy, Guid id, DateTimeOffset boughtTime)
        {
            Client = client;
            CarCopy = carCopy;
            Id = id;
            BoughtTime = boughtTime;
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
