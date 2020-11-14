using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TP;
using TP.Objects;
using TP_LL;

namespace LogicLayerTests
{
    [TestClass]
    public class LogicLayerUnitTests
    {
        public DataService dataService = new DataService(new DataRepository());


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
           


        }
        [TestMethod]
        public void GetClientTest()
        {
           
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
        public void UpdateCarTest()
        {
           
        }
        [TestMethod]
        public void GetCarTest()
        {
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
/*            Assert.AreEqual(0, dataService.GetAllFactures().Count());
            dataService.AddClient("Andrzej", "Nowak", 123456789);
            dataService.AddCar("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            dataService.AddWarehouseItem(dataService.GetAllCars().First(), 10000);
            dataService.AddFacture(dataService.GetAllClients().First(), dataService.GetAllWarehouseItems().First());
            Assert.AreEqual(1, dataService.GetAllCars().Count());
            dataService.DeleteFacture(dataService.GetAllFactures().First());
            Assert.AreEqual(0, dataService.GetAllFactures().Count());*/
        }
        [TestMethod]
        public void UpdateFactureTest()
        {
           
        }
        [TestMethod]
        public void GetFactureTest()
        {
           
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


            /*Assert.AreEqual(0, dataService.GetAllWarehouseItems().Count());
            dataService.AddClient("Andrzej", "Nowak", 123456789);
            dataService.AddCar("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            dataService.AddWarehouseItem(dataService.GetAllCars().First(), 10000);
            Assert.AreEqual(1, dataService.GetAllWarehouseItems().Count());
            dataService.DeleteWarehouseItem(dataService.GetAllWarehouseItems().First());
            Assert.AreEqual(0, dataService.GetAllWarehouseItems().Count());*/
        }
        [TestMethod]
        public void UpdateWarehouseItemTest()
        {

        }
        [TestMethod]
        public void GetWarehouseItemTest()
        {

        }

        
    }
}
