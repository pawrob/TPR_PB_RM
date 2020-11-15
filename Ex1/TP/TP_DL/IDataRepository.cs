using System;
using System.Collections.Generic;
using TP_DL.Objects;

namespace TP_DL
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

        //BillOfSale
        public void AddBill(BillOfSale bill);
        public BillOfSale GetBill(Guid id);
        public IEnumerable<BillOfSale> GetAllBillesOfSale();
        public void UpdateBill(Guid id, BillOfSale bill);
        public void DeleteBill(BillOfSale bill);


        //stock
        public void AddWarehouseItem(WarehouseItem warehouseItem);
        public WarehouseItem GetWarehouseItem(Guid id);
        public IEnumerable<WarehouseItem> GetAllWarehouseItems();
        public void UpdateWarehouseItem(Guid id, WarehouseItem warehouseItem);
        public void DeleteWarehouseItem(WarehouseItem warehouseItem);
    }
}
