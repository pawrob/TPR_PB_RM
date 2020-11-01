using System;
using System.Collections.Generic;
using System.Text;
using TP.Objects;

namespace TP
{
    public class DataRepository : IDataRepository
    {

        private DataContext dataContext = new DataContext();

        public DataRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
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
                throw new ArgumentException($"There isn't car with {client.Id} id in reposotry");
            }
        }

        public void DeleteFacture(Facture facture)
        {
            if (dataContext.Factures.Contains(facture)
            {
                dataContext.Cars.Remove(facture.Id);
            }
            else
            {
                throw new ArgumentException($"There isn't car with {facture.Id} id in reposotry");
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
                throw new ArgumentException($"There isn't car with {stock.Id} id in reposotry");
            }
        }

        public IEnumerable<Car> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetAllClients()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Facture> GetAllFactures()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAllStockss()
        {
            throw new NotImplementedException();
        }

        public Car GetCar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Client GetClient(Guid id)
        {
            throw new NotImplementedException();
        }

        public Car GetFacture(Guid id)
        {
            throw new NotImplementedException();
        }

        public Car GetStock(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCar(Guid id, Car car)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(Guid id, Client client)
        {
            throw new NotImplementedException();
        }

        public void UpdateFacture(Guid id, Facture facture)
        {
            throw new NotImplementedException();
        }

        public void UpdateStock(Guid id, Stock stock)
        {
            throw new NotImplementedException();
        }
    }
}
