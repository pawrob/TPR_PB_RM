using System;
using System.Collections.Generic;
using System.Linq;
using TP_DL;
using TP_DL.Objects;

namespace TP_LL
{
    public class DataService : IDataService
    {

        private IDataRepository dataRepository;



        public DataService(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public void AddCar(string make, string model, string variant, int horsepower, string color, VehicleType vehicleType, FuelType fueltype, Transmission transmission)
        {
            dataRepository.AddCar(new Car(make, model, variant, horsepower, color, vehicleType, fueltype, transmission));
        }

        public void AddClient(string firstName, string lastName, long phoneNumber)
        {
            dataRepository.AddClient(new Client(firstName, lastName, phoneNumber,new Guid()));
        }

        public void AddFacture(Client client, WarehouseItem warehouseItem)
        {
            dataRepository.AddFacture(new Facture(client, warehouseItem, new Guid(), DateTime.Now));
        }

        public void AddBill(WarehouseItem warehouseItem)
        {
            dataRepository.AddBill(new BillOfSale(warehouseItem, new Guid(), DateTime.Now));
        }

        public void AddWarehouseItem(Car car, decimal price)
        {
            dataRepository.AddWarehouseItem(new WarehouseItem(car, price, new Guid()));
        }

        public void DeleteClient(Client client)
        {
            dataRepository.DeleteClient(client);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return dataRepository.GetAllCars();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return dataRepository.GetAllClients();
        }

        public IEnumerable<Facture> GetAllFactures()
        {
            return dataRepository.GetAllFactures();
        }
        public IEnumerable<BillOfSale> GetAllBills()
        {
            return dataRepository.GetAllBillesOfSale();
        }

        public IEnumerable<WarehouseItem> GetAllWarehouseItems()
        {
            return dataRepository.GetAllWarehouseItems();
        }

        public Car GetCar(Guid id)
        {
            return dataRepository.GetCar(id);
        }

        public Client GetClient(Guid id)
        {
            return dataRepository.GetClient(id);
        }

        public Facture GetFacture(Guid id)
        {
            return dataRepository.GetFacture(id);
        }

        public BillOfSale GetBill(Guid id)
        {
            return dataRepository.GetBill(id);
        }

        public WarehouseItem GetWarehouseItem(Guid id)
        {
            return dataRepository.GetWarehouseItem(id);
        }

        public void DeleteCar(Car car)
        {
            if (dataRepository.GetAllWarehouseItems().FirstOrDefault(c => c.Equals(car)) != default)
            {
                throw new ArgumentException("There is a reference to car!");
            }
            dataRepository.DeleteCar(car);
        }

        public void DeleteFacture(Facture facture)
        {
            dataRepository.DeleteFacture(facture);
        }

        public void DeleteBill(BillOfSale bill)
        {
            dataRepository.DeleteBill(bill);
        }

        public void DeleteWarehouseItem(WarehouseItem warehouseItem)
        {
            dataRepository.DeleteWarehouseItem(warehouseItem);
        }

        public void updateCar(Guid id, Car car)
        {
            dataRepository.UpdateCar(id, car);
        }

        public void updateClient(Guid id, Client client)
        {
            dataRepository.UpdateClient(id, client);
        }

        public void updateFacture(Guid id, Facture facture)
        {
            dataRepository.UpdateFacture(id, facture);
        }

        public void updateBill(Guid id, BillOfSale bill)
        {
            dataRepository.UpdateBill(id, bill);
        }

        public void updateWarehouseItem(Guid id, WarehouseItem warehouseItem)
        {
            dataRepository.UpdateWarehouseItem(id, warehouseItem);
        }








       
    }
}
