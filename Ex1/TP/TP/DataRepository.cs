using System;
using System.Collections.Generic;
using System.Text;
using TP.Objects;

namespace TP
{
    public class DataRepository : IDataRepository
    {

        private DataContext dataContext = new DataContext();

        public DataRepository()
        {
            
        }

        public void AddCar(Car car)
        {
            try
            {
                dataContext.Cars.Add(car.Id, car);
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

        public void AddStock(Stock stock)
        {
            try
            {
                dataContext.Stocks.Add(stock);
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException($"Stock with Id {stock.Id} do not exist.", e);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException($"Stock with Id {stock.Id} already exists.", e);
            }
        }

        public void DeleteCar(Car car)
        {
            if (dataContext.Cars.ContainsKey(car.Id))
            {
                dataContext.Cars.Remove(car.Id);
            }
            else
            {
                throw new ArgumentException($"There isn't car with {car.Id} id in reposotry");
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
                throw new ArgumentException($"There isn't client with {client.Id} id in reposotry");
            }
        }

        public void DeleteFacture(Facture facture)
        {
            if (dataContext.Factures.Contains(facture))
            {
                dataContext.Cars.Remove(facture.Id);
            }
            else
            {
                throw new ArgumentException($"There isn't facture with {facture.Id} id in reposotry");
            }
        }

        public void DeleteStock(Stock stock)
        {
            if (dataContext.Cars.ContainsKey(stock.Id))
            {
                dataContext.Cars.Remove(stock.Id);
            }
            else
            {
                throw new ArgumentException($"There isn't stock with {stock.Id} id in reposotry");
            }
        }

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

        public IEnumerable<Stock> GetAllStockss()
        {
            return dataContext.Stocks;
        }

        public Car GetCar(Guid id)
        {
            if (dataContext.Cars.Count != 0)
            {
                return dataContext.Cars[id];
            }
            else
            {
                return null;
            }  
        }

        public Client GetClient(Guid id)
        {
            if (dataContext.Clients.Count != 0)
            {
                int pom = 0;
                for (int i = 0; i < dataContext.Clients.Count; i++)
                {
                    if (dataContext.Clients[i].Id.Equals(id))
                    {
                        pom = i;
                    }
                }
                return dataContext.Clients[pom];
            }
            else
            {
                return null;
            }
            
        }

        public Facture GetFacture(Guid id)
        {
            if (dataContext.Factures.Count != 0)
            {
                int pom = 0;
            for (int i = 0; i < dataContext.Factures.Count; i++)
            {
                if (dataContext.Factures[i].Id.Equals(id))
                {
                    pom = i;
                }
            }
            return dataContext.Factures[pom];
        }
            else
            {
                return null;
            }
        }

        public Stock GetStock(Guid id)
        {
            if (dataContext.Stocks.Count != 0)
            {
                int pom = 0;
                for (int i = 0; i < dataContext.Stocks.Count; i++)
                {
                    if (dataContext.Stocks[i].Id.Equals(id))
                    {
                        pom = i;
                    }
                }
                return dataContext.Stocks[pom];
            }
         
             else
            {
                return null;
            }
        }

        public void UpdateCar(Guid id, Car car)
        {
            if (!dataContext.Cars.ContainsKey(id))
            {
                throw new ArgumentException("Car with this ID doesn't exist");
            }
            dataContext.Cars[id] = car;


        }

/*        public void UpdateClient(Guid id, Client client)
        {

            for (int i = 0; i <= dataContext.Clients.Count; i++)
            {
                if (dataContext.Clients[i].Id.Equals(id))
                {
                    dataContext.Clients[i] = client;
                }
            }
        }*/

        public void UpdateClient(Guid id, Client author)
        {
            Client updatedClient = dataContext.Clients.Find(a => a.Id.Equals(id));

            if (updatedClient == null)
            {
                throw new ArgumentException("Author with this ID doesn't exist");
            }

             dataContext.Clients[dataContext.Clients.IndexOf(updatedClient)] = author;
        }

        public void UpdateFacture(Guid id, Facture facture)
        {
            int pom = 0;
            for (int i = 0; i <= dataContext.Factures.Count; i++)
            {
                if (dataContext.Factures[i].Id.Equals(id))
                {
                    dataContext.Factures[i] = facture;
                }
            }
        }

        public void UpdateStock(Guid id, Stock stock)
        {

            for (int i = 0; i <= dataContext.Stocks.Count; i++)
            {
                if (dataContext.Stocks[i].Id.Equals(id))
                {
                    dataContext.Stocks[i] = stock;
                }
            }
        }
    }
}
