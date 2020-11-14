using System;
using System.Collections.Generic;
using System.Text;
using TP.Objects;

namespace TP
{
    public interface IDataRepository
    {
        //car
        public void AddCar(Car car);
        public Car GetCar(Guid id);//czy int ?
        public IEnumerable<Car> GetAllCars();
        public void UpdateCar(Guid id, Car car);
        public void DeleteCar(Car car);

        //client
        public void AddClient (Client client);
        public Client GetClient(Guid id);//czy int ?
        public IEnumerable<Client> GetAllClients();
        public void UpdateClient(Guid id, Client client);
        public void DeleteClient(Client client);

        //facture
        public void AddFacture(Facture facture);
        public Facture GetFacture(Guid id);//czy int ?
        public IEnumerable<Facture> GetAllFactures();
        /*public void UpdateFacture(Guid id, Facture facture);*/
        public void DeleteFacture(Facture facture);

        //stock
        public void AddStock(Stock stock);
        public Stock GetStock(Guid id);//czy int ?
        public IEnumerable<Stock> GetAllStockss();
        public void UpdateStock(Guid id, Stock stock);
        public void DeleteStock(Stock stock);
    }
}
