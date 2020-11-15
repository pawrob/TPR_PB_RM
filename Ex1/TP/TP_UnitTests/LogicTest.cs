using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TP_DL;
using TP_DL.Objects;
using TP_LL;

namespace TP_UnitTests
{
    [TestClass]
    public class LogicLayerUnitTests
    {
        public DataService dataService = new DataService(new DataRepository(null));


        [TestMethod]
        public void AddClientTest()
        {
            Assert.AreEqual(0, dataService.GetAllClients().Count());
            dataService.AddClient("Andrzej","Nowak",123456789);
            Assert.AreEqual(1, dataService.GetAllClients().Count());


        }
        [TestMethod]
        public void RemoveClientTest()
        {
            Assert.AreEqual(0, dataService.GetAllClients().Count());
            dataService.AddClient("Andrzej", "Nowak", 123456789);
            Assert.AreEqual(1, dataService.GetAllClients().Count());
            dataService.DeleteClient(dataService.GetAllClients().First());
            Assert.AreEqual(0, dataService.GetAllClients().Count());


        }
        [TestMethod]
        public void UpdateClientTest()
        {
            dataService.AddClient("Andrzej", "Nowak", 123456789);
            Assert.AreEqual(1, dataService.GetAllClients().Count());
            Client c1 = new Client("Marian", "Kowalski", 987654321, new System.Guid());
            dataService.updateClient(dataService.GetAllClients().First().Id, c1);
            Assert.AreEqual(dataService.GetAllClients().First(), c1);


        }


        [TestMethod]
        public void AddCarTest()
        {

            Assert.AreEqual(0, dataService.GetAllCars().Count());
            dataService.AddCar("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            Assert.AreEqual(1, dataService.GetAllCars().Count());

        }
        [TestMethod]
        public void RemoveCarTest()
        {
            Assert.AreEqual(0, dataService.GetAllCars().Count());
            dataService.AddCar("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            Assert.AreEqual(1, dataService.GetAllCars().Count());
            dataService.DeleteCar(dataService.GetAllCars().First());
            Assert.AreEqual(0, dataService.GetAllCars().Count());

        }

        [TestMethod]
        public void AddFactureTest()
        {
            Assert.AreEqual(0, dataService.GetAllFactures().Count());
            dataService.AddClient("Andrzej", "Nowak", 123456789);
            dataService.AddCar("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            dataService.AddWarehouseItem(dataService.GetAllCars().First(), 10000);
            dataService.AddFacture(dataService.GetAllClients().First(), dataService.GetAllWarehouseItems().First());
            Assert.AreEqual(1, dataService.GetAllCars().Count());
        }
        [TestMethod]
        public void RemoveFactureTest()
        {
            Assert.AreEqual(0, dataService.GetAllFactures().Count());
            dataService.AddClient("Andrzej", "Nowak", 123456789);
            dataService.AddCar("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            dataService.AddWarehouseItem(dataService.GetAllCars().First(), 10000);
            dataService.AddFacture(dataService.GetAllClients().First(), dataService.GetAllWarehouseItems().First());
            Assert.AreEqual(1, dataService.GetAllCars().Count());
            dataService.DeleteFacture(dataService.GetAllFactures().First());
            Assert.AreEqual(0, dataService.GetAllFactures().Count());
        }
        [TestMethod]
        public void UpdateFactureTest()
        {
            Assert.AreEqual(0, dataService.GetAllFactures().Count());
            dataService.AddClient("Andrzej", "Nowak", 123456789);
            dataService.AddClient("Marian", "Kowalski", 987654321);
            dataService.AddCar("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            dataService.AddWarehouseItem(dataService.GetAllCars().First(), 10000);
            dataService.AddFacture(dataService.GetAllClients().First(), dataService.GetAllWarehouseItems().First());
            Facture f2 = new Facture(dataService.GetAllClients().Last(), dataService.GetAllWarehouseItems().First(), new Guid(), DateTime.Now);
            dataService.updateFacture(dataService.GetAllFactures().First().Id, f2);

            Assert.AreEqual(dataService.GetAllFactures().First(), f2);

        }



        [TestMethod]
        public void AddBillTest()
        {
            Assert.AreEqual(0, dataService.GetAllBills().Count());

            dataService.AddCar("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            dataService.AddWarehouseItem(dataService.GetAllCars().First(), 10000);
            dataService.AddBill(dataService.GetAllWarehouseItems().First());
            Assert.AreEqual(1, dataService.GetAllCars().Count());
        }
        [TestMethod]
        public void RemoveBillTest()
        {
            Assert.AreEqual(0, dataService.GetAllBills().Count());

            dataService.AddCar("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            dataService.AddWarehouseItem(dataService.GetAllCars().First(), 10000);
            dataService.AddBill(dataService.GetAllWarehouseItems().First());
            Assert.AreEqual(1, dataService.GetAllCars().Count());
            dataService.DeleteBill(dataService.GetAllBills().First());
            Assert.AreEqual(0, dataService.GetAllBills().Count());
        }
        [TestMethod]
        public void UpdateBillTest()
        {
            Assert.AreEqual(0, dataService.GetAllBills().Count());

            dataService.AddCar("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            dataService.AddWarehouseItem(dataService.GetAllCars().First(), 10000);
            dataService.AddBill(dataService.GetAllWarehouseItems().First());
            BillOfSale b2 = new BillOfSale(dataService.GetAllWarehouseItems().First(), new Guid(), DateTime.Now);
            dataService.updateBill(dataService.GetAllBills().First().Id, b2);

            Assert.AreEqual(dataService.GetAllBills().First(), b2);

        }

        [TestMethod]
        public void AddWarehouseItemTest()
        {
            Assert.AreEqual(0, dataService.GetAllWarehouseItems().Count());
            dataService.AddClient("Andrzej", "Nowak", 123456789);
            dataService.AddCar("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            dataService.AddWarehouseItem(dataService.GetAllCars().First(), 10000);
            Assert.AreEqual(1, dataService.GetAllWarehouseItems().Count());
        }
        [TestMethod]
        public void RemoveWarehouseItemTest()
        {


            Assert.AreEqual(0, dataService.GetAllWarehouseItems().Count());
            dataService.AddClient("Andrzej", "Nowak", 123456789);
            dataService.AddCar("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            dataService.AddWarehouseItem(dataService.GetAllCars().First(), 10000);
            Assert.AreEqual(1, dataService.GetAllWarehouseItems().Count());
            dataService.DeleteWarehouseItem(dataService.GetAllWarehouseItems().First());
            Assert.AreEqual(0, dataService.GetAllWarehouseItems().Count());
        }


        
        
    }
}
