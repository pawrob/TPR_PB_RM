using System;
using System.Collections.Generic;
using System.Text;

namespace TP.Objects
{
    public class Facture

    {
        public Client Client;
        public Stock CarCopy;
        public Guid Id { get; set; }
        public DateTimeOffset BoughtTime { get; set; }


        public Facture(Client client, Stock carCopy, DateTimeOffset boughtTime)
        {
            Client = client;
            CarCopy = carCopy;
            Id = Guid.NewGuid();
            BoughtTime = DateTime.UtcNow;
        }
        public override string ToString()
        {
            return Client + " " + CarCopy + " " + Id + "Data zakupu: " + BoughtTime;
        }
        public override bool Equals(object obj)
        {
            return obj is Facture facture &&
                   EqualityComparer<Client>.Default.Equals(Client, facture.Client) &&
                   EqualityComparer<Stock>.Default.Equals(CarCopy, facture.CarCopy) &&
                   Id.Equals(facture.Id) &&
                   BoughtTime.Equals(facture.BoughtTime);
        }
    }
}
