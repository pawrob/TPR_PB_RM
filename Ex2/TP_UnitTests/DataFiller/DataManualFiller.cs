using System;
using TP_DL;
using TP_DL.Objects;


namespace TP_UnitTests
{
    public class DataManualFiller : IDataFiller
    {

        public DataManualFiller(){}

        public void InsertData(DataContext dataContext)
        {
            Client c1 = new Client("John", "Doe", 000000000, Guid.NewGuid());
            Client c2 = new Client("Jack", "Karabinczyk", 213721151, Guid.NewGuid());
            Client c3 = new Client("Peter", "Parker", 123456789, Guid.NewGuid());
            Car Car2 = new Car("Skoda", "Fabia", "Style", 210, "Silver Metalic", VehicleType.Small_car, FuelType.Petrol, Transmission.Manual);
            Car Car1 = new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            
            WarehouseItem wi1 = new WarehouseItem(Car1, 10000, Guid.Parse("594e4c41-7e20-432c-9773-085d75e9b80b"));
            SellCar f1 = new SellCar(c1, wi1, Guid.Parse("594e4c41-7e20-432c-9773-085d75e9b90b"), Convert.ToDateTime("5.11.2020"));
            BuyCar b1 = new BuyCar(wi1, Guid.Parse("594e4c41-7e20-432c-9773-085d75e9b91b"), Convert.ToDateTime("5.11.2020"));

            dataContext.Clients.Add(c1);
            dataContext.Clients.Add(c2);
            dataContext.Clients.Add(c3);
            dataContext.Cars.Add(Guid.Parse("594e4c41-7e20-432c-9773-085d75e9b80d"),Car1);
            dataContext.Cars.Add(Guid.Parse("694e4c41-7e20-432c-9773-085d75e9b80d"), Car2);
            dataContext.WarehouseItems.Add(wi1);
            dataContext.BoughtCars.Add(b1);
            dataContext.SoldCars.Add(f1);
        }
    }
}
