using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP.Objects;
using TP;
using System.Linq;
using System;

namespace DataLayerTests
{
    [TestClass]
    public class DataLayerUnitTests
    {

        DataRepository dataRepository = new DataRepository();

        [TestMethod]
        public void AddClientTest()
        {

            Client c1 = new Client("Jan", "Kowalski", 111111);
            dataRepository.AddClient(c1);
            Assert.IsTrue(c1.Equals(dataRepository.GetClient(c1.Id)));

        }
        [TestMethod]
        public void RemoveClientTest()
        {
            
            Client c2 = new Client("Karol", "Kowalski",222222);
            dataRepository.AddClient(c2);

            Assert.IsTrue(c2.Equals(dataRepository.GetClient(c2.Id)));

            dataRepository.DeleteClient(c2);
            Assert.ThrowsException<ArgumentNullException>(() => dataRepository.GetClient(c2.Id));

        }
        [TestMethod]
        public void UpdateClientTest()
        {
            Client c1 = new Client("Jan", "Kowalski", 111111);
            Client c2 = new Client("Karol", "Kowalski", 222222);
            dataRepository.AddClient(c1);
            dataRepository.UpdateClient(c1.Id, c2);
            Assert.IsTrue(dataRepository.GetClient(c2.Id) == c2);


        }
        [TestMethod]
        public void GetClientTest()
        {
            Client c1 = new Client("Jan", "Kowalski", 111111);
            dataRepository.AddClient(c1);
            Assert.IsTrue(dataRepository.GetClient(c1.Id) == c1);
        }



        [TestMethod]
        public void AddCarTest()
        {

            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            dataRepository.AddCar(Car1);
            Assert.IsTrue(Car1.Equals(dataRepository.GetCar(Car1.Id)));


        }
        [TestMethod]
        public void RemoveCarTest()
        {

            Car Car2 = new Car("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            dataRepository.AddCar(Car2);
            Assert.IsTrue(Car2.Equals(dataRepository.GetCar(Car2.Id)));

            dataRepository.DeleteCar(Car2);
            Assert.ThrowsException<ArgumentNullException>(() => dataRepository.GetCar(Car2.Id));
        }
         [TestMethod]
         public void UpdateCarTest()
         {
             Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
             Car Car2 = new Car("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
             dataRepository.AddCar(Car1);
             dataRepository.UpdateCar(Car1.Id, Car2);

             Assert.AreEqual(Car2, dataRepository.GetAllCars().First());
        }
        [TestMethod]
        public void GetCarTest()
        {
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            dataRepository.AddCar(Car1);
            Assert.IsTrue(dataRepository.GetCar(Car1.Id) == Car1);


        }
        [TestMethod]
        public void AddFactureTest()
        {
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            Client c1 = new Client("Jan", "Kowalski", 111111);
            WarehouseItem wi1 = new WarehouseItem(Car1,10000);
            Facture f1 = new Facture(c1, wi1);
            dataRepository.AddFacture(f1);
            Assert.AreEqual(dataRepository.GetFacture(f1.Id), f1);
        }
        [TestMethod]
        public void RemoveFactureTest()
        {
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            Client c1 = new Client("Jan", "Kowalski", 111111);
            WarehouseItem wi1 = new WarehouseItem(Car1, 10000);
            Facture f1 = new Facture(c1, wi1);
            dataRepository.AddFacture(f1);
            Assert.AreEqual(dataRepository.GetFacture(f1.Id), f1);
            dataRepository.DeleteFacture(f1);
            Assert.AreEqual(0, dataRepository.GetAllFactures().Count());

        }
        [TestMethod]
        public void UpdateFactureTest()
        {
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            Client c1 = new Client("Jan", "Kowalski", 111111);
            WarehouseItem wi1 = new WarehouseItem(Car1, 10000);
            Facture f1 = new Facture(c1, wi1);
            dataRepository.AddFacture(f1);
            Car Car2 = new Car("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            WarehouseItem wi2 = new WarehouseItem(Car2, 210000);
            Facture f2 = new Facture(c1, wi2);
            dataRepository.UpdateFacture(f1.Id, f2);

            Assert.AreEqual(f2, dataRepository.GetAllFactures().First());
        }
        [TestMethod]
        public void GetFactureTest()
        {
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            Client c1 = new Client("Jan", "Kowalski", 111111);
            WarehouseItem wi1 = new WarehouseItem(Car1, 10000);
            Facture f1 = new Facture(c1, wi1);
            dataRepository.AddFacture(f1);
            Assert.IsTrue(dataRepository.GetFacture(f1.Id) == f1);
        }

        [TestMethod]
        public void AddWarehouseItemTest()
        {
            Assert.AreEqual(0, dataRepository.GetAllWarehouseItems().Count());
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            Client c1 = new Client("Jan", "Kowalski", 111111);
            WarehouseItem wi1 = new WarehouseItem(Car1, 10000);
            dataRepository.AddWarehouseItem(wi1);
            Assert.AreEqual(1, dataRepository.GetAllWarehouseItems().Count()); 
        }
        [TestMethod]
        public void RemoveWarehouseItemTest()
        {
            Assert.AreEqual(0, dataRepository.GetAllWarehouseItems().Count());
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            Client c1 = new Client("Jan", "Kowalski", 111111);
            WarehouseItem wi1 = new WarehouseItem(Car1, 10000);
            dataRepository.AddWarehouseItem(wi1);
            Assert.AreEqual(1, dataRepository.GetAllWarehouseItems().Count());
            dataRepository.DeleteWarehouseItem(wi1);
            Assert.AreEqual(0, dataRepository.GetAllWarehouseItems().Count());
        }
        [TestMethod]
        public void UpdateWarehouseItemTest()
        {
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            Client c1 = new Client("Jan", "Kowalski", 111111);
            WarehouseItem wi1 = new WarehouseItem(Car1, 10000);
            dataRepository.AddWarehouseItem(wi1);
            Car Car2 = new Car("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            WarehouseItem wi2 = new WarehouseItem(Car2, 210000);

            dataRepository.UpdateWarehouseItem(wi1.Id, wi2);

            Assert.AreEqual(wi2, dataRepository.GetAllWarehouseItems().First());
        }
        [TestMethod]
        public void GetWarehouseItemTest()
        {
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            Client c1 = new Client("Jan", "Kowalski", 111111);
            WarehouseItem wi1 = new WarehouseItem(Car1, 10000);
            dataRepository.AddWarehouseItem(wi1);
            Assert.AreEqual(dataRepository.GetWarehouseItem(wi1.Id), wi1);
        }
    }
}
