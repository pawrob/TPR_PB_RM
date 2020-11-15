using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_DL.Objects;
using TP_DL;
using System.Linq;
using System;

namespace TP_UnitTests
{
    [TestClass]
    public class DataLayerUnitTests
    {

        DataRepository dataRepository = new DataRepository();


        [TestMethod]
        public void ObjectsDataFiller()
        {
            DataManualFiller df1 = new DataManualFiller();
            dataRepository.DataFiller = df1;
            dataRepository.FillData();
            Assert.AreEqual(1, dataRepository.GetAllClients().Count());
        }

        [TestMethod]
        public void XMLDataFiller()
        {
            DataXMLFiller df1 = new DataXMLFiller();
            dataRepository.DataFiller = df1;
            dataRepository.FillData();
            Assert.AreEqual(5, dataRepository.GetAllClients().Count());
        }

        [TestMethod]
        public void AddClientTest()
        {

            Client c1 = new Client("Jan", "Kowalski", 111111, Guid.Parse("1981e86b-2f16-4b61-9d91-664bfed3ebc5"));
            dataRepository.AddClient(c1);
            Assert.IsTrue(c1.Equals(dataRepository.GetClient(c1.Id)));

        }
        [TestMethod]
        public void RemoveClientTest()
        {
            
            Client c2 = new Client("Karol", "Kowalski",222222, Guid.Parse("03e0c811-7c69-4924-b0e0-b2a44065b9bd"));
            dataRepository.AddClient(c2);

            Assert.IsTrue(c2.Equals(dataRepository.GetClient(c2.Id)));

            dataRepository.DeleteClient(c2);
            Assert.ThrowsException<ArgumentNullException>(() => dataRepository.GetClient(c2.Id));

        }
        [TestMethod]
        public void UpdateClientTest()
        {
            Client c1 = new Client("Jan", "Kowalski", 111111, Guid.Parse("1981e86b-2f16-4b61-9d91-664bfed3ebc5"));
            Client c2 = new Client("Karol", "Kowalski", 222222, Guid.Parse("03e0c811-7c69-4924-b0e0-b2a44065b9bd"));
            dataRepository.AddClient(c1);
            dataRepository.UpdateClient(c1.Id, c2);
            Assert.IsTrue(dataRepository.GetClient(c2.Id) == c2);


        }
        [TestMethod]
        public void GetClientTest()
        {
            Client c1 = new Client("Jan", "Kowalski", 111111, Guid.Parse("1981e86b-2f16-4b61-9d91-664bfed3ebc5"));
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
            Client c1 = new Client("Jan", "Kowalski", 111111, Guid.Parse("1981e86b-2f16-4b61-9d91-664bfed3ebc5"));
            WarehouseItem wi1 = new WarehouseItem(Car1,10000, Guid.Parse("594e4c41-7e20-432c-9773-085d75e9b90b")); 
            Facture f1 = new Facture(c1, wi1, Guid.Parse("594e4c41-7e20-432c-9773-085d75e9b90b"), Convert.ToDateTime("5.11.2020"));
            dataRepository.AddFacture(f1);
            Assert.AreEqual(dataRepository.GetFacture(f1.Id), f1);
        }
        [TestMethod]
        public void RemoveFactureTest()
        {
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            Client c1 = new Client("Jan", "Kowalski", 111111, Guid.Parse("1981e86b-2f16-4b61-9d91-664bfed3ebc5"));
            WarehouseItem wi1 = new WarehouseItem(Car1, 10000, Guid.Parse("594e4c41-7e20-432c-9773-085d75e9b90b"));
            Facture f1 = new Facture(c1, wi1, Guid.Parse("594e4c41-7e20-432c-9773-085d75e9b90b"), Convert.ToDateTime("5.11.2020"));
            dataRepository.AddFacture(f1);
            Assert.AreEqual(dataRepository.GetFacture(f1.Id), f1);
            dataRepository.DeleteFacture(f1);
            Assert.AreEqual(0, dataRepository.GetAllFactures().Count());

        }
        [TestMethod]
        public void UpdateFactureTest()
        {
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            Client c1 = new Client("Jan", "Kowalski", 111111, Guid.Parse("1981e86b-2f16-4b61-9d91-664bfed3ebc5"));
            WarehouseItem wi1 = new WarehouseItem(Car1, 10000, Guid.Parse("594e4c41-7e20-432c-9773-085d75e9b90b"));
            Facture f1 = new Facture(c1, wi1, Guid.Parse("594e4c41-7e20-432c-9773-085d75e9b90b"), Convert.ToDateTime("5.11.2020"));
            dataRepository.AddFacture(f1);
            Car Car2 = new Car("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            WarehouseItem wi2 = new WarehouseItem(Car2, 210000, Guid.Parse("2273ec6b-7c26-4bce-8ec0-00a2773d108a"));
            Facture f2 = new Facture(c1, wi2, Guid.Parse("bef406e7-61b5-4a14-86b7-d20af86cb752"), Convert.ToDateTime("8.11.2020"));
            dataRepository.UpdateFacture(f1.Id, f2);

            Assert.AreEqual(f2, dataRepository.GetAllFactures().First());
        }
        [TestMethod]
        public void GetFactureTest()
        {
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            Client c1 = new Client("Jan", "Kowalski", 111111, Guid.Parse("1981e86b-2f16-4b61-9d91-664bfed3ebc5"));
            WarehouseItem wi1 = new WarehouseItem(Car1, 10000, Guid.Parse("594e4c41-7e20-432c-9773-085d75e9b90b"));
            Facture f1 = new Facture(c1, wi1, Guid.Parse("594e4c41-7e20-432c-9773-085d75e9b90b"), Convert.ToDateTime("5.11.2020"));
            dataRepository.AddFacture(f1);
            Assert.IsTrue(dataRepository.GetFacture(f1.Id) == f1);
        }

        [TestMethod]
        public void AddWarehouseItemTest()
        {
            Assert.AreEqual(0, dataRepository.GetAllWarehouseItems().Count());
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            Client c1 = new Client("Jan", "Kowalski", 111111, Guid.Parse("1981e86b-2f16-4b61-9d91-664bfed3ebc5"));
            WarehouseItem wi1 = new WarehouseItem(Car1, 10000, Guid.Parse("594e4c41-7e20-432c-9773-085d75e9b90b"));
            dataRepository.AddWarehouseItem(wi1);
            Assert.AreEqual(1, dataRepository.GetAllWarehouseItems().Count()); 
        }
        [TestMethod]
        public void RemoveWarehouseItemTest()
        {
            Assert.AreEqual(0, dataRepository.GetAllWarehouseItems().Count());
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            Client c1 = new Client("Jan", "Kowalski", 111111, Guid.Parse("1981e86b-2f16-4b61-9d91-664bfed3ebc5"));
            WarehouseItem wi1 = new WarehouseItem(Car1, 10000, Guid.Parse("594e4c41-7e20-432c-9773-085d75e9b90b"));
            dataRepository.AddWarehouseItem(wi1);
            Assert.AreEqual(1, dataRepository.GetAllWarehouseItems().Count());
            dataRepository.DeleteWarehouseItem(wi1);
            Assert.AreEqual(0, dataRepository.GetAllWarehouseItems().Count());
        }
        [TestMethod]
        public void UpdateWarehouseItemTest()
        {
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            Client c1 = new Client("Jan", "Kowalski", 111111, Guid.Parse("1981e86b-2f16-4b61-9d91-664bfed3ebc5"));
            WarehouseItem wi1 = new WarehouseItem(Car1, 10000, Guid.Parse("594e4c41-7e20-432c-9773-085d75e9b90b"));
            dataRepository.AddWarehouseItem(wi1);
            Car Car2 = new Car("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            WarehouseItem wi2 = new WarehouseItem(Car2, 210000, Guid.Parse("6f16b79d-f9fd-4cc3-8e46-78f8a799b176"));

            dataRepository.UpdateWarehouseItem(wi1.Id, wi2);

            Assert.AreEqual(wi2, dataRepository.GetAllWarehouseItems().First());
        }
        [TestMethod]
        public void GetWarehouseItemTest()
        {
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            Client c1 = new Client("Jan", "Kowalski", 111111, Guid.Parse("1981e86b-2f16-4b61-9d91-664bfed3ebc5"));
            WarehouseItem wi1 = new WarehouseItem(Car1, 10000, Guid.Parse("594e4c41-7e20-432c-9773-085d75e9b90b"));
            dataRepository.AddWarehouseItem(wi1);
            Assert.AreEqual(dataRepository.GetWarehouseItem(wi1.Id), wi1);
        }
    }
}
