using System;
using System.Collections.Generic;
using System.Linq;
using TP_DL.Objects;

namespace TP_DL
{
    public class DataRepository : IDataRepository
    {

        private DataContext dataContext;
        private IDataFiller dataFiller = null;

        public IDataFiller DataFiller { get => dataFiller; set => dataFiller = value; }
        public DataRepository()
        {
            dataContext = new DataContext();
        }

        public void FillData()
        {
            if (dataFiller != null)
            {
                dataFiller.InsertData(dataContext);
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
   

        public void AddFacture(Facture facture)
        {
            try
            {
                dataContext.Factures.Add(facture);
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

        public void DeleteFacture(Facture facture)
        {
            if (dataContext.Factures.Contains(facture))
            {
                dataContext.Factures.Remove(facture);
            }
            else
            {
                throw new ArgumentException($"There isn't facture with {facture.Id} id in warehouse");
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

        public IEnumerable<Facture> GetAllFactures()
        {
            return dataContext.Factures;
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

        public Facture GetFacture(Guid id)
        {
            if (dataContext.Factures.Count != 0)
            {

                return dataContext.Factures.First(f => f.Id.Equals(id));
            }
            else
            {
                throw new ArgumentNullException($"There isn't facture with {id} id");
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

        public void UpdateFacture(Guid id, Facture facture)
        {
            Facture foundFacture = dataContext.Factures.First(f => f.Id.Equals(id)); 
            if (foundFacture == null)
            {
                throw new ArgumentException($"Facture with {id} id doesn't exist");
            }
            dataContext.Factures[dataContext.Factures.IndexOf(foundFacture)] = facture;
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
