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
        public void AddFacture(SellCar facture);
        public SellCar GetFacture(Guid id);
        public IEnumerable<SellCar> GetAllFactures();
        public void UpdateFacture(Guid id, SellCar facture);
        public void DeleteFacture(SellCar facture);

        //BillOfSale
        public void AddBill(BuyCar bill);
        public BuyCar GetBill(Guid id);
        public IEnumerable<BuyCar> GetAllBillesOfSale();
        public void UpdateBill(Guid id, BuyCar bill);
        public void DeleteBill(BuyCar bill);


        //stock
        public void AddWarehouseItem(WarehouseItem warehouseItem);
        public WarehouseItem GetWarehouseItem(Guid id);
        public IEnumerable<WarehouseItem> GetAllWarehouseItems();
        public void UpdateWarehouseItem(Guid id, WarehouseItem warehouseItem);
        public void DeleteWarehouseItem(WarehouseItem warehouseItem);
    }
}
