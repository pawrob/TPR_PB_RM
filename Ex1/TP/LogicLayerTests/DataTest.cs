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

        DataRepository dp = new DataRepository();
        [TestMethod]
        public void AddClientTest()
        {

            Client c1 = new Client("Jan", "Kowalski", 111111);
            dp.AddClient(c1);
            Assert.IsTrue(c1.Equals(dp.GetClient(c1.Id)));

        }
        [TestMethod]
        public void RemoveClientTest()
        {
            
            Client c2 = new Client("Karol", "Kowalski",222222);
            dp.AddClient(c2);

            Assert.IsTrue(c2.Equals(dp.GetClient(c2.Id)));

            dp.DeleteClient(c2);
            Assert.IsNull(dp.GetClient(c2.Id));

        }
        [TestMethod]
        public void UpdateClientTest()
        {
            Client c1 = new Client("Jan", "Kowalski", 111111);
            Client c2 = new Client("Karol", "Kowalski", 222222);
            dp.AddClient(c1);
            dp.UpdateClient(c1.Id, c2);
            Assert.IsTrue(dp.GetClient(c2.Id) == c2);


        }
        [TestMethod]
        public void GetClientTest()
        {
            Client c1 = new Client("Jan", "Kowalski", 111111);
            dp.AddClient(c1);
            Assert.IsTrue(dp.GetClient(c1.Id) == c1);


        }



        [TestMethod]
        public void AddCarTest()
        {

            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            dp.AddCar(Car1);
            Assert.IsTrue(Car1.Equals(dp.GetCar(Car1.Id)));

        }
        [TestMethod]
        public void RemoveCarTest()
        {

            Car Car2 = new Car("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            dp.AddCar(Car2);
            Assert.IsTrue(Car2.Equals(dp.GetCar(Car2.Id)));

            dp.DeleteCar(Car2);
            Assert.IsNull(dp.GetCar(Car2.Id));

        }
         [TestMethod]
         public void UpdateCarTest()
         {
             Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
             Car Car2 = new Car("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
             dp.AddCar(Car1);
             dp.UpdateCar(Car1.Id, Car2);
             Console.WriteLine(Car1);
             Console.WriteLine(Car2);
            Assert.AreEqual(Car2, dp.GetAllCars().First());
        }
        [TestMethod]
        public void GetCarTest()
        {
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            dp.AddCar(Car1);
            Assert.IsTrue(dp.GetCar(Car1.Id) == Car1);


        }
    }
}
