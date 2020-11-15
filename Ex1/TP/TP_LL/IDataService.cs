using System;
using System.Collections.Generic;
using TP_DL.Objects;

namespace TP_LL
{
    public interface IDataService
    {
        //Client
        void AddClient(string firstName, string lastName, long phoneNumber);
        void DeleteClient(Client client);
        IEnumerable<Client> GetAllClients();
        Client GetClient(Guid id);
        void updateClient(Guid id, Client client);

        //Car
        void AddCar(string make, string model, string variant, int horsepower, string color, VehicleType vehicleType, FuelType fueltype, Transmission transmission);
        void DeleteCar(Car car);
        IEnumerable<Car> GetAllCars();
        Car GetCar(Guid id);
        void updateCar(Guid id, Car car);

        //Facture
        void AddFacture(Client client, WarehouseItem warehouseItem);
        void DeleteFacture(Facture facture);
        IEnumerable<Facture> GetAllFactures();
        Facture GetFacture(Guid id);
        void updateFacture(Guid id, Facture facture);

        //WarehouseItem
        void AddWarehouseItem(Car car, decimal price);
        void DeleteWarehouseItem(WarehouseItem warehouseItem);
        IEnumerable<WarehouseItem> GetAllWarehouseItems();
        WarehouseItem GetWarehouseItem(Guid id);
        void updateWarehouseItem(Guid id, WarehouseItem warehouseItem);

    }
}
