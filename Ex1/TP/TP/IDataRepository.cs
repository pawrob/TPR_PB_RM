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
        public Car GetCar(Guid id);
        public IEnumerable<Car> GetAllCars();
        public void UpdateCar(Guid id, Car car);
        public void DeleteCar(Car car);

        //client
        public void AddClient (Client client);
        public Client GetClient(Guid id);
        public IEnumerable<Client> GetAllClients();
        public void UpdateClient(Guid id, Client client);
        public void DeleteClient(Client client);

        //facture
        public void AddFacture(Facture facture);
        public Facture GetFacture(Guid id);
        public IEnumerable<Facture> GetAllFactures();
        public void UpdateFacture(Guid id, Facture facture);
        public void DeleteFacture(Facture facture);

        //stock
        public void AddWarehouseItem(WarehouseItem warehouseItem);
        public WarehouseItem GetWarehouseItem(Guid id);
        public IEnumerable<WarehouseItem> GetAllWarehouseItems();
        public void UpdateWarehouseItem(Guid id, WarehouseItem warehouseItem);
        public void DeleteWarehouseItem(WarehouseItem warehouseItem);
    }
}
