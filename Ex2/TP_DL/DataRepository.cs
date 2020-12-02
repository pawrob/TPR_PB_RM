using System;
using System.Collections.Generic;
using System.Linq;
using TP_DL.Objects;

namespace TP_DL
{
    public class DataRepository : IDataRepository
    {

        private DataContext dataContext;
        public IDataFiller DataFiller = null;


        public DataRepository(IDataFiller dataFiller)
        {
            this.DataFiller = dataFiller;
            this.dataContext = new DataContext();
        }

        public void FillData()
        {
            if (DataFiller != null)
            {
                DataFiller.InsertData(dataContext);
            }
            else {
                throw new Exception($"Data filler is not specyfied.");
            }

        }

        // ADD METHODS
        public void AddCar(Car car)
        {
           
            try
            {
                Guid g = new Guid();
                car.Id = g;
                dataContext.Cars.Add(g, car);
                

            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException($"Car with Id {car.Id} do not exist.", e);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException($"Car with Id {car.Id} already exists.", e);
            }
        }

        public void AddClient(Client client)
        {
            try
            {
                dataContext.Clients.Add(client);
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException($"Client with Id {client.Id} do not exist.", e);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException($"Client with Id {client.Id} already exists.", e);
            }
        }
   

        public void AddFacture(SellCar facture)
        {
            try
            {
                dataContext.SoldCars.Add(facture);
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException($"Facture with Id {facture.Id} do not exist.", e);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException($"Facture with Id {facture.Id} already exists.", e);
            }
        }

        public void AddBill(BuyCar bill)
        {
            try
            {
                dataContext.BoughtCars.Add(bill);
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException($"Bill with Id {bill.Id} do not exist.", e);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException($"Bill with Id {bill.Id} already exists.", e);
            }
        }

        public void AddWarehouseItem(WarehouseItem warehouseItem)
        {
            try
            {
                dataContext.WarehouseItems.Add(warehouseItem);
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException($"Warehouse item with Id {warehouseItem.Id} do not exist.", e);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException($"Warehouse item with Id {warehouseItem.Id} already exists.", e);
            }
        }

        //DELETE METHODS
        public void DeleteCar(Car car)
        {
            if (dataContext.Cars.ContainsKey(car.Id))
            {
                dataContext.Cars.Remove(car.Id);
            }
            else
            {
                throw new ArgumentException($"There isn't car with {car.Id} id in warehouse");
            }
        }

        public void DeleteClient(Client client)
        {
            if (dataContext.Clients.Contains(client))
            {
                dataContext.Clients.Remove(client);
            }
            else
            {
                throw new ArgumentException($"There isn't client with {client.Id} id in warehouse");
            }
        }

        public void DeleteFacture(SellCar facture)
        {
            if (dataContext.SoldCars.Contains(facture))
            {
                dataContext.SoldCars.Remove(facture);
            }
            else
            {
                throw new ArgumentException($"There isn't facture with {facture.Id} id in warehouse");
            }
        }
        public void DeleteBill(BuyCar bill)
        {
            if (dataContext.BoughtCars.Contains(bill))
            {
                dataContext.BoughtCars.Remove(bill);
            }
            else
            {
                throw new ArgumentException($"There isn't bill with {bill.Id} id in warehouse");
            }
        }

        public void DeleteWarehouseItem(WarehouseItem warehouseItem)
        {
            if (dataContext.WarehouseItems.Contains(warehouseItem))
            {
                dataContext.WarehouseItems.Remove(warehouseItem);
            }
            else
            {
                throw new ArgumentException($"There isn't item with {warehouseItem.Id} id in warehouse");
            }
        }
        //GET ALL METHODS
        public IEnumerable<Car> GetAllCars()
        {
           return dataContext.Cars.Values;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return dataContext.Clients;
        }

        public IEnumerable<SellCar> GetAllFactures()
        {
            return dataContext.SoldCars;
        }

        public IEnumerable<BuyCar> GetAllBillesOfSale()
        {
            return dataContext.BoughtCars;
        }

        public IEnumerable<WarehouseItem> GetAllWarehouseItems()
        {
            return dataContext.WarehouseItems;
        }

        // GET METHODS
        public Car GetCar(Guid id)
        {
            if (dataContext.Cars.Count != 0)
            {
                return dataContext.Cars[id];
            }
            else
            {
                throw new ArgumentNullException($"There isn't car with {id} id in warehouse");
            }  
        }

        public Client GetClient(Guid id)
        {
            if (dataContext.Clients.Count != 0)
            {
                return dataContext.Clients.Find(client => client.Id.Equals(id));
            }
            else
            {
                throw new ArgumentNullException($"There isn't client with {id} id");
            }   
        }

        public SellCar GetFacture(Guid id)
        {
            if (dataContext.SoldCars.Count != 0)
            {

                return dataContext.SoldCars.First(f => f.Id.Equals(id));
            }
            else
            {
                throw new ArgumentNullException($"There isn't facture with {id} id");
            }
        }

        public BuyCar GetBill(Guid id)
        {
            if (dataContext.BoughtCars.Count != 0)
            {

                return dataContext.BoughtCars.First(b => b.Id.Equals(id));
            }
            else
            {
                throw new ArgumentNullException($"There isn't bill with {id} id");
            }
        }

        public WarehouseItem GetWarehouseItem(Guid id)
        {

            if (dataContext.WarehouseItems.Count != 0)
            {
                return dataContext.WarehouseItems.Find(item => item.Id.Equals(id));
            }
            else
            {
                throw new ArgumentNullException($"There isn't warehouse item with {id} id");
            }
        }


        //UPDATE METHODS
        public void UpdateCar(Guid id, Car car)
        {
            if (!dataContext.Cars.ContainsKey(id))
            {
                throw new ArgumentException($"Car with {id} id doesn't exist");
            }
            dataContext.Cars[id] = car;
        }


        public void UpdateClient(Guid id, Client client)
        {
            Client foundClient = dataContext.Clients.Find(client => client.Id.Equals(id));
            if (foundClient == null)
            {
                throw new ArgumentException($"Client with {id} id doesn't exist");
            }
            dataContext.Clients[dataContext.Clients.IndexOf(foundClient)] = client;
        }

        public void UpdateFacture(Guid id, SellCar facture)
        {
            SellCar foundFacture = dataContext.SoldCars.First(f => f.Id.Equals(id)); 
            if (foundFacture == null)
            {
                throw new ArgumentException($"Facture with {id} id doesn't exist");
            }
            dataContext.SoldCars[dataContext.SoldCars.IndexOf(foundFacture)] = facture;
        }

        public void UpdateBill(Guid id,BuyCar bill)
        {
            BuyCar foundBill = dataContext.BoughtCars.First(f => f.Id.Equals(id));
            if (foundBill== null)
            {
                throw new ArgumentException($"Bill with {id} id doesn't exist");
            }
            dataContext.BoughtCars[dataContext.BoughtCars.IndexOf(foundBill)] = bill;
        }

        public void UpdateWarehouseItem(Guid id, WarehouseItem warehouseItem)
        {
            WarehouseItem foundStock = dataContext.WarehouseItems.Find(stock => stock.Id.Equals(id));
            if (foundStock == null)
            {
                throw new ArgumentException($"Item with {id} id doesn't exist");
            }
            dataContext.WarehouseItems[dataContext.WarehouseItems.IndexOf(foundStock)] = warehouseItem;
        }
    }
}
